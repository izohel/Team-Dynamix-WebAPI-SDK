using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TeamDynamix.Api.CustomAttributes.Models;
using TeamDynamix.Api.KnowledgeBase.Models;
using TeamDynamix.Api.SharedModels;

namespace TeamDynamix.Api.Tickets.Models;

/// <summary>
/// Represents a ticket with all associated details in TeamDynamix.
/// </summary>
public class Ticket
{
    /// <summary>
    /// The ID of the ticket.
    /// </summary>
    [JsonProperty("ID")]
    public int Id { get; set; }

    /// <summary>
    /// The ID of the parent associated with the ticket.
    /// </summary>
    [JsonProperty("ParentID")]
    public int ParentId { get; set; }

    /// <summary>
    /// The title of the parent associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ParentTitle))]
    public string ParentTitle { get; set; } = string.Empty;

    /// <summary>
    /// The classification of the parent associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ParentClass))]
    public TicketClass ParentClass { get; set; }

    /// <summary>
    /// The ID of the ticket type associated with the ticket.
    /// </summary>
    [JsonProperty("TypeID")]
    public int TypeId { get; set; }

    /// <summary>
    /// The name of the ticket type associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(TypeName))]
    public string TypeName { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the category associated with the ticket's type.
    /// </summary>
    [JsonProperty("TypeCategoryID")]
    public int TypeCategoryId { get; set; }

    /// <summary>
    /// The name of the category associated with the ticket's type.
    /// </summary>
    [JsonProperty(nameof(TypeCategoryName))]
    public string TypeCategoryName { get; set; } = string.Empty;

    /// <summary>
    /// The classification associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(Classification))]
    public TicketClass Classification { get; set; }

    /// <summary>
    /// The application-defined name of the classification associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ClassificationName))]
    public string ClassificationName { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the form associated with the ticket.
    /// </summary>
    [JsonProperty("FormID")]
    public int FormId { get; set; }

    /// <summary>
    /// The name of the form associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(FormName))]
    public string FormName { get; set; } = string.Empty;

    /// <summary>
    /// The title of the ticket.
    /// </summary>
    [JsonProperty(nameof(Title))]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The description of the ticket.
    /// </summary>
    [JsonProperty(nameof(Description))]
    public string? Description { get; set; }

    /// <summary>
    /// Indicates if the ticket description is rich-text or plain-text.
    /// </summary>
    [JsonProperty(nameof(IsRichHtml))]
    public bool IsRichHtml { get; set; }

    /// <summary>
    /// The URI to retrieve the full details of the ticket via the web API.
    /// </summary>
    [JsonProperty(nameof(Uri))]
    public string Uri { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the account/department associated with the ticket.
    /// </summary>
    [JsonProperty("AccountID")]
    public int AccountId { get; set; }

    /// <summary>
    /// The name of the account/department associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(AccountName))]
    public string AccountName { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the ticket source associated with the ticket.
    /// </summary>
    [JsonProperty("SourceID")]
    public int SourceId { get; set; }

    /// <summary>
    /// The name of the ticket source associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(SourceName))]
    public string SourceName { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the ticket status associated with the ticket.
    /// </summary>
    [JsonProperty("StatusID")]
    public int StatusId { get; set; }

    /// <summary>
    /// The name of the ticket status associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(StatusName))]
    public string StatusName { get; set; } = string.Empty;

    /// <summary>
    /// The class of the ticket status associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(StatusClass))]
    public StatusClass StatusClass { get; set; }

    /// <summary>
    /// The ID of the impact associated with the ticket.
    /// </summary>
    [JsonProperty("ImpactID")]
    public int ImpactId { get; set; }

    /// <summary>
    /// The name of the impact associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ImpactName))]
    public string ImpactName { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the urgency associated with the ticket.
    /// </summary>
    [JsonProperty("UrgencyID")]
    public int UrgencyId { get; set; }

    /// <summary>
    /// The name of the urgency associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(UrgencyName))]
    public string UrgencyName { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the priority associated with the ticket.
    /// </summary>
    [JsonProperty("PriorityID")]
    public int PriorityId { get; set; }

    /// <summary>
    /// The name of the priority associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(PriorityName))]
    public string PriorityName { get; set; } = string.Empty;

    /// <summary>
    /// The order of the priority associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(PriorityOrder))]
    public double PriorityOrder { get; set; }

    /// <summary>
    /// The ID of the Service Level Agreement (SLA) associated with the ticket.
    /// </summary>
    [JsonProperty("SlaID")]
    public int SlaId { get; set; }

    /// <summary>
    /// The name of the Service Level Agreement (SLA) associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(SlaName))]
    public string SlaName { get; set; } = string.Empty;

    /// <summary>
    /// Whether the Service Level Agreement (SLA) associated with the ticket has been violated.
    /// </summary>
    [JsonProperty(nameof(IsSlaViolated))]
    public bool IsSlaViolated { get; set; }

    /// <summary>
    /// Whether the Service Level Agreement (SLA) associated with the ticket has its "Respond By" component violated.
    /// </summary>
    [JsonProperty(nameof(IsSlaRespondByViolated))]
    public bool? IsSlaRespondByViolated { get; set; }

    /// <summary>
    /// Whether the Service Level Agreement (SLA) associated with the ticket has its "Resolve By" component violated.
    /// </summary>
    [JsonProperty(nameof(IsSlaResolveByViolated))]
    public bool? IsSlaResolveByViolated { get; set; }

    /// <summary>
    /// The "Respond By" deadline of the Service Level Agreement (SLA) associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(RespondByDate))]
    public DateTime? RespondByDate { get; set; }

    /// <summary>
    /// The "Resolve By" deadline of the Service Level Agreement (SLA) associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ResolveByDate))]
    public DateTime? ResolveByDate { get; set; }

    /// <summary>
    /// The date the Service Level Agreement (SLA) associated with the ticket was started.
    /// </summary>
    [JsonProperty(nameof(SlaBeginDate))]
    public DateTime? SlaBeginDate { get; set; }

    /// <summary>
    /// The on hold status of the ticket.
    /// </summary>
    [JsonProperty(nameof(IsOnHold))]
    public bool IsOnHold { get; set; }

    /// <summary>
    /// The date the ticket was placed on hold.
    /// </summary>
    [JsonProperty(nameof(PlacedOnHoldDate))]
    public DateTime? PlacedOnHoldDate { get; set; }

    /// <summary>
    /// The date the ticket goes off hold.
    /// </summary>
    [JsonProperty(nameof(GoesOffHoldDate))]
    public DateTime? GoesOffHoldDate { get; set; }

    /// <summary>
    /// The created date of the ticket.
    /// </summary>
    [JsonProperty(nameof(CreatedDate))]
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// The UID of the user who created the ticket.
    /// </summary>
    [JsonProperty(nameof(CreatedUid))]
    public string? CreatedUid { get; set; }

    /// <summary>
    /// The full name of the user who created the ticket.
    /// </summary>
    [JsonProperty(nameof(CreatedFullName))]
    public string CreatedFullName { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the user who created the ticket.
    /// </summary>
    [JsonProperty(nameof(CreatedEmail))]
    public string CreatedEmail { get; set; } = string.Empty;

    /// <summary>
    /// The last modified date of the ticket.
    /// </summary>
    [JsonProperty(nameof(ModifiedDate))]
    public DateTime ModifiedDate { get; set; }

    /// <summary>
    /// The UID of the user who last modified the ticket.
    /// </summary>
    [JsonProperty(nameof(ModifiedUid))]
    public string? ModifiedUid { get; set; }

    /// <summary>
    /// The full name of the user who last modified the ticket.
    /// </summary>
    [JsonProperty(nameof(ModifiedFullName))]
    public string ModifiedFullName { get; set; } = string.Empty;

    /// <summary>
    /// The full name of the requestor associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(RequestorName))]
    public string RequestorName { get; set; } = string.Empty;

    /// <summary>
    /// The first name of the requestor associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(RequestorFirstName))]
    public string RequestorFirstName { get; set; } = string.Empty;

    /// <summary>
    /// The last name of the requestor associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(RequestorLastName))]
    public string RequestorLastName { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the requestor associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(RequestorEmail))]
    public string RequestorEmail { get; set; } = string.Empty;

    /// <summary>
    /// The phone number of the requestor associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(RequestorPhone))]
    public string RequestorPhone { get; set; } = string.Empty;

    /// <summary>
    /// The UID of the requestor associated with the ticket.
    /// Nullable because it may not be provided in some cases.
    /// </summary>
    [JsonProperty("RequestorUID")]
    public string? RequestorUid { get; set; }

    /// <summary>
    /// The time, in minutes, entered against the ticket or associated tasks/activities.
    /// </summary>
    [JsonProperty(nameof(ActualMinutes))]
    public int ActualMinutes { get; set; }

    /// <summary>
    /// The estimated minutes of the ticket.
    /// </summary>
    [JsonProperty(nameof(EstimatedMinutes))]
    public int EstimatedMinutes { get; set; }

    /// <summary>
    /// The age of the ticket, in days.
    /// </summary>
    [JsonProperty(nameof(DaysOld))]
    public int DaysOld { get; set; }

    /// <summary>
    /// The start date of the ticket.
    /// Nullable because it may not be provided.
    /// </summary>
    [JsonProperty(nameof(StartDate))]
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// The end date of the ticket.
    /// Nullable because it may not be provided.
    /// </summary>
    [JsonProperty(nameof(EndDate))]
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// The UID of the responsible user associated with the ticket.
    /// Nullable because it may not be provided.
    /// </summary>
    [JsonProperty(nameof(ResponsibleUid))]
    public string? ResponsibleUid { get; set; }

    /// <summary>
    /// The full name of the responsible user associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ResponsibleFullName))]
    public string ResponsibleFullName { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the responsible user associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ResponsibleEmail))]
    public string ResponsibleEmail { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the responsible group associated with the ticket.
    /// </summary>
    [JsonProperty("ResponsibleGroupID")]
    public int ResponsibleGroupId { get; set; }

    /// <summary>
    /// The name of the responsible group associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ResponsibleGroupName))]
    public string ResponsibleGroupName { get; set; } = string.Empty;

    /// <summary>
    /// The date the ticket was responded to.
    /// </summary>
    [JsonProperty(nameof(RespondedDate))]
    public DateTime RespondedDate { get; set; }

    /// <summary>
    /// The UID of the user who responded to the ticket.
    /// Nullable because it may not be provided.
    /// </summary>
    [JsonProperty(nameof(RespondedUid))]
    public string? RespondedUid { get; set; }

    /// <summary>
    /// The full name of the user who responded to the ticket.
    /// </summary>
    [JsonProperty(nameof(RespondedFullName))]
    public string RespondedFullName { get; set; } = string.Empty;

    /// <summary>
    /// The completed/closed date of the ticket.
    /// </summary>
    [JsonProperty(nameof(CompletedDate))]
    public DateTime CompletedDate { get; set; }

    /// <summary>
    /// The UID of the user who completed/closed the ticket.
    /// Nullable because it may not be provided.
    /// </summary>
    [JsonProperty(nameof(CompletedUid))]
    public string? CompletedUid { get; set; }

    /// <summary>
    /// The full name of the user who completed/closed the ticket.
    /// </summary>
    [JsonProperty(nameof(CompletedFullName))]
    public string CompletedFullName { get; set; } = string.Empty;

    /// <summary>
    /// The UID of the reviewing user associated with the ticket.
    /// Nullable because it may not be provided.
    /// </summary>
    [JsonProperty(nameof(ReviewerUid))]
    public string? ReviewerUid { get; set; }

    /// <summary>
    /// The full name of the reviewing user associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ReviewerFullName))]
    public string ReviewerFullName { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the reviewing user associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ReviewerEmail))]
    public string ReviewerEmail { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the reviewing group associated with the ticket.
    /// </summary>
    [JsonProperty("ReviewingGroupID")]
    public int ReviewingGroupId { get; set; }

    /// <summary>
    /// The name of the reviewing group associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ReviewingGroupName))]
    public string ReviewingGroupName { get; set; } = string.Empty;

    /// <summary>
    /// The time budget of the ticket.
    /// </summary>
    [JsonProperty(nameof(TimeBudget))]
    public double TimeBudget { get; set; }

    /// <summary>
    /// The expense budget of the ticket.
    /// </summary>
    [JsonProperty(nameof(ExpensesBudget))]
    public double ExpensesBudget { get; set; }

    /// <summary>
    /// The used time budget of the ticket.
    /// </summary>
    [JsonProperty(nameof(TimeBudgetUsed))]
    public double TimeBudgetUsed { get; set; }

    /// <summary>
    /// The used expense budget of the ticket.
    /// </summary>
    [JsonProperty(nameof(ExpensesBudgetUsed))]
    public double ExpensesBudgetUsed { get; set; }

    /// <summary>
    /// Whether the ticket has been converted to a project task.
    /// </summary>
    [JsonProperty(nameof(IsConvertedToTask))]
    public bool IsConvertedToTask { get; set; }

    /// <summary>
    /// The date the ticket was converted to a project task.
    /// </summary>
    [JsonProperty(nameof(ConvertedToTaskDate))]
    public DateTime ConvertedToTaskDate { get; set; }

    /// <summary>
    /// The UID of the user who converted the ticket to a project task.
    /// Nullable because it may not be provided.
    /// </summary>
    [JsonProperty(nameof(ConvertedToTaskUid))]
    public string? ConvertedToTaskUid { get; set; }

    /// <summary>
    /// The full name of the user who converted the ticket to a project task.
    /// </summary>
    [JsonProperty(nameof(ConvertedToTaskFullName))]
    public string ConvertedToTaskFullName { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the associated project when the ticket has been converted to a project task.
    /// </summary>
    [JsonProperty("TaskProjectID")]
    public int TaskProjectId { get; set; }

    /// <summary>
    /// The name of the associated project when the ticket has been converted to a project task.
    /// </summary>
    [JsonProperty(nameof(TaskProjectName))]
    public string TaskProjectName { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the associated project plan when the ticket has been converted to a project task.
    /// </summary>
    [JsonProperty("TaskPlanID")]
    public int TaskPlanId { get; set; }

    /// <summary>
    /// The name of the associated project plan when the ticket has been converted to a project task.
    /// </summary>
    [JsonProperty(nameof(TaskPlanName))]
    public string TaskPlanName { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the associated project task when the ticket has been converted to a project task.
    /// </summary>
    [JsonProperty("TaskID")]
    public int TaskId { get; set; }

    /// <summary>
    /// The title of the associated project task when the ticket has been converted to a project task.
    /// </summary>
    [JsonProperty(nameof(TaskTitle))]
    public string TaskTitle { get; set; } = string.Empty;

    /// <summary>
    /// The start date of the associated project task when the ticket has been converted to a project task.
    /// </summary>
    [JsonProperty(nameof(TaskStartDate))]
    public DateTime TaskStartDate { get; set; }

    /// <summary>
    /// The end date of the associated project task when the ticket has been converted to a project task.
    /// </summary>
    [JsonProperty(nameof(TaskEndDate))]
    public DateTime TaskEndDate { get; set; }

    /// <summary>
    /// The percent complete of the associated project task when the ticket has been converted to a project task.
    /// </summary>
    [JsonProperty(nameof(TaskPercentComplete))]
    public int TaskPercentComplete { get; set; }

    /// <summary>
    /// The ID of the location associated with the ticket.
    /// </summary>
    [JsonProperty("LocationID")]
    public int LocationId { get; set; }

    /// <summary>
    /// The name of the location associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(LocationName))]
    public string LocationName { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the location room associated with the ticket.
    /// </summary>
    [JsonProperty("LocationRoomID")]
    public int LocationRoomId { get; set; }

    /// <summary>
    /// The name of the location room associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(LocationRoomName))]
    public string LocationRoomName { get; set; } = string.Empty;

    /// <summary>
    /// The reference code of the ticket.
    /// </summary>
    [JsonProperty(nameof(RefCode))]
    public string RefCode { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the service associated with the ticket.
    /// </summary>
    [JsonProperty("ServiceID")]
    public int ServiceId { get; set; }

    /// <summary>
    /// The name of the service associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ServiceName))]
    public string ServiceName { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the service offering associated with the ticket.
    /// </summary>
    [JsonProperty("ServiceOfferingID")]
    public int ServiceOfferingId { get; set; }

    /// <summary>
    /// The name of the service offering associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ServiceOfferingName))]
    public string ServiceOfferingName { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the category associated with the ticket's service.
    /// </summary>
    [JsonProperty("ServiceCategoryID")]
    public int ServiceCategoryId { get; set; }

    /// <summary>
    /// The name of the category associated with the ticket's service.
    /// </summary>
    [JsonProperty(nameof(ServiceCategoryName))]
    public string ServiceCategoryName { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the Knowledge Base article associated with the ticket.
    /// </summary>
    [JsonProperty("ArticleID")]
    public int ArticleId { get; set; }

    /// <summary>
    /// The subject of the Knowledge Base article associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ArticleSubject))]
    public string ArticleSubject { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the Knowledge Base article associated with the ticket.
    /// </summary>
    [JsonProperty(nameof(ArticleStatus))]
    public ArticleStatus ArticleStatus { get; set; }

    /// <summary>
    /// A delimited string of the category hierarchy associated with the ticket's Knowledge Base article.
    /// </summary>
    [JsonProperty(nameof(ArticleCategoryPathNames))]
    public string ArticleCategoryPathNames { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the client portal application associated with the ticket's Knowledge Base article.
    /// </summary>
    [JsonProperty("ArticleAppID")]
    public int ArticleAppId { get; set; }

    /// <summary>
    /// The ID of the shortcut that is used when viewing the ticket's Knowledge Base article. This is set when the ticket is associated with a cross client portal article shortcut.
    /// Nullable.
    /// </summary>
    [JsonProperty("ArticleShortcutID")]
    public int? ArticleShortcutId { get; set; }

    /// <summary>
    /// The ID of the ticketing application associated with the ticket.
    /// </summary>
    [JsonProperty("AppID")]
    public int AppId { get; set; }

    /// <summary>
    /// The custom attributes associated with the ticket.
    /// Nullable.
    /// </summary>
    [JsonProperty(nameof(Attributes))]
    public List<CustomAttribute>? Attributes { get; set; }

    /// <summary>
    /// The attachments associated with the ticket.
    /// Nullable.
    /// </summary>
    [JsonProperty(nameof(Attachments))]
    public List<Attachments.Models.Attachment>? Attachments { get; set; }

    /// <summary>
    /// The ticket tasks associated with the ticket.
    /// Nullable.
    /// </summary>
    [JsonProperty(nameof(Tasks))]
    public List<TicketTask>? Tasks { get; set; }

    /// <summary>
    /// The list of people who can be notified for the ticket.
    /// Nullable.
    /// </summary>
    [JsonProperty(nameof(Notify))]
    public List<ResourceItem>? Notify { get; set; }

    /// <summary>
    /// The ID of the workflow associated with the ticket.
    /// </summary>
    [JsonProperty("WorkflowID")]
    public int WorkflowId { get; set; }

    /// <summary>
    /// The ID of the configuration workflow associated with the ticket.
    /// </summary>
    [JsonProperty("WorkflowConfigurationID")]
    public int WorkflowConfigurationId { get; set; }

    /// <summary>
    /// The name of the workflow associated with the ticket.
    /// Nullable.
    /// </summary>
    [JsonProperty(nameof(WorkflowName))]
    public string? WorkflowName { get; set; }
}

