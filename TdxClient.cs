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
    /// <summary>
    /// Use this constructor to supply your own <see cref="HttpClient"/> instance,
    /// such as one configured with logging, handlers, or a shared retry policy.
    /// If <c>BaseAddress</c> is not set, it will be inferred from the tenant and options.
    /// </summary>
    public TdxClient(HttpClient httpClient, string tenant, string webServicesBeId, string webServicesKey, TdxClientOptions? options = null)
    : base(httpClient, tenant, options ?? new TdxClientOptions())
    {
        ArgumentException.ThrowIfNullOrEmpty(webServicesBeId, nameof(webServicesBeId));
        ArgumentException.ThrowIfNullOrEmpty(webServicesKey, nameof(webServicesKey));
        _webServicesBeId = webServicesBeId;
        _webServicesKey = webServicesKey;
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