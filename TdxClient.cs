using Polly;
using Polly.Retry;
using Newtonsoft.Json;
using TeamDynamix.Api.Accounts;
using TeamDynamix.Api.People;
using TeamDynamix.Api.Tickets;
using TeamDynamix.Api.Extensions;
using TeamDynamix.Api.Locations;
using TeamDynamix.Api.Assets;
using TeamDynamix.Api.Auth;

namespace TeamDynamix.Api;

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
    /// <summary>
    /// Provides authentication-related actions such as admin login, SSO login,
    /// and current user retrieval for the TeamDynamix API.
    /// </summary>
    public AuthRequestBuilder Auth => new(this);
    /// <summary>
    /// Provides methods for working with assets.To the specified App
    /// </summary>
    /// <param name="appId">The application ID used to scope asset requests.</param>
    /// <returns>A <see cref="AssetsRequestBuilder"/> instance for the app</returns>
    public AssetsRequestBuilder Assets(string appId) => new(this, appId); 
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
    /// Contains methods for working with locations.
    /// </summary>
    public LocationsRequestBuilder Locations => new(this);
    /// <summary>
    /// Provides access to Accounts-related API requests.
    /// </summary>
    public AccountsRequestBuilder Accounts => new(this);

    /// <summary>
    /// Initializes a new instance of <see cref="TdxClient"/> with default retry policy and no throttling callbacks.
    /// </summary>
    /// <param name="tenant">The tenant name or base URL for API access.</param>
    public TdxClient(string tenant)
       : this(tenant, new TdxClientOptions())
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="TdxClient"/> with full configuration options.
    /// </summary>
    /// <param name="tenant">The tenant name or base URL for API access.</param>
    /// <param name="options">Optional configuration settings for the client, such as retry policies.</param>
    public TdxClient(string tenant, TdxClientOptions options)
        : base(new HttpClient { BaseAddress = BuildBaseUri(tenant, options) }, options: options)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="TdxClient"/> using a supplied <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="httpClient">A preconfigured <see cref="HttpClient"/> instance to use for requests.</param>
    /// <param name="tenant">The tenant name or base URL for API access.</param>
    /// <param name="options">Optional configuration settings for the client.</param>
    /// <remarks>
    /// Use this constructor to supply your own <see cref="HttpClient"/> instance, for example, one configured with custom
    /// message handlers, logging, or retry policies. If <see cref="HttpClient.BaseAddress"/> is not set,
    /// it will be inferred from the tenant and options.
    /// </remarks>
    public TdxClient(HttpClient httpClient, string tenant,TdxClientOptions? options = null)
        : base(httpClient, tenant, options ?? new TdxClientOptions())
    {
    }

    //public async Task AuthenticateAsync()
    //{
    //    var loginPayload = new
    //    {
    //        BEID = _webServicesBeId,
    //        WebServicesKey = _webServicesKey
    //    };

    //    HttpRequestMessage request = new(HttpMethod.Post, "auth/loginadmin/")
    //    {
    //        Content = new StringContent(JsonConvert.SerializeObject(loginPayload), System.Text.Encoding.UTF8, "application/json")
    //    };

    //    HttpResponseMessage response = await SendRequestAsync(request);

    //    string token = await response.Content.ReadAsStringAsync();

    //    ArgumentException.ThrowIfNullOrEmpty("Token could not be retrieved.", token);

    //    SetToken(token.Trim());
    //}

    //public async Task AuthenticateSsoAsync()
    //{
    //    HttpRequestMessage request = new(HttpMethod.Post, "auth/loginadmin/auth/loginsso");

    //    HttpResponseMessage response = await SendRequestAsync(request);

    //    string token = await response.Content.ReadAsStringAsync();

    //    ArgumentException.ThrowIfNullOrEmpty("Token could not be retrieved.", token);

    //    SetToken(token.Trim());
    //}
}
