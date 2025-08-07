using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDynamix.Api.People.Models;

namespace TeamDynamix.Api.Auth;

public class AuthRequestBuilder : BaseRequestBuilder
{
    /// <summary>
    /// Provides authentication-related actions such as admin login, SSO login,
    /// and current user retrieval for the TeamDynamix API.
    /// </summary>
    public AuthRequestBuilder(TdxBaseClient client)
        : base("auth", client) { }

    /// <summary>
    /// Authenticates the client by sending the BEID and WebServicesKey to the authentication endpoint
    /// and storing the returned token for subsequent API requests.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentException">Thrown if the authentication token cannot be retrieved or is empty.</exception>
    public async Task AuthenticateAdminAsync(string beid, string webServicesKey)
    {
        HttpRequestMessage request = CreateRequest(HttpMethod.Post, "loginadmin",
            new
            {
                BEID = beid,
                WebServicesKey = webServicesKey
            });
        string token = await ExtractTokenAsync(request);
        Client.SetToken(token);
    }

    ///// <summary>
    ///// Logs in the current session using single sign-on (SSO).
    ///// </summary>
    ///// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    ///// <exception cref="ArgumentException">Thrown if the authentication token cannot be retrieved or is empty.</exception>
    //public async Task AuthenticateSsoAsync()
    //{
    //    var request = CreateRequest(HttpMethod.Post, "loginsso");
    //    string token = await ExtractTokenAsync(request);
    //    Client.SetToken(token);
    //}
    /// <summary>
    /// Logs in the current session with the specified parameters.
    /// </summary>
    /// <remarks>
    /// Expects that you are not using your SSO creds, this would have been set up a TDX admin
    /// </remarks>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task AuthenticateUserAsync(string username, string password)
    {
        var request = CreateRequest(HttpMethod.Post, "login", new { Username = username, Password = password });
        string token = await ExtractTokenAsync(request);
        Client.SetToken(token);
    }
    /// <summary>
    /// Gets the current user.
    /// </summary>
    /// <returns cref="User">The <see cref="User">user </see>instance of the current logged in user.</returns>
    public async Task<User> GetCurrentUserAsync()
    {
        var request = CreateRequest(HttpMethod.Get, "getuser");
        return await SendAsync<User>(request);
    }

    private async Task<string> ExtractTokenAsync(HttpRequestMessage request)
    {
        HttpResponseMessage response = await Client.SendRequestAsync(request);
        string token = await response.Content.ReadAsStringAsync();
        ArgumentException.ThrowIfNullOrEmpty("Token could not be retrieved.", token);
        return token.Trim();
    }
}
