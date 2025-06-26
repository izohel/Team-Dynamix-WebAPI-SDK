namespace Itsm.Tdx.WebApi;
/// <summary>
/// Factory for creating <see cref="HttpClient"/> instances with advanced control over message handlers.
/// Consumers can:
/// - Create any number of custom <see cref="DelegatingHandler"/> instances (e.g., logging, authentication, retry, telemetry).
/// - Pass them as a collection to the factory method.
/// The factory chains these handlers together and builds an <see cref="HttpClient"/> instance that
/// executes all handlers in the specified order.
/// </summary>
/// <remarks>
/// Use this factory when you need to customize the <see cref="HttpClient"/> pipeline, such as adding
/// custom logging, authentication, or retry policies. This enables flexible, reusable,
/// and testable HTTP communication.
/// </remarks>
public static class TdxClientFactory
{
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

    private static HttpMessageHandler CreatePipeline(IEnumerable<DelegatingHandler> handlers, HttpMessageHandler rootHandler)
    {
        HttpMessageHandler current = rootHandler;

        foreach (DelegatingHandler handler in handlers.Reverse())
        {
            handler.InnerHandler = current;
            current = handler;
        }

        return current;
    }

    private static Uri BuildBaseUri(string tenantOrUrl)
    {
        return Uri.TryCreate(tenantOrUrl, UriKind.Absolute, out Uri? absolute)
            ? absolute
            : new Uri($"https://{tenantOrUrl}.teamdynamix.com/TDWebApi/api/");
    }
}
