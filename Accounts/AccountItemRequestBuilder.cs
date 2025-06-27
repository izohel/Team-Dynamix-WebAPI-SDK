using Itsm.Tdx.WebApi.Accounts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.Accounts;
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
        : base($"path", client)
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
}