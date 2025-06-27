namespace Itsm.Tdx.WebApi;
/// <summary>
/// Factory for creating <see cref="HttpClient"/> instances with advanced control over the message handler pipeline.
/// </summary>
/// <remarks>
/// This factory allows consumers to compose a customized <see cref="HttpClient"/> by chaining any number of
/// <see cref="DelegatingHandler"/> instances such as logging, authentication, retry policies, or telemetry.
/// 
/// By providing a collection of handlers, the factory builds a pipeline that executes handlers in the specified order,
/// enabling flexible, reusable, and testable HTTP communication tailored to specific needs.
/// 
/// Use this factory when the default <see cref="HttpClient"/> behavior is insufficient or when custom
/// cross-cutting concerns need to be injected into the HTTP request/response pipeline.
/// </remarks>
public static class TdxClientFactory
{
    /// <summary>
    /// Creates a new <see cref="HttpClient"/> instance configured with a pipeline of <see cref="DelegatingHandler"/> instances.
    /// </summary>
    /// <param name="handlers">A collection of <see cref="DelegatingHandler"/> instances to be chained together
    /// in the order provided. These handlers can implement cross-cutting concerns like logging, retry, or authentication.</param>
    /// <param name="tenantOrUrl">The base URI for the <see cref="HttpClient"/>. This can be a full URI string,
    /// or a tenant identifier which will be used to construct a standard TeamDynamix API URL.</param>
    /// <param name="rootHandler">An optional root <see cref="HttpMessageHandler"/> to terminate the pipeline.
    /// If null, the default <see cref="HttpClientHandler"/> is used.</param>
    /// <returns>A new <see cref="HttpClient"/> instance with the specified handler pipeline and base address.</returns>
    public static HttpClient CreateHttpClient(
         IEnumerable<DelegatingHandler> handlers,
         string tenantOrUrl,
         HttpMessageHandler? rootHandler = null) // Allow user to specify base handler
    {
        HttpMessageHandler pipeline = CreatePipeline(handlers, rootHandler ?? new HttpClientHandler());

        HttpClient httpClient = new(pipeline)
        {
            BaseAddress = BuildBaseUri(tenantOrUrl)
        };

        return httpClient;
    }

    /// <summary>
    /// Constructs a chained <see cref="HttpMessageHandler"/> pipeline from a collection of <see cref="DelegatingHandler"/> instances,
    /// terminating with the provided root handler.
    /// </summary>
    /// <param name="handlers">The <see cref="DelegatingHandler"/> instances to chain.</param>
    /// <param name="rootHandler">The terminal <see cref="HttpMessageHandler"/> in the pipeline.</param>
    /// <returns>The first <see cref="HttpMessageHandler"/> in the chained pipeline.</returns>
    private static HttpMessageHandler CreatePipeline(IEnumerable<DelegatingHandler> handlers, HttpMessageHandler rootHandler)
    {
        HttpMessageHandler current = rootHandler;

        // Handlers are chained in reverse order to ensure the first handler executes first in the pipeline.
        foreach (DelegatingHandler handler in handlers.Reverse())
        {
            handler.InnerHandler = current;
            current = handler;
        }

        return current;
    }

    /// <summary>
    /// Builds the base <see cref="Uri"/> for the HttpClient from a tenant name or an absolute URL.
    /// </summary>
    /// <param name="tenantOrUrl">Either a full absolute URI or a TeamDynamix tenant name.</param>
    /// <returns>A valid absolute <see cref="Uri"/> representing the base address.</returns>
    private static Uri BuildBaseUri(string tenantOrUrl)
    {
        return Uri.TryCreate(tenantOrUrl, UriKind.Absolute, out Uri? absolute)
            ? absolute
            : new Uri($"https://{tenantOrUrl}.teamdynamix.com/TDWebApi/api/");
    }
}
