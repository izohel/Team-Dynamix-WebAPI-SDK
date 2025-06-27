using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi;
/// <summary>
/// Abstract base class for building and sending HTTP requests to the TeamDynamix API.
/// Provides helper methods to create requests with optional JSON bodies and send them
/// using a <see cref="TdxBaseClient"/> instance.
/// </summary>
public abstract class BaseRequestBuilder
{
    /// <summary>
    /// The <see cref="TdxBaseClient"/> instance used to send HTTP requests.
    /// </summary>
    protected readonly TdxBaseClient Client;

    /// <summary>
    /// The base path (relative URI) for the API endpoint this request builder targets.
    /// </summary>
    protected readonly string Path;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseRequestBuilder"/> class
    /// with the specified base path and client.
    /// </summary>
    /// <param name="path">The base API path for the resource (relative URI).</param>
    /// <param name="client">The <see cref="TdxBaseClient"/> to use for sending requests.</param>
    protected BaseRequestBuilder(string path, TdxBaseClient client)
    {
        Path = path;
        Client = client;
    }

    /// <summary>
    /// Creates an <see cref="HttpRequestMessage"/> with the specified HTTP method, optional relative path,
    /// and optional request body serialized as JSON.
    /// </summary>
    /// <param name="method">The HTTP method to use (GET, POST, etc.).</param>
    /// <param name="relativePath">
    /// An optional relative path to append to the base <see cref="Path"/>.
    /// If null or empty, the base <see cref="Path"/> is used as-is.
    /// </param>
    /// <param name="body">
    /// An optional object to serialize as JSON in the request body.
    /// If null, no body content is added.
    /// </param>
    /// <returns>A configured <see cref="HttpRequestMessage"/> instance.</returns>
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

    /// <summary>
    /// Sends an HTTP request asynchronously and deserializes the JSON response content
    /// into an instance of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The expected type of the deserialized response.</typeparam>
    /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
    /// <returns>A task representing the asynchronous operation, with the deserialized response object as result.</returns>
    protected async Task<T> SendAsync<T>(HttpRequestMessage request)
        => await Client.SendRequestAsync<T>(request);

    /// <summary>
    /// Sends an HTTP request asynchronously without expecting a response body.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> to send.</param>
    /// <returns>A task representing the asynchronous send operation.</returns>
    protected async Task SendAsync(HttpRequestMessage request)
        => await Client.SendRequestAsync(request);
}
