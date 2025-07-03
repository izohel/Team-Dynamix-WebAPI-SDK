using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using TeamDynamix.Api.Exceptions;
using TeamDynamix.Api.People.Models;

namespace TeamDynamix.Api.People;

/// <summary>
/// Provides functionality to search for people in the TeamDynamix people database
/// based on various search criteria.
/// </summary>
public class PersonSearchRequestBuilder : BaseRequestBuilder
{
    private readonly Dictionary<string, object> _searchCriteria = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="PersonSearchRequestBuilder"/> class.
    /// </summary>
    /// <param name="path">The relative API path for the search endpoint.</param>
    /// <param name="client">The TDX API client used to send the request.</param>
    public PersonSearchRequestBuilder(string path, TdxBaseClient client)
        : base(path, client)
    {
    }

    /// <summary>
    /// Adds the external ID to the search criteria.
    /// </summary>
    /// <param name="externalId">The external ID of the person.</param>
    /// <returns>The current <see cref="PersonSearchRequestBuilder"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="externalId"/> is null or empty.</exception>
    public PersonSearchRequestBuilder WithExternalId(string externalId)=> Add("ExternalId",externalId);

    /// <summary>
    /// Adds the username to the search criteria.
    /// </summary>
    /// <param name="username">The username of the person.</param>
    /// <returns>The current <see cref="PersonSearchRequestBuilder"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="username"/> is null or empty.</exception>    
    public PersonSearchRequestBuilder WithUsername(string username) => Add("Username", username);

    /// <summary>
    /// Adds the first name to the search criteria.
    /// </summary>
    /// <param name="firstName">The first name of the person.</param>
    /// <returns>The current <see cref="PersonSearchRequestBuilder"/> instance.</returns>
    public PersonSearchRequestBuilder WithFirstName(string firstName) => Add("FirstName", firstName);

    /// <summary>
    /// Adds the last name to the search criteria.
    /// </summary>
    /// <param name="lastName">The last name of the person.</param>
    /// <returns>The current <see cref="PersonSearchRequestBuilder"/> instance.</returns>
    public PersonSearchRequestBuilder WithLastName(string lastName) => Add("LastName", lastName);

    /// <summary>
    /// Adds the email to the search criteria.
    /// </summary>
    /// <param name="email">The email address of the person.</param>
    /// <returns>The current <see cref="PersonSearchRequestBuilder"/> instance.</returns>
    public PersonSearchRequestBuilder WithEmail(string email) => Add("Email", email);

    /// <summary>
    /// Adds a custom search criterion to the search criteria.
    /// </summary>
    /// <param name="key">The key of the search criterion.</param>
    /// <param name="value">The value of the search criterion.</param>
    /// <returns>The current <see cref="PersonSearchRequestBuilder"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="key"/> or <paramref name="value"/> is null or empty.</exception>
    public PersonSearchRequestBuilder With(string key, string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(key, nameof(key));
        ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));
        _searchCriteria[key] = value;
        return this;
    }

    /// <summary>
    /// Executes the search with the provided criteria and returns a list of matching users.
    /// </summary>
    /// <returns>A list of <see cref="User"/> objects that match the search criteria.</returns>
    /// <exception cref="InvalidOperationException">Thrown when no search criteria have been provided.</exception>
    /// <exception cref="UserException">Thrown when no matching users are found.</exception>
    public async Task<List<User>> GetAsync()
    {
        if (_searchCriteria.Count == 0)
            throw new InvalidOperationException("No search criteria provided for person search.");

        HttpRequestMessage request = new(HttpMethod.Post, "people/search");

        string jsonBody = JsonConvert.SerializeObject(_searchCriteria);
        request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        return await Client.SendRequestAsync<List<User>>(request) 
            ?? throw new UserException("No matching users found.");
    }
    private PersonSearchRequestBuilder Add(string key, string? value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value, nameof(value));
        _searchCriteria[key] = value!;
        return this;
    }
}
