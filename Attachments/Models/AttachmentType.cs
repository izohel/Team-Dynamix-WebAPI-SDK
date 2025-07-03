using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDynamix.Api.Attachments.Models;

/// <summary>
/// Describes the different types of supported attachments.
/// </summary>
public enum AttachmentType
{
    /// <summary>
    /// Indicates that the type of attachment is unknown.
    /// </summary>
    None = 0,

    /// <summary>
    /// A project attachment.
    /// </summary>
    Project = 1,

    /// <summary>
    /// An issue attachment.
    /// </summary>
    Issue = 3,

    /// <summary>
    /// An announcement attachment.
    /// </summary>
    Announcement = 7,

    /// <summary>
    /// A ticket attachment.
    /// </summary>
    Ticket = 9,

    /// <summary>
    /// A forum post attachment.
    /// </summary>
    Forums = 13,

    /// <summary>
    /// A Knowledge Base article attachment.
    /// </summary>
    KnowledgeBase = 26,

    /// <summary>
    /// An asset attachment.
    /// </summary>
    Asset = 27,

    /// <summary>
    /// An asset contract attachment.
    /// </summary>
    Contract = 29,

    /// <summary>
    /// A service attachment.
    /// </summary>
    Service = 47,

    /// <summary>
    /// A calendar event attachment.
    /// </summary>
    CalendarEvent = 57,

    /// <summary>
    /// An expense attachment.
    /// </summary>
    Expense = 62,

    /// <summary>
    /// A configuration item attachment.
    /// </summary>
    ConfigurationItem = 63,

    /// <summary>
    /// A location attachment.
    /// </summary>
    Location = 71,

    /// <summary>
    /// A risk attachment.
    /// </summary>
    Risk = 72,

    /// <summary>
    /// A portfolio issue attachment.
    /// </summary>
    PortfolioIssue = 83,

    /// <summary>
    /// A portfolio risk attachment.
    /// </summary>
    PortfolioRisk = 84
}
