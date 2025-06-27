using Polly;
using Polly.Retry;
using Itsm.Tdx.WebApi.Extensions;
using Newtonsoft.Json;
using Itsm.Tdx.WebApi.People;
using Itsm.Tdx.WebApi.Tickets;
using Itsm.Tdx.WebApi.Accounts;

namespace Itsm.Tdx.WebApi;

/// <summary>
/// Client for interacting with the TeamDynamix API, extending <see cref="TdxBaseClient"/>.
/// Provides strongly typed request builders for People, Tickets, and Accounts endpoints,
/// and handles authentication using provided credentials.
/// </summary>
/// <remarks>
/// Currently only supports admin login.<br></br>
/// This client abstracts API interaction details, managing authentication tokens,
/// HTTP client configuration, and exposes high-level endpoint request builders.
/// It supports multiple constructors for flexible configuration, including
/// default options, fully custom options, or supplying a preconfigured <see cref="HttpClient"/> instance.
/// </remarks>
public class TdxClient : TdxBaseClient
{
    private readonly string _webServicesBeId;
    private readonly string _webServicesKey;

    /// <summary>
    /// Provides access to People-related API requests.
    /// </summary>
    public PeopleRequestBuilder People => new(this);

    /// <summary>
    /// Provides access to Tickets-related API requests for a specified application ID.
    /// </summary>
    /// <param name="appId">The application ID used to scope ticket requests.</param>
    /// <returns>A <see cref="TicketsRequestBuilder"/> instance for the specified appId.</returns>
    public TicketsRequestBuilder Tickets(string appId) => new(this, appId);

    /// <summary>
    /// Provides access to Accounts-related API requests.
    /// </summary>
    public AccountsRequestBuilder Accounts => new(this);

    /// <summary>
    /// Initializes a new instance of <see cref="TdxClient"/> with default retry policy and no throttling callbacks.
    /// </summary>
    /// <param name="tenant">The tenant name or base URL for API access.</param>
    /// <param name="webServicesBeId">The BEID credential for authentication.</param>
    /// <param name="webServicesKey">The Web Services key credential for authentication.</param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="webServicesBeId"/> or <paramref name="webServicesKey"/> is null or empty.</exception>
    public TdxClient(string tenant, string webServicesBeId, string webServicesKey)
       : this(tenant, webServicesBeId, webServicesKey, new TdxClientOptions())
    {
        ArgumentException.ThrowIfNullOrEmpty(webServicesBeId, nameof(webServicesBeId));
        ArgumentException.ThrowIfNullOrEmpty(webServicesKey, nameof(webServicesKey));
        _webServicesBeId = webServicesBeId;
        _webServicesKey = webServicesKey;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="TdxClient"/> with full configuration options.
    /// </summary>
    /// <param name="tenant">The tenant name or base URL for API access.</param>
    /// <param name="webServicesBeId">The BEID credential for authentication.</param>
    /// <param name="webServicesKey">The Web Services key credential for authentication.</param>
    /// <param name="options">Optional configuration settings for the client, such as retry policies.</param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="webServicesBeId"/> or <paramref name="webServicesKey"/> is null or empty.</exception>
    public TdxClient(string tenant, string webServicesBeId, string webServicesKey, TdxClientOptions options)
        : base(new HttpClient { BaseAddress = BuildBaseUri(tenant, options) }, options: options)
    {
        ArgumentException.ThrowIfNullOrEmpty(webServicesBeId, nameof(webServicesBeId));
        ArgumentException.ThrowIfNullOrEmpty(webServicesKey, nameof(webServicesKey));
        _webServicesBeId = webServicesBeId;
        _webServicesKey = webServicesKey;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="TdxClient"/> using a supplied <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="httpClient">A preconfigured <see cref="HttpClient"/> instance to use for requests.</param>
    /// <param name="tenant">The tenant name or base URL for API access.</param>
    /// <param name="webServicesBeId">The BEID credential for authentication.</param>
    /// <param name="webServicesKey">The Web Services key credential for authentication.</param>
    /// <param name="options">Optional configuration settings for the client.</param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="webServicesBeId"/> or <paramref name="webServicesKey"/> is null or empty.</exception>
    /// <remarks>
    /// Use this constructor to supply your own <see cref="HttpClient"/> instance, for example, one configured with custom
    /// message handlers, logging, or retry policies. If <see cref="HttpClient.BaseAddress"/> is not set,
    /// it will be inferred from the tenant and options.
    /// </remarks>
    public TdxClient(HttpClient httpClient, string tenant, string webServicesBeId, string webServicesKey, TdxClientOptions? options = null)
        : base(httpClient, tenant, options ?? new TdxClientOptions())
    {
        ArgumentException.ThrowIfNullOrEmpty(webServicesBeId, nameof(webServicesBeId));
        ArgumentException.ThrowIfNullOrEmpty(webServicesKey, nameof(webServicesKey));
        _webServicesBeId = webServicesBeId;
        _webServicesKey = webServicesKey;
    }

    /// <summary>
    /// Authenticates the client by sending the BEID and WebServicesKey to the authentication endpoint
    /// and storing the returned token for subsequent API requests.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentException">Thrown if the authentication token cannot be retrieved or is empty.</exception>
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
