using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.Tickets.Models;
/// <summary>
/// Describes the different types of items that can be backended by ticket tasks.
/// </summary>
public enum TicketTaskType
{
    /// <summary>
    /// An unknown or indeterminate type of task.
    /// </summary>
    None = 0,

    /// <summary>
    /// A standard, workable ticket task.
    /// </summary>
    TicketTask = 1,

    /// <summary>
    /// A scheduled maintenance activity.
    /// </summary>
    MaintenanceActivity = 2,

    /// <summary>
    /// A task that is used as a work step in a workflow.
    /// </summary>
    WorkflowTask = 3,
}
