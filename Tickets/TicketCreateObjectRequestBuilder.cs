using TeamDynamix.Api.Tickets.Models;
using TeamDynamix.Api.Tickets.Options;


namespace TeamDynamix.Api.Tickets;
/// <summary>
/// Provides a builder for creating tickets using a fully constructed <see cref="Ticket"/> object.
/// </summary>
public class TicketCreateObjectRequestBuilder : BaseRequestBuilder
{
    private readonly Ticket _ticket;
    private readonly TicketCreateOptions _options = new();
    /// <summary>
    /// Initializes a new instance of the <see cref="TicketCreateObjectRequestBuilder"/> class.
    /// </summary>
    /// <param name="path">The API endpoint path.</param>
    /// <param name="client">The client used to send the request.</param>
    /// <param name="ticket">The ticket to be created.</param>
    public TicketCreateObjectRequestBuilder(string path, TdxBaseClient client, Ticket ticket)
        : base(path, client)
    {
        _ticket = ticket;
    }
    /// <summary>
    /// Configures additional query parameters for the creation request.
    /// </summary>
    /// <param name="configure">An action to configure <see cref="TicketCreateOptions"/>.</param>
    public TicketCreateObjectRequestBuilder WithOptions(Action<TicketCreateOptions> configure)
    {
        configure(_options);
        return this;
    }
    /// <summary>
    /// Submits the ticket creation request and returns the created <see cref="Ticket"/>.
    /// </summary>
    public async Task<Ticket> PostAsync()
    {
        ValidateRequired();
        string query = _options.ToQueryString();
        HttpRequestMessage request = CreateRequest(HttpMethod.Post, $"?{query}", _ticket);
        return await SendAsync<Ticket>(request);
    }
    /// <summary>
    /// Ensures required ticket fields are populated before sending the request.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if a required field is not set.</exception>
    private void ValidateRequired()
    {
        if (string.IsNullOrWhiteSpace(_ticket.Title))
            throw new InvalidOperationException("Title is required.");
        if (_ticket.TypeId == 0)
            throw new InvalidOperationException("TypeID is required.");
        if (_ticket.AccountId == 0)
            throw new InvalidOperationException("AccountID is required.");
        if (_ticket.StatusId == 0)
            throw new InvalidOperationException("StatusID is required.");
        if (_ticket.PriorityId == 0)
            throw new InvalidOperationException("PriorityID is required.");
        if (string.IsNullOrEmpty( _ticket.RequestorUid))
            throw new InvalidOperationException("RequestorUid is required.");
    }
}