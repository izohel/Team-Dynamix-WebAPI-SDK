using Itsm.Tdx.WebApi.Tickets.Models;
using Itsm.Tdx.WebApi.Tickets.Options;


namespace Itsm.Tdx.WebApi.Tickets;
public class TicketCreateObjectRequestBuilder : BaseRequestBuilder
{
    private readonly Ticket _ticket;
    private readonly TicketCreateOptions _options = new();

    public TicketCreateObjectRequestBuilder(string path, TdxBaseClient client, Ticket ticket)
        : base(path, client)
    {
        _ticket = ticket;
    }

    public TicketCreateObjectRequestBuilder WithOptions(Action<TicketCreateOptions> configure)
    {
        configure(_options);
        return this;
    }

    public async Task<Ticket> PostAsync()
    {
        ValidateRequired();
        string query = _options.ToQueryString();
        HttpRequestMessage request = CreateRequest(HttpMethod.Post, $"?{query}", _ticket);
        return await SendAsync<Ticket>(request);
    }

    private void ValidateRequired()
    {
        if (string.IsNullOrWhiteSpace(_ticket.Title))
            throw new InvalidOperationException("Title is required.");
        if (_ticket.TypeID == 0)
            throw new InvalidOperationException("TypeID is required.");
        if (_ticket.AccountID == 0)
            throw new InvalidOperationException("AccountID is required.");
        if (_ticket.StatusID == 0)
            throw new InvalidOperationException("StatusID is required.");
        if (_ticket.PriorityID == 0)
            throw new InvalidOperationException("PriorityID is required.");
        if (string.IsNullOrEmpty( _ticket.RequestorUid))
            throw new InvalidOperationException("RequestorUid is required.");
    }
}