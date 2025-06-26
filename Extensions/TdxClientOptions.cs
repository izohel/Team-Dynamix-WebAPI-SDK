using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.Extensions;
public class TdxClientOptions
{
    /// <summary>
    /// Optional The fully formed base API URL. If not set, it's built from the Tenant.
    /// </summary>
    public string? BaseApiUrl { get; set; }

    /// <summary>
    /// Invoked before waiting due to a throttling response (HTTP 429).
    /// </summary>
    public Action<TimeSpan>? OnThrottleWait { get; set; }


    /// <summary>
    /// Invoked after waiting completes and before retrying the request.
    /// </summary>
    public Action? OnThrottleContinue { get; set; }
    public bool EnableThrottleCountdownLogging { get; set; } = false;
    /// <summary>
    /// The number of retry attempts after a 429 response.
    /// Default is 1.
    /// </summary>
    public int MaxRetries { get; set; } = 1;
}
