using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;


namespace TeamDynamix.Api.People;
/// <summary>
/// Provides methods for interacting with people in the TeamDynamix system.
/// This includes searching for people or retrieving them by UID.
/// </summary>
public class PeopleRequestBuilder : BaseRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PeopleRequestBuilder"/> class.
    /// </summary>
    /// <param name="client">The base TDX API client used for sending requests.</param>
    public PeopleRequestBuilder(TdxBaseClient client)
        : base("people", client)
    {
    }

    /// <summary>
    /// Gets a request builder used to search for people using various filters.
    /// </summary>
    public PersonSearchRequestBuilder Search => new($"{Path}/search", Client);

    // Future implementation for lookup can be re-enabled here
    // public PersonLookupRequestBuilder Lookup => new(Client);

    /// <summary>
    /// Gets a request builder to access a specific person by their UID.
    /// </summary>
    /// <param name="uid">The UID of the person to retrieve.</param>
    /// <returns>A <see cref="PersonByIdRequestBuilder"/> for the specified person.</returns>
    public PersonByIdRequestBuilder this[string uid]
        => new($"{Path}/{uid}", Client);
}
