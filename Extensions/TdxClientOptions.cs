using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.Extensions;
/// <summary>
/// Configuration options for the TeamDynamix API client.
/// 
/// This class provides settings that control the behavior of the client,
/// including how it constructs the base API URL, and how it handles throttling
/// responses from the API (HTTP 429 Too Many Requests).
/// 
/// Use these options to customize retry logic, logging, and notification callbacks
/// related to API throttling to improve robustness and observability of API calls.
/// Applies only if not overriding the default HttpClient.
/// </summary>
public class TdxClientOptions
{
    /// <summary>
    /// Optional. The fully formed base API URL for the TeamDynamix API.
    /// If this is not set, the URL will be constructed automatically based on the Tenant identifier.
    /// Setting this explicitly can be useful for targeting different environments such as your demo envrionment or versions.
    /// </summary>
    public string? BaseApiUrl { get; set; }

    /// <summary>    
    /// An optional callback invoked before the client waits due to a throttling response (HTTP 429).
    /// <paragraph>
    ///  The <see cref="TimeSpan"/> parameter indicates how long the client will wait before retrying.
    /// </paragraph>
    /// </summary>
    /// <remarks>This allows the caller to log or display information about the wait time.</remarks>
    public Action<TimeSpan>? OnThrottleWait { get; set; }

    /// <summary>
    /// An optional callback invoked immediately after the throttling wait has completed
    /// and before the client retries the request.
    /// This can be used to notify that the request will be retried.
    /// </summary>
    public Action? OnThrottleContinue { get; set; }

    /// <summary>
    /// If true, enables logging of the countdown timer during throttle wait periods.
    /// Useful for debugging or monitoring retry behavior.
    /// Default is false.
    /// </summary>
    public bool EnableThrottleCountdownLogging { get; set; } = false;

    /// <summary>
    /// The maximum number of retry attempts the client will make after receiving
    /// a throttling response (HTTP 429).
    /// Default value is 3, meaning three retries after the initial failure.
    /// Increasing this number allows more retries but may increase overall latency.
    /// </summary>
    public int MaxRetries { get; set; } = 3;
}

