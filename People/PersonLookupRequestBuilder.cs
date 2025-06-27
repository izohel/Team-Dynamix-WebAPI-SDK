namespace Itsm.Tdx.WebApi.People;
/// <summary>
/// 
/// </summary>
public class PersonLookupRequestBuilder : BaseRequestBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="client"></param>
    /// <param name="path"></param>
    public PersonLookupRequestBuilder(TdxBaseClient client, string path)
        : base(path, client)
    {
        
    }
}