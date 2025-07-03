using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDynamix.Api.Tickets.Models;
/// <summary>
/// Describes the different classes of statuses.
/// </summary>
public enum StatusClass
{
    /// <summary>
    /// Used when a status class could not be determined. Should not be used in normal operations.
    /// </summary>
    None = 0,

    /// <summary>
    /// Used for new statuses.
    /// </summary>
    New = 1,

    /// <summary>
    /// Used for statuses that are somewhere in the pipeline, but not yet completed.
    /// </summary>
    InProcess = 2,

    /// <summary>
    /// Used for statuses that indicate completion such as "Closed" or "Closed and Approved".
    /// </summary>
    Completed = 3,

    /// <summary>
    /// Used for items that are cancelled.
    /// </summary>
    Cancelled = 4,

    /// <summary>
    /// Used for items that are on hold.
    /// </summary>
    OnHold = 5,

    /// <summary>
    /// Used for items that have been requested and not yet assigned a status.
    /// </summary>
    Requested = 6
}
