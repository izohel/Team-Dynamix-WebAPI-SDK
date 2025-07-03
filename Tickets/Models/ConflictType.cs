using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDynamix.Api.Tickets.Models;
using System;

/// <summary>
/// Describes the different types of conflicts that can be detected for a scheduled maintenance activity for a CI.
/// </summary>
/// /// <remarks>This is an enumeration that can be treated as a bit field (i.e. a series of flags), and thus the fields can be combined.</remarks>
[Flags]
public enum ConflictType
{
    /// <summary>
    /// Indicates that no conflicts were detected.
    /// </summary>
    None = 0,

    /// <summary>
    /// Indicates that an activity takes place outside of the CI's maintenance window.
    /// </summary>
    OutsideMaintenanceWindow = 1,

    /// <summary>
    /// Indicates that an activity takes place during a blackout window.
    /// </summary>
    DuringBlackoutWindow = 2,

    /// <summary>
    /// Indicates that an activity conflicts with a pre-existing activity scheduled for the CI.
    /// </summary>
    ExistingActivity = 4,

    /// <summary>
    /// Indicates that an activity takes place outside the maintenance window of one or more of the CI's operational children.
    /// </summary>
    OutsideChildMaintenanceWindow = 8,

    /// <summary>
    /// Indicates that an activity conflicts with a pre-existing activity on one of the CI's operational children.
    /// </summary>
    ExistingChildActivity = 16,

    /// <summary>
    /// Indicates that an activity conflicts with a pre-existing activity on one of the CI's operational parents.
    /// </summary>
    ExistingParentActivity = 32,
}

