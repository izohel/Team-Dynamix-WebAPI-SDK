using Itsm.Tdx.WebApi.Extensions;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;

namespace Itsm.Tdx.WebApi;
public abstract class TdxBaseClient
{
    protected readonly HttpClient HttpClient;
    protected readonly AsyncRetryPolicy<HttpResponseMessage> RetryPolicy;
    protected readonly TdxClientOptions TdxClientOptions;
    protected string? Token;
    protected TdxBaseClient(HttpClient httpClient, string tenant, TdxClientOptions? options)
    : this(httpClient, options)
    {
        if (httpClient.BaseAddress == null)
        {
            httpClient.BaseAddress = BuildBaseUri(tenant, options ?? new TdxClientOptions());
        }
    }
    protected TdxBaseClient(HttpClient httpClient, TdxClientOptions? options)
    {
        HttpClient = httpClient;
        TdxClientOptions = options ?? new TdxClientOptions();
        RetryPolicy = CreateRetryPolicy(TdxClientOptions);
    }
    protected static Uri BuildBaseUri(string tenant, TdxClientOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.BaseApiUrl))
            return new Uri(options.BaseApiUrl);

        ArgumentException.ThrowIfNullOrWhiteSpace(tenant, "Tenant is required if BaseApiUrl is not set.");
        string url = $"https://{tenant}.teamdynamix.com/TDWebApi/api/";
        return new Uri(url);
    }
    protected static AsyncRetryPolicy<HttpResponseMessage> CreateRetryPolicy(TdxClientOptions clientOptions)
    {
        int retryCount = clientOptions.MaxRetries;
        return Policy<HttpResponseMessage>
            .HandleResult(resp => resp.StatusCode == HttpStatusCode.TooManyRequests)
            .WaitAndRetryAsync(
                retryCount: 1,
                sleepDurationProvider: (retryAttempt, context) =>
                {
                    if (context.TryGetValue("X-RateLimit-Reset", out object? resetObj) && resetObj is DateTime resetTime)
                    {
                        TimeSpan wait = resetTime - DateTime.UtcNow;
                        return wait > TimeSpan.Zero
                            ? wait.Add(TimeSpan.FromSeconds(5))
                            : TimeSpan.FromSeconds(5);
                    }
                    return TimeSpan.FromSeconds(5);
                },
                onRetryAsync: async (outcome, timespan, retryCount, context) =>
                {
                    if (clientOptions.EnableThrottleCountdownLogging && clientOptions.OnThrottleWait != null)
                    {
                        TimeSpan remaining = timespan;
                        while (remaining > TimeSpan.Zero)
                        {
                            clientOptions.OnThrottleWait(remaining);
                            TimeSpan delay = remaining > TimeSpan.FromSeconds(5) ? TimeSpan.FromSeconds(5) : remaining;
                            await Task.Delay(delay);
                            remaining -= delay;
                        }
                    }
                    else
                    {
                        clientOptions.OnThrottleWait?.Invoke(timespan);
                        await Task.Delay(timespan);
                    }
                    clientOptions.OnThrottleContinue?.Invoke();
                });
    }

    public void SetToken(string token) => Token = token;
    protected void AddAuthorization(HttpRequestMessage request)
    {
        if (!string.IsNullOrWhiteSpace(Token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
    }

    public async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request)
    {
        return await SendWithPolicyAsync(request);
    }

    public async Task<T> SendRequestAsync<T>(HttpRequestMessage request)
    {
        HttpResponseMessage response = await SendWithPolicyAsync(request);

        if (!response.IsSuccessStatusCode)
            throw new InvalidOperationException($"Request failed with status {response.StatusCode}");

        string content = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(content))
            throw new InvalidOperationException("Empty response content.");

        T? result = JsonConvert.DeserializeObject<T>(content);
        return result ?? throw new InvalidOperationException($"Could not deserialize response to {typeof(T)}");
    }

    private async Task<HttpResponseMessage> SendWithPolicyAsync(HttpRequestMessage request)
    {
        ArgumentNullException.ThrowIfNull(request);
        AddAuthorization(request);
        Context context = new();
        HttpResponseMessage response = await RetryPolicy.ExecuteAsync(async ctx =>
        {
            HttpResponseMessage resp = await HttpClient.SendAsync(request);

            if (resp.Headers.TryGetValues("X-RateLimit-Reset", out IEnumerable<string>? values))
            {
                string? resetTimeStr = values.FirstOrDefault();
                if (DateTime.TryParse(resetTimeStr, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out DateTime resetTime))
                    ctx["X-RateLimit-Reset"] = resetTime;
            }

            return resp;
        }, context);

        return response;
    }
}
