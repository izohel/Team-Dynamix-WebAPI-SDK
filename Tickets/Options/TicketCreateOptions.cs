using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.Tickets.Options;
/// <summary>
/// Represents optional parameters that can be applied when creating a ticket via the TeamDynamix API.
/// These options are serialized into query string parameters.
/// </summary>
public class TicketCreateOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether to enable notifications to the reviewer.
    /// </summary>
    public bool EnableNotifyReviewer { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether to apply default values to the ticket.
    /// </summary>
    public bool ApplyDefaults { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to allow creation of the requestor if they do not already exist.
    /// </summary>
    public bool AllowRequestorCreation { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether to notify the person responsible for the ticket.
    /// </summary>
    public bool NotifyResponsible { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to notify the requestor.
    /// </summary>
    public bool NotifyRequestor { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to prefer the requestor's account and priority over defaults.
    /// </summary>
    public bool PreferRequestorAccountAndPriority { get; set; } = false;

    /// <summary>
    /// Converts the current options to a URL query string suitable for appending to an HTTP request.
    /// </summary>
    /// <returns>A query string representation of the ticket creation options.</returns>
    public string ToQueryString()
    {
        Dictionary<string, string> dict = new()
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

