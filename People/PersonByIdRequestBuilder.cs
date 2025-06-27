using Itsm.Tdx.WebApi.People.Models;

namespace Itsm.Tdx.WebApi.People;

/// <summary>
/// Provides functionality to retrieve a person by their unique identifier (UID)
/// from the TeamDynamix people database.
/// </summary>
public class PersonByIdRequestBuilder : BaseRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PersonByIdRequestBuilder"/> class.
    /// </summary>
    /// <param name="path">The relative API path to the specific person.</param>
    /// <param name="client">The TDX API client used to send the request.</param>
    public PersonByIdRequestBuilder(string path, TdxBaseClient client)
        : base(path, client)
    {
    }

    /// <summary>
    /// Sends a GET request to retrieve the person identified by the specified UID.
    /// </summary>
    /// <returns>A <see cref="User"/> object representing the person.</returns>
    public async Task<User> GetAsync()
    {
        HttpRequestMessage request = CreateRequest(HttpMethod.Get);
        return await SendAsync<User>(request);
    }
}
