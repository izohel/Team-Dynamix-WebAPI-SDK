using Itsm.Tdx.WebApi.People.Models;

namespace Itsm.Tdx.WebApi.People;

public class PersonByIdRequestBuilder : BaseRequestBuilder
{

    public PersonByIdRequestBuilder(string path ,TdxBaseClient client)
        : base(path, client)
    {
    }
    public async Task<User> GetAsync()
    {
        HttpRequestMessage request = CreateRequest(HttpMethod.Get);
        return await SendAsync<User>(request);
    }
}