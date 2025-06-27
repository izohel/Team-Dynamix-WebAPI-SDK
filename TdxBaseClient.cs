using Itsm.Tdx.WebApi.Extensions;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;

namespace Itsm.Tdx.WebApi;
/// <summary>
/// Base abstract client for interacting with the TeamDynamix API.
/// Provides core HTTP communication features such as:
/// - Configurable <see cref="HttpClient"/> with base address setup.
/// - Retry policy handling for HTTP 429 (Too Many Requests) throttling responses.
/// - Token-based authorization header management.
/// - Generic request sending methods with built-in retry logic and deserialization.
/// </summary>
/// <remarks>
/// This class serves as the foundation for more specific TeamDynamix API clients.
/// It handles common concerns like retrying throttled requests, managing authentication tokens,
/// and deserializing API responses into strongly-typed objects.
/// </remarks>
public abstract class TdxBaseClient
{
    /// <summary>
    /// The underlying <see cref="HttpClient"/> used to send HTTP requests.
    /// </summary>
    protected readonly HttpClient HttpClient;

    /// <summary>
    /// The retry policy used to handle throttling responses (HTTP 429) with backoff.
    /// </summary>
    protected readonly AsyncRetryPolicy<HttpResponseMessage> RetryPolicy;

    /// <summary>
    /// The configuration options for this client instance.
    /// </summary>
    protected readonly TdxClientOptions TdxClientOptions;

    /// <summary>
    /// The bearer token used for API authorization. Null if not authenticated.
    /// </summary>
    protected string? Token;

    /// <summary>
    /// Initializes a new instance of <see cref="TdxBaseClient"/>,
    /// setting the base URI if not already set on the provided <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="httpClient">The HTTP client to use for requests.</param>
    /// <param name="tenant">The tenant identifier or base URL part used to build the API base URI if necessary.</param>
    /// <param name="options">Optional client configuration options.</param>
    protected TdxBaseClient(HttpClient httpClient, string tenant, TdxClientOptions? options)
        : this(httpClient, options)
    {
        if (httpClient.BaseAddress == null)
        {
            httpClient.BaseAddress = BuildBaseUri(tenant, options ?? new TdxClientOptions());
        }
    }

    /// <summary>
    /// Initializes a new instance of <see cref="TdxBaseClient"/> with the given <see cref="HttpClient"/>
    /// and client options, creating the retry policy accordingly.
    /// </summary>
    /// <param name="httpClient">The HTTP client to use for requests.</param>
    /// <param name="options">Optional client configuration options.</param>
    protected TdxBaseClient(HttpClient httpClient, TdxClientOptions? options)
    {
        HttpClient = httpClient;
        TdxClientOptions = options ?? new TdxClientOptions();
        RetryPolicy = CreateRetryPolicy(TdxClientOptions);
    }

    /// <summary>
    /// Builds the base URI for API calls based on the tenant or explicit BaseApiUrl.
    /// </summary>
    /// <param name="tenant">The tenant name or base URL fragment.</param>
    /// <param name="options">Client options that may contain a full BaseApiUrl override.</param>
    /// <returns>A <see cref="Uri"/> representing the API base address.</returns>
    /// <exception cref="ArgumentException">Thrown if both BaseApiUrl and tenant are null or whitespace.</exception>
    protected static Uri BuildBaseUri(string tenant, TdxClientOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.BaseApiUrl))
            return new Uri(options.BaseApiUrl);

        ArgumentException.ThrowIfNullOrWhiteSpace(tenant, "Tenant is required if BaseApiUrl is not set.");
        string url = $"https://{tenant}.teamdynamix.com/TDWebApi/api/";
        return new Uri(url);
    }

    /// <summary>
    /// Creates a retry policy that handles HTTP 429 responses (rate limiting) with exponential backoff
    /// and optional throttle wait/continue callbacks.
    /// </summary>
    /// <param name="clientOptions">The client options controlling retry behavior.</param>
    /// <returns>An <see cref="AsyncRetryPolicy{HttpResponseMessage}"/> configured to handle throttling.</returns>
    protected static AsyncRetryPolicy<HttpResponseMessage> CreateRetryPolicy(TdxClientOptions clientOptions)
    {
        int retryCount = clientOptions.MaxRetries;

        return Policy<HttpResponseMessage>
            .HandleResult(resp => resp.StatusCode == HttpStatusCode.TooManyRequests)
            .WaitAndRetryAsync(
                retryCount: retryCount,
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
                onRetryAsync: async (outcome, timespan, retryAttempt, context) =>
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

    /// <summary>
    /// Sets the bearer token to use for authorization on subsequent requests.
    /// </summary>
    /// <param name="token">The bearer token string.</param>
    public void SetToken(string token) => Token = token;

    /// <summary>
    /// Adds the bearer token authorization header to the specified HTTP request if the token is set.
    /// </summary>
    /// <param name="request">The HTTP request message to add the authorization header to.</param>
    protected void AddAuthorization(HttpRequestMessage request)
    {
        if (!string.IsNullOrWhiteSpace(Token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Token);
    }

    /// <summary>
    /// Sends an HTTP request and returns the raw <see cref="HttpResponseMessage"/>.
    /// The request will be retried according to the retry policy if throttled.
    /// </summary>
    /// <param name="request">The HTTP request message to send.</param>
    /// <returns>The HTTP response message.</returns>
    public async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request)
    {
        return await SendWithPolicyAsync(request);
    }

    /// <summary>
    /// Sends an HTTP request, ensures success, and deserializes the JSON response content to the specified type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response content to.</typeparam>
    /// <param name="request">The HTTP request message to send.</param>
    /// <returns>The deserialized response object of type <typeparamref name="T"/>.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the response is unsuccessful, content is empty, or deserialization fails.</exception>
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

    /// <summary>
    /// Internal method that sends the HTTP request with retry logic for throttling responses.
    /// Extracts rate limit reset headers to inform wait duration.
    /// </summary>
    /// <param name="request">The HTTP request message to send.</param>
    /// <returns>The HTTP response message.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="request"/> is null.</exception>
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

