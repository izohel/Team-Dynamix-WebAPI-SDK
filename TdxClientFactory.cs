using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi;
public static class TdxClientFactory
{
    public static IList<DelegatingHandler> CreateDefaultHandlers()
    {
        return new List<DelegatingHandler>
        {
            
            // You can add more defaults here
        };
    }

    public static HttpClient CreateHttpClient(IEnumerable<DelegatingHandler> handlers, string tenantOrUrl)
    {
        HttpMessageHandler pipeline = CreatePipeline(handlers);

        HttpClient httpClient = new(pipeline)
        {
            BaseAddress = BuildBaseUri(tenantOrUrl)
        };

        return httpClient;
    }

    private static HttpMessageHandler CreatePipeline(IEnumerable<DelegatingHandler> handlers)
    {
        HttpMessageHandler current = new HttpClientHandler();

        foreach (DelegatingHandler? handler in handlers.Reverse())
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
