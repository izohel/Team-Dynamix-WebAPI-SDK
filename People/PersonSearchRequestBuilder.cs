using Itsm.Tdx.WebApi.Exceptions;
using Itsm.Tdx.WebApi.People.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Itsm.Tdx.WebApi.People;

public class PersonSearchRequestBuilder : BaseRequestBuilder
{
    private readonly Dictionary<string, object> _searchCriteria = new();
    public PersonSearchRequestBuilder(string path, TdxBaseClient client)
        : base(path, client)
    {
        
    }
    public PersonSearchRequestBuilder WithExternalId(string externalId)
    {
        ArgumentException.ThrowIfNullOrEmpty(externalId);
        _searchCriteria["ExternalId"] = externalId;
        return this;
    }
    public PersonSearchRequestBuilder WithUsername(string username)
    {
        ArgumentException.ThrowIfNullOrEmpty(username);
        _searchCriteria["Username"] = username;
        return this;
    }

    public PersonSearchRequestBuilder WithFirstName(string firstName)
    {
        if (!string.IsNullOrWhiteSpace(firstName))
            _searchCriteria["FirstName"] = firstName;
        return this;
    }

    public PersonSearchRequestBuilder WithLastName(string lastName)
    {
        if (!string.IsNullOrWhiteSpace(lastName))
            _searchCriteria["LastName"] = lastName;
        return this;
    }

    public PersonSearchRequestBuilder WithEmail(string email)
    {
        if (!string.IsNullOrWhiteSpace(email))
            _searchCriteria["Email"] = email;
        return this;
    }

    public async Task<List<User>> GetAsync()
    {
        if (_searchCriteria.Count == 0)
            throw new InvalidOperationException("No search criteria provided for person search.");

        HttpRequestMessage request = new(HttpMethod.Post, "people/search");
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        string jsonBody = JsonConvert.SerializeObject(_searchCriteria);
        request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        List<User> result = await Client.SendRequestAsync<List<User>>(request);

        return result ?? throw new UserException("No matching users found.");
    }
}