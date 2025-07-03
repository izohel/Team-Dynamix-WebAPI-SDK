using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDynamix.Api.Assets.Models;

namespace TeamDynamix.Api.Assets;
public class AssetsRequestBuilder : BaseRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AssetsRequestBuilder"/> class.
    /// </summary>
    /// <param name="client">The TDX base client used to send HTTP requests.</param>
    /// <param name="appId">The ID of the asset application.</param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="appId"/> is null or empty.</exception>
    public AssetsRequestBuilder(TdxBaseClient client, string appId)
        : base($"{appId}/assets", client)
    {
        ArgumentException.ThrowIfNullOrEmpty(appId);
        AppId = appId;
    }
    /// <summary>
    /// Gets the ID of the asset application associated with this request builder.
    /// </summary>
    public string AppId { get; }
    public async Task<Asset> PostAsync(Asset asset)
    {
        HttpRequestMessage request = CreateRequest( HttpMethod.Post,"", asset);
        return await SendAsync<Asset>(request);

    }
    /// <summary>
    /// Provides operations for a specific asset by its ID.
    /// </summary>
    /// <param name="assetId">The ID of the asset to manage.</param>
    /// <returns>An <see cref="AssetItemRequestBuilder"/> for the specified asset.</returns>
    public AssetItemRequestBuilder this[string assetId]
        => new($"{Path}/{assetId}", Client);
    public AssetSearchBuilder Search(Action<AssetSearchOptions> searchOptions)
        => new($"{Path}/search", searchOptions, Client);
}
