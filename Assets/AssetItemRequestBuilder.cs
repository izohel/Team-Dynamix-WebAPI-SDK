using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDynamix.Api.Assets.Models;
using TeamDynamix.Api.Tickets.Models;

namespace TeamDynamix.Api.Assets;
/// <summary>
/// Provides operation for a single asset.
/// </summary>
public class AssetItemRequestBuilder : BaseRequestBuilder
{
    /// <summary>
    ///  Initializes a new instance of the <see cref="AssetItemRequestBuilder"/> class.
    /// </summary>
    /// <param name="path">Path to the specfic asset.</param>
    /// <param name="client">The client used to send requests.</param>
    public AssetItemRequestBuilder(string path, TdxBaseClient client):
        base(path, client)
    {
        
    }
    public async Task<Asset> GetAsync()
    {
        HttpRequestMessage request = new(HttpMethod.Get, Path);
        return await Client.SendRequestAsync<Asset>(request);
    }
}
