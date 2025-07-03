using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDynamix.Api.Accounts.Models;
using TeamDynamix.Api.Locations.Models;

namespace TeamDynamix.Api.Locations;
/// <summary>
/// Contains methods for working with locations.
/// </summary>
public class LocationsRequestBuilder : BaseRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LocationsRequestBuilder"/> class.
    /// </summary>
    /// <param name="client">The <see cref="TdxBaseClient"/> instance used to send HTTP requests.</param>
    public LocationsRequestBuilder(TdxBaseClient client)
        :base("locations", client){ }

    /// <summary>
    /// Retrieves a list of all active locations. 
    /// This does not return full location details.
    /// Corresponds to:
    /// <c>GET https://{tenant}.teamdynamix.com/TDWebApi/api/locations</c>.
    /// </summary>
    /// <returns>A list of <see cref="Location"/> objects with basic metadata.</returns>
    public async Task<List<Location>> GetAsync()
    {
        HttpRequestMessage request = new(HttpMethod.Get, Path);
        request.Headers.Accept.Add(new("application/json"));
        return await SendAsync<List<Location>>(request);
    }

    /// <summary>
    /// Gets a request builder for operations on a specific location.
    /// Corresponds to endpoints like:
    /// <c>GET/PUT https://{tenant}.teamdynamix.com/TDWebApi/api/locations/{id}</c>.
    /// </summary>
    /// <param name="locationId">The ID of the location.</param>
    public LocationItemRequestBuilder this[string locationId] 
        => new($"{Path}/{locationId}", Client);
}
