using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.Accounts;

public class AccountsRequestBuilder : BaseRequestBuilder
{
    public AccountsRequestBuilder(TdxBaseClient client)
    : base("accounts", client)
    {

    }
    public async Task<List<Account>> GetAsync()
    {
        HttpRequestMessage request = new(HttpMethod.Get, Path);
        request.Headers.Accept.Add(new("application/json"));
        return await Client.SendRequestAsync<List<Account>>(request);
    }
    public AccountItemRequestBuilder this[string accountId]
        => new("${Path}/{accountId}, Client");
}

