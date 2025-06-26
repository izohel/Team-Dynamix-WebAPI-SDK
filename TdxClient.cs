using Polly;
using Polly.Retry;
using Itsm.Tdx.WebApi.Extensions;
using Newtonsoft.Json;
using Itsm.Tdx.WebApi.People;
using Itsm.Tdx.WebApi.Tickets;

namespace Itsm.Tdx.WebApi;

public class TdxClient : TdxBaseClient
{
    private readonly string _webServicesBeId;
    private readonly string _webServicesKey;
    public PeopleRequestBuilder Users => new(this);

    // Fluent entry point: client.Tickets("244")["ticketId]
    public TicketsRequestBuilder Tickets(string appId) => new(this, appId);
    /// <summary>
    /// Constructor with default retry policy and no throttling callbacks.
    /// </summary>
    public TdxClient(string tenant, string webServicesBeId, string webServicesKey)
   : this(tenant, webServicesBeId, webServicesKey, new TdxClientOptions())
    {
        ArgumentException.ThrowIfNullOrEmpty(webServicesBeId, nameof(webServicesBeId));
        ArgumentException.ThrowIfNullOrEmpty(webServicesKey, nameof(webServicesKey));
        _webServicesBeId = webServicesBeId;
        _webServicesKey = webServicesKey;
    }
    /// <summary>
    /// Constructor that takes full configuration via TdxClientOptions.
    /// </summary>
    public TdxClient(string tenant, string webServicesBeId, string webServicesKey, TdxClientOptions options)
        : base(new HttpClient { BaseAddress = BuildBaseUri(tenant, options) }, options: options)
    {
        ArgumentException.ThrowIfNullOrEmpty(webServicesBeId, nameof(webServicesBeId));
        ArgumentException.ThrowIfNullOrEmpty(webServicesKey, nameof(webServicesKey));
        _webServicesBeId = webServicesBeId;
        _webServicesKey = webServicesKey;
    }
    private static Uri BuildBaseUri(string tenant, TdxClientOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.BaseApiUrl))
            return new Uri(options.BaseApiUrl);

        ArgumentException.ThrowIfNullOrWhiteSpace(tenant, "Tenant is required if BaseApiUrl is not set.");
        string url = $"https://{tenant}.teamdynamix.com/TDWebApi/api/";
        return new Uri(url);
    }
    public async Task AuthenticateAsync()
    {
        var loginPayload = new
        {
            BEID = _webServicesBeId,
            WebServicesKey = _webServicesKey
        };
        HttpRequestMessage request = new(HttpMethod.Post, "auth/loginadmin/")
        {
            Content = new StringContent(JsonConvert.SerializeObject(loginPayload), System.Text.Encoding.UTF8, "application/json")
        };
        HttpResponseMessage response = await SendRequestAsync(request);
        string token = await response.Content.ReadAsStringAsync();
        ArgumentException.ThrowIfNullOrEmpty("Token could not be retrieved.", token);
        SetToken(token.Trim());
    }
}