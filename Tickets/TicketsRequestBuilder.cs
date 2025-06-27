using Itsm.Tdx.WebApi.Tickets.Models;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace Itsm.Tdx.WebApi.Tickets;
/// <summary>
/// Provides operations to manage and create tickets within a specific ticketing application
/// in the TeamDynamix platform.
/// </summary>
public class TicketsRequestBuilder : BaseRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TicketsRequestBuilder"/> class.
    /// </summary>
    /// <param name="client">The TDX base client used to send HTTP requests.</param>
    /// <param name="appId">The ID of the ticketing application.</param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="appId"/> is null or empty.</exception>
    public TicketsRequestBuilder(TdxBaseClient client, string appId)
        : base($"{appId}/tickets",client)
    {
        ArgumentException.ThrowIfNullOrEmpty(appId);
        AppId = appId;
    }
    /// <summary>
    /// Gets the ID of the ticketing application associated with this request builder.
    /// </summary>
    public string AppId { get; }
    /// <summary>
    /// Provides operations for a specific ticket by its ID.
    /// </summary>
    /// <param name="ticketId">The ID of the ticket to manage.</param>
    /// <returns>A <see cref="TicketItemRequestBuilder"/> for the specified ticket.</returns>
    public TicketItemRequestBuilder this[string ticketId]
        => new($"{Path}/{ticketId}",Client);
    /// <summary>
    /// Provides operations for creating new tickets using request parameters.
    /// </summary>
    /// <returns>A <see cref="TicketCreateRequestBuilder"/> for ticket creation.</returns>
    public TicketCreateRequestBuilder Create()
        => new(Path, Client);

    /// <summary>
    /// Provides operations for creating a new ticket using a <see cref="Ticket"/> object.
    /// </summary>
    /// <param name="ticket">The ticket to create.</param>
    /// <returns>A <see cref="TicketCreateObjectRequestBuilder"/> to execute the ticket creation.</returns>
    public TicketCreateObjectRequestBuilder Create(Ticket ticket)
        => new(Path, Client, ticket);

}
