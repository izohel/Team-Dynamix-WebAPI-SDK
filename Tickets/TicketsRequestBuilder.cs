using Itsm.Tdx.WebApi.Tickets.Models;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace Itsm.Tdx.WebApi.Tickets;
public class TicketsRequestBuilder : BaseRequestBuilder
{
    public TicketsRequestBuilder(TdxBaseClient client, string appId)
        : base($"{appId}/tickets",client)
    {
        ArgumentException.ThrowIfNullOrEmpty(appId);
        AppId = appId;
    }
    public string AppId { get; }
    
    public TicketItemRequestBuilder this[string ticketId]
        => new($"{Path}/{ticketId}",Client);
    public TicketCreateRequestBuilder Create()
        => new(Path, Client);
    public TicketCreateObjectRequestBuilder Create(Ticket ticket)
        => new(Path, Client, ticket);

}
