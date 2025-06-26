using Itsm.Tdx.WebApi.Tickets.Models;

namespace Itsm.Tdx.WebApi.Tickets;

public class TicketItemRequestBuilder : BaseRequestBuilder
{
    public TicketItemRequestBuilder(string path, TdxBaseClient tdxBaseClient)
        : base(path, tdxBaseClient) { }
    public async Task<Ticket> GetAsync()
    {
        HttpRequestMessage request = new(HttpMethod.Get, Path);
        request.Headers.Accept.Add(new("application/json"));
        return await Client.SendRequestAsync<Ticket>(request);
    }
}