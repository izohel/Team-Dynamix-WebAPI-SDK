using TeamDynamix.Api.Locations.Models;

namespace TeamDynamix.Api.Locations;
/// <summary>
/// Provides operations to retrieve and update a specific location in the TeamDynamix API.
/// </summary>
public class LocationItemRequestBuilder : BaseRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LocationItemRequestBuilder"/> class.
    /// </summary>
    /// <param name="path">The full API path to the location resource.</param>
    /// <param name="client">The <see cref="TdxBaseClient"/> instance used to send HTTP requests.</param>
    public LocationItemRequestBuilder(string path, TdxBaseClient client)
        :base(path, client)
    {        
    }

    /// <summary>
    /// Retrieves detailed information about a specific location.
    /// Corresponds to:
    /// <c>GET https://{tenant}.teamdynamix.com/TDWebApi/api/locations/{id}</c>.
    /// </summary>
    /// <returns>A fully populated <see cref="Location"/> object.</returns>
    public async Task<Location> GetAsync()
    {
        HttpRequestMessage request = new(HttpMethod.Get, Path);
        request.Headers.Accept.Add(new("application/json"));
        return await SendAsync<Location>(request);
    }

    /// <summary>
    /// Updates an existing location with new values.
    /// Corresponds to:
    /// <c>PUT https://{tenant}.teamdynamix.com/TDWebApi/api/locations/{id}</c>.
    /// </summary>
    /// <param name="location">The updated <see cref="Location"/> object to send.</param>
    /// <returns>The updated <see cref="Location"/> returned by the API.</returns>
    public async Task<Location> UpdateAsync(Location location)
    {
        HttpRequestMessage request = CreateRequest(HttpMethod.Put, "", location);
        return await SendAsync<Location>(request);
    }
}
