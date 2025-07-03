using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDynamix.Api.Tickets.Models;
/// <summary>
/// Describes the different classifications of tickets.
/// </summary>
public enum TicketClass
{
    /// <summary>
    /// An unknown or indeterminate type of ticket.
    /// </summary>
    None = 0,

    /// <summary>
    /// An "all tickets" classification for filtering purposes. 
    /// Tickets should not be created or edited with this class.
    /// </summary>
    Ticket = 9,

    /// <summary>
    /// An incident.
    /// </summary>
    Incident = 32,

    /// <summary>
    /// A major incident.
    /// </summary>
    MajorIncident = 77,

    /// <summary>
    /// A problem.
    /// </summary>
    Problem = 33,

    /// <summary>
    /// A change.
    /// </summary>
    Change = 34,

    /// <summary>
    /// A release.
    /// </summary>
    Release = 35,

    /// <summary>
    /// A ticket template. Tickets should not be created or edited with this class.
    /// </summary>
    TicketTemplate = 36,

    /// <summary>
    /// A service request.
    /// </summary>
    ServiceRequest = 46
}
