using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDynamix.Api.Assets.Models;
using TeamDynamix.Api.Attachments.Models;

namespace TeamDynamix.Api.Assets;
public class AssetSearchBuilder : BaseRequestBuilder
{
    private AssetSearchOptions _options = new();
    /// <summary>
    /// Searches assets. Will not return full asset information.
    /// <remarks>
    /// The following properties will not be included in the results:<br/><see cref="Asset.Attachments"/><br/><see cref="Asset.Attributes"/><br/>To retrieve such information, you must load an asset individually.
    /// </remarks>
    /// </summary>
    /// <returns><see cref="AssetSearchBuilder"/></returns>
    public AssetSearchBuilder(string path, Action<AssetSearchOptions> searchOptions, TdxBaseClient client )
        : base(path, client)
    {

         searchOptions(_options);
    }

    public async Task<List<Asset>> GetAsync()
    {
        HttpRequestMessage request = CreateRequest(HttpMethod.Post, "", _options);
        return await SendAsync<List<Asset>>(request);
    }
}
