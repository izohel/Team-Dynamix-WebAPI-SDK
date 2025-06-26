using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi;
public abstract class BaseRequestBuilder
{
    protected readonly TdxBaseClient Client;
    protected readonly string Path;

    protected BaseRequestBuilder(string path, TdxBaseClient client)
    {
        Path = path;
        Client = client;
    }

    protected HttpRequestMessage CreateRequest(HttpMethod method, string relativePath = "", object? body = null)
    {
        string fullPath = string.IsNullOrWhiteSpace(relativePath)
            ? Path
            : $"{Path.TrimEnd('/')}/{relativePath.TrimStart('/')}";

        HttpRequestMessage request = new(method, fullPath);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        if (body is not null)
        {
            string json = JsonConvert.SerializeObject(body);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        return request;
    }

    protected async Task<T> SendAsync<T>(HttpRequestMessage request)
        => await Client.SendRequestAsync<T>(request);

    protected async Task SendAsync(HttpRequestMessage request)
        => await Client.SendRequestAsync(request);
}