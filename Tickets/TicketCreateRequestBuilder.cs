using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamDynamix.Api.Tickets.Models;
using TeamDynamix.Api.Tickets.Options;

namespace TeamDynamix.Api.Tickets;
/// <summary>
/// Provides a fluent interface for constructing and submitting a new ticket using discrete fields.
/// </summary>
public class TicketCreateRequestBuilder : BaseRequestBuilder
{
    private readonly Dictionary<string, object> _ticket = new();
    private readonly TicketCreateOptions _options = new();
    private readonly string[] requiredFields = { "TypeId", "Title", "AccountId", "StatusId","RequestorUid" };
    /// <summary>
    /// Initializes a new instance of the <see cref="TicketCreateRequestBuilder"/> class.
    /// </summary>
    /// <param name="path">The base path for the ticket creation API endpoint.</param>
    /// <param name="client">The API client used to make requests.</param>
    public TicketCreateRequestBuilder(string path, TdxBaseClient client)
        : base(path, client) { }

    /// <summary>Sets the type ID of the ticket.</summary>
    public TicketCreateRequestBuilder WithTypeId(string typeId) => Add("TypeId", typeId);

    /// <summary>Sets the title of the ticket.</summary>
    public TicketCreateRequestBuilder WithTitle(string title) => Add("Title", title);

    /// <summary>Sets the account ID associated with the ticket.</summary>
    public TicketCreateRequestBuilder WithAccountId(string accountId) => Add("AccountId", accountId);

    /// <summary>Sets the status ID of the ticket.</summary>
    public TicketCreateRequestBuilder WithStatusId(string statusID) => Add("StatusId",statusID);

    /// <summary>Sets the UID of the requestor.</summary>
    public TicketCreateRequestBuilder WithRequestor(string uid) => Add("RequestorUid", uid);

    /// <summary>Sets the description for the ticket.</summary>
    public TicketCreateRequestBuilder WithDescription(string description) => Add("Description", description);

    /// <summary>Sets the UID of the responsible person.</summary>
    public TicketCreateRequestBuilder WithResponsible(string uid) => Add("ResponsibleUid", uid);

    /// <summary> Sets Id of the responsible group associated with the ticket. </summary>
    /// <param name="id">Id Of the responsible group</param>
    public TicketCreateRequestBuilder WithResponsibleGroup(string id) => Add("ResponsibleGroupID", id);

    private TicketCreateRequestBuilder Add(string key, object value)
    {
        _ticket[key] = value;
        return this;
    }

    ///<summary>
    /// Applies additional options for the ticket creation request.
    /// </summary>
    /// <param name="configure">An action to configure the <see cref="TicketCreateOptions"/>.</param>
    public TicketCreateRequestBuilder WithOptions(Action<TicketCreateOptions> configure)
    {
        configure(_options);
        return this;
    }

    /// <summary>
    /// Submits the ticket creation request and returns the created <see cref="Ticket"/>.
    /// </summary>
    public async Task<Ticket> PostAsync()
    {
        ValidateRequiredFields();
        string queryString = _options.ToQueryString();
        HttpRequestMessage request = CreateRequest(HttpMethod.Post, $"?{queryString}", _ticket);

        string requestBody = await request.Content.ReadAsStringAsync();
        Console.WriteLine(requestBody);
        return await SendAsync<Ticket>(request);
    }
    /// <summary>
    /// Validates that all required fields for ticket creation are present.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when a required field is missing.</exception>
    public void ValidateRequiredFields()
    {

        foreach (string field in requiredFields)
            if (!_ticket.ContainsKey(field))
                throw new InvalidOperationException($"{field} is required to create a ticket.");
    }
}
