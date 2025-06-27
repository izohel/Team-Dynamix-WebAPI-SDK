using Itsm.Tdx.WebApi.Tickets.Models;

namespace Itsm.Tdx.WebApi.Tickets;
/// <summary>
/// Provides operations to retrieve a specific ticket by ID.
/// </summary>
public class TicketItemRequestBuilder : BaseRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TicketItemRequestBuilder"/> class.
    /// </summary>
    /// <param name="path">The API path to the specific ticket.</param>
    /// <param name="tdxBaseClient">The client used to send requests.</param>
    public TicketItemRequestBuilder(string path, TdxBaseClient tdxBaseClient)
        : base(path, tdxBaseClient) { }
    /// <summary>
    /// Retrieves the ticket identified by the path.
    /// </summary>
    /// <returns>A <see cref="Ticket"/> object representing the ticket.</returns>
    public async Task<Ticket> GetAsync()
    {
        HttpRequestMessage request = new(HttpMethod.Get, Path);
        return await Client.SendRequestAsync<Ticket>(request);
    }
}