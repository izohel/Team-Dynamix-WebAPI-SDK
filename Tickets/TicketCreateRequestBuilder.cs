using Itsm.Tdx.WebApi.Tickets.Models;
using Itsm.Tdx.WebApi.Tickets.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.Tickets;
public class TicketCreateRequestBuilder : BaseRequestBuilder
{
    private readonly Dictionary<string, object> _ticket = new();
    private readonly TicketCreateOptions _options = new();
    private readonly string[] requiredFields = { "TypeId", "Title", "AccountId", "StatusId", "PriorityId", "RequestorUid" };
    public TicketCreateRequestBuilder(string path, TdxBaseClient client)
        : base(path, client) { }
    public TicketCreateRequestBuilder WithTypeId(string typeId) => Add("TypeId", typeId);
    public TicketCreateRequestBuilder WithTitle(string title) => Add("Title", title);
    public TicketCreateRequestBuilder WithAccountId(string accountId) => Add("AccountId", accountId);
    public TicketCreateRequestBuilder WithStatusId(string statusID) => Add("StatusId",statusID);
    public TicketCreateRequestBuilder WithPriority(string priorityId) => Add("PriorityId", priorityId);
    public TicketCreateRequestBuilder WithRequestor(string uid) => Add("RequestorUid", uid);
    public TicketCreateRequestBuilder WithDescription(string description) => Add("Description", description);
    public TicketCreateRequestBuilder WithResponsible(string uid) => Add("ResponsibleUid", uid);

    private TicketCreateRequestBuilder Add(string key, object value)
    {
        _ticket[key] = value;
        return this;
    }
    public TicketCreateRequestBuilder WithOptions(Action<TicketCreateOptions> configure)
    {
        configure(_options);
        return this;
    }

    public async Task<Ticket> PostAsync()
    {
        ValidateRequiredFields();
        string queryString = _options.ToQueryString();
        HttpRequestMessage request = CreateRequest(HttpMethod.Post, $"?{queryString}", _ticket);

        //string requestBody = await request.Content.ReadAsStringAsync();
        return await SendAsync<Ticket>(request);
    }
    public void ValidateRequiredFields()
    {

        foreach (string field in requiredFields)
        {
            if (!_ticket.ContainsKey(field))
                throw new InvalidOperationException($"{field} is required to create a ticket.");
        }
    }
}
