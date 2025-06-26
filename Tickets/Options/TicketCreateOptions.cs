using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.Tickets.Options;
public class TicketCreateOptions
{
    public bool EnableNotifyReviewer { get; set; } = false;
    public bool ApplyDefaults { get; set; } = true;
    public bool AllowRequestorCreation { get; set; } = false;
    public bool NotifyResponsible { get; set; } = true;
    public bool NotifyRequestor { get; set; } = true;
    public bool PreferRequestorAccountAndPriority { get; set; } = false;

    public string ToQueryString()
    {
        Dictionary<string, string> dict = new ()
        {
            ["EnableNotifyReviewer"] = EnableNotifyReviewer.ToString().ToLowerInvariant(),
            ["ApplyDefaults"] = ApplyDefaults.ToString().ToLowerInvariant(),
            ["AllowRequestorCreation"] = AllowRequestorCreation.ToString().ToLowerInvariant(),
            ["NotifyResponsible"] = NotifyResponsible.ToString().ToLowerInvariant(),
            ["NotifyRequestor"] = NotifyRequestor.ToString().ToLowerInvariant(),
            ["PreferRequestorAccountAndPriority"] = PreferRequestorAccountAndPriority.ToString().ToLowerInvariant()
        };

        return string.Join("&", dict.Select(kv => $"{kv.Key}={kv.Value}"));
    }
}
