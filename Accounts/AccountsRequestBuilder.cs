using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDynamix.Api.Accounts.Models;

namespace TeamDynamix.Api.Accounts;
/// <summary>
/// Contains methods for working with accounts/departments in the TeamDynamix API.
/// </summary>
public class AccountsRequestBuilder : BaseRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountsRequestBuilder"/> class
    /// with the specified client. The base path is set to "accounts".
    /// </summary>
    /// <param name="client">The <see cref="TdxBaseClient"/> used to send requests.</param>
    public AccountsRequestBuilder(TdxBaseClient client)
        : base("accounts", client)
    {
    }

    /// <summary>
    /// Retrieves a list of all active accounts/departments.
    /// This method calls the endpoint:
    /// <c>GET https://{{tenant}}.teamdynamix.com/TDWebApi/api/accounts</c>.
    /// Note that this does not return full account or department details.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.
    /// The task result contains a list of <see cref="Account"/> objects.</returns>
    public async Task<List<Account>> GetAsync()
    {
        HttpRequestMessage request = new(HttpMethod.Get, Path);
        request.Headers.Accept.Add(new("application/json"));
        return await Client.SendRequestAsync<List<Account>>(request);
    }

    /// <summary>
    /// Gets a request builder for a specific account by its identifier.
    /// This allows further operations scoped to a single account.
    /// Corresponds to the endpoint:
    /// <c>GET https://{{tenant}}.teamdynamix.com/TDWebApi/api/accounts/{id}</c>.
    /// </summary>
    /// <param name="accountId">The ID of the account.</param>
    public AccountItemRequestBuilder this[string accountId]
        => new($"{Path}/{accountId}", Client);
}


