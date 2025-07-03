using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDynamix.Api.Tickets.Models;
/// <summary>
/// A ticket task or activity.
/// </summary>
public class TicketTask
{
    /// <summary>The ID of the task.</summary>
    [JsonProperty("ID")]
    public int Id { get; set; }

    /// <summary>The ID of the ticket associated with the task.</summary>
    [JsonProperty("TicketID")]
    public int TicketId { get; set; }

    /// <summary>The title of the task.</summary>
    [JsonProperty(nameof(Title))]
    public string Title { get; set; } = string.Empty;

    /// <summary>The description of the task.</summary>
    [JsonProperty(nameof(Description))]
    public string? Description { get; set; }

    /// <summary>The active status of the ticket task.</summary>
    [JsonProperty(nameof(IsActive))]
    public bool IsActive { get; set; }

    /// <summary>Whether to notify responsible party. Defaults to true.</summary>
    [JsonProperty(nameof(NotifyResponsible))]
    public bool NotifyResponsible { get; set; }

    /// <summary>The start date of the task.</summary>
    [JsonProperty(nameof(StartDate))]
    public DateTime? StartDate { get; set; }

    /// <summary>The end date of the task.</summary>
    [JsonProperty(nameof(EndDate))]
    public DateTime? EndDate { get; set; }

    /// <summary>The expected duration, in operational minutes, of the task.</summary>
    [JsonProperty(nameof(CompleteWithinMinutes))]
    public int? CompleteWithinMinutes { get; set; }

    /// <summary>The estimated minutes of the task.</summary>
    [JsonProperty(nameof(EstimatedMinutes))]
    public int EstimatedMinutes { get; set; }

    /// <summary>The time, in minutes, entered against the task.</summary>
    [JsonProperty(nameof(ActualMinutes))]
    public int ActualMinutes { get; set; }

    /// <summary>The percent complete of the task.</summary>
    [JsonProperty(nameof(PercentComplete))]
    public int PercentComplete { get; set; }

    /// <summary>The created date of the task.</summary>
    [JsonProperty(nameof(CreatedDate))]
    public DateTime CreatedDate { get; set; }

    /// <summary>The UID of the user who created the task.</summary>
    [JsonProperty("CreatedUID")]
    public Guid CreatedUid { get; set; }

    /// <summary>The full name of the user who created the task.</summary>
    [JsonProperty(nameof(CreatedFullName))]
    public string CreatedFullName { get; set; } = string.Empty;

    /// <summary>The email address of the user who created the task.</summary>
    [JsonProperty(nameof(CreatedEmail))]
    public string CreatedEmail { get; set; } = string.Empty;

    /// <summary>The last modified date of the task.</summary>
    [JsonProperty(nameof(ModifiedDate))]
    public DateTime ModifiedDate { get; set; }

    /// <summary>The UID of the user who last modified the task.</summary>
    [JsonProperty("ModifiedUID")]
    public Guid ModifiedUid { get; set; }

    /// <summary>The full name of the user who last modified the task.</summary>
    [JsonProperty(nameof(ModifiedFullName))]
    public string ModifiedFullName { get; set; } = string.Empty;

    /// <summary>The completed date of the task.</summary>
    [JsonProperty(nameof(CompletedDate))]
    public DateTime CompletedDate { get; set; }

    /// <summary>The UID of the user who completed the task.</summary>
    [JsonProperty("CompletedUID")]
    public Guid? CompletedUid { get; set; }

    /// <summary>The full name of the user who completed the task.</summary>
    [JsonProperty(nameof(CompletedFullName))]
    public string CompletedFullName { get; set; } = string.Empty;

    /// <summary>The UID of the user responsible for the task.</summary>
    [JsonProperty("ResponsibleUID")]
    public Guid? ResponsibleUid { get; set; }

    /// <summary>The full name of the user responsible for the task.</summary>
    [JsonProperty(nameof(ResponsibleFullName))]
    public string ResponsibleFullName { get; set; } = string.Empty;

    /// <summary>The email address of the user responsible for the task.</summary>
    [JsonProperty(nameof(ResponsibleEmail))]
    public string ResponsibleEmail { get; set; } = string.Empty;

    /// <summary>The ID of the group responsible for the task.</summary>
    [JsonProperty("ResponsibleGroupID")]
    public int ResponsibleGroupId { get; set; }

    /// <summary>The name of the group responsible for the task.</summary>
    [JsonProperty(nameof(ResponsibleGroupName))]
    public string ResponsibleGroupName { get; set; } = string.Empty;

    /// <summary>The ID of the predecessor associated with the task.</summary>
    [JsonProperty("PredecessorID")]
    public int PredecessorId { get; set; }

    /// <summary>The title of the predecessor associated with the task.</summary>
    [JsonProperty(nameof(PredecessorTitle))]
    public string PredecessorTitle { get; set; } = string.Empty;

    /// <summary>The order in which the task should be displayed in the list of the ticket's tasks/activities.</summary>
    [JsonProperty(nameof(Order))]
    public int Order { get; set; }

    /// <summary>The type ID of the task.</summary>
    [JsonProperty("TypeID")]
    public TicketTaskType TypeId { get; set; }

    /// <summary>The number of detected conflicts for this task.</summary>
    [JsonProperty(nameof(DetectedConflictCount))]
    public int DetectedConflictCount { get; set; }

    /// <summary>The type of detected conflicts for this task.</summary>
    [JsonProperty(nameof(DetectedConflictTypes))]
    public ConflictType DetectedConflictTypes { get; set; }

    /// <summary>The date the task was last scanned for conflicts.</summary>
    [JsonProperty(nameof(LastConflictScanDateUtc))]
    public DateTime LastConflictScanDateUtc { get; set; }

    /// <summary>The URI to retrieve the full details of the ticket task via the web API.</summary>
    [JsonProperty(nameof(Uri))]
    public string Uri { get; set; } = string.Empty;
}