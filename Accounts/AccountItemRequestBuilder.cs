using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TeamDynamix.Api;
using TeamDynamix.Api.Accounts.Models;

namespace TeamDynamix.Api.Accounts;
/// <summary>
/// Provides operations to retrieve information about a specific account/department
/// in the TeamDynamix system.
/// </summary>
public class AccountItemRequestBuilder : BaseRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountItemRequestBuilder"/> class.
    /// </summary>
    /// <param name="path">The path segment for the specific account resource.</param>
    /// <param name="client">The TdxBaseClient used to send HTTP requests.</param>
    public AccountItemRequestBuilder(string path, TdxBaseClient client)
        : base($"{path}", client)
    {
    }

    /// <summary>
    /// Retrieves detailed information for a specific <see cref="Account"/>.
    /// </summary>
    /// <returns>An <see cref="Account"/> object with full details.</returns>
    public async Task<Account> GetAsync()
    {
        HttpRequestMessage request = new(HttpMethod.Get, Path);
        return await Client.SendRequestAsync<Account>(request);
    }
    /// <summary>
    /// Updates the specified account with the provided field values.
    /// <para>
    /// Important: Any properties not set in the <paramref name="account"/> object
    /// will be treated as <c>null</c> by the TeamDynamix API and will overwrite existing data.
    /// This is due to how the TDX API handles this update operation.
    /// </para>
    /// Corresponds to the endpoint:
    /// <c>PUT https://{{tenant}}.teamdynamix.com/TDWebApi/api/accounts/{id}</c>.
    /// </summary>
    /// <param name="account">The account object containing the updated values. 
    /// Fields you want to retain should be mocked from the original object.
    /// </param>
    /// <returns>A task representing the asynchronous operation, containing the updated account.</returns>
    public async Task<Account> UpdateAsync(Account account)
    {
        ArgumentNullException.ThrowIfNull(account);
        HttpRequestMessage request = CreateRequest(HttpMethod.Put, "", account);
        return await Client.SendRequestAsync<Account>(request);
    }
}