using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.Tickets.Models;

public class Ticket
{
    [JsonPropertyName("ID")]
    public int? ID { get; set; }

    [JsonPropertyName("ParentID")]
    public int? ParentID { get; set; }

    [JsonPropertyName("ParentTitle")]
    public string? ParentTitle { get; set; }

    [JsonPropertyName("ParentClass")]
    public int? ParentClass { get; set; }

    [JsonPropertyName("TypeID")]
    public int? TypeID { get; set; }

    [JsonPropertyName("TypeName")]
    public string? TypeName { get; set; }

    [JsonPropertyName("TypeCategoryID")]
    public int? TypeCategoryID { get; set; }

    [JsonPropertyName("TypeCategoryName")]
    public string? TypeCategoryName { get; set; }

    [JsonPropertyName("Classification")]
    public int? Classification { get; set; }

    [JsonPropertyName("ClassificationName")]
    public string? ClassificationName { get; set; }

    [JsonPropertyName("FormID")]
    public int? FormID { get; set; }

    [JsonPropertyName("FormName")]
    public string? FormName { get; set; }

    [JsonPropertyName("Title")]
    public string? Title { get; set; }

    [JsonPropertyName("Description")]
    public string? Description { get; set; }

    [JsonPropertyName("IsRichHtml")]
    public bool? IsRichHtml { get; set; }

    [JsonPropertyName("Uri")]
    public string? Uri { get; set; }

    [JsonPropertyName("AccountID")]
    public int? AccountID { get; set; }

    [JsonPropertyName("AccountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("SourceID")]
    public int? SourceID { get; set; }

    [JsonPropertyName("SourceName")]
    public string? SourceName { get; set; }

    [JsonPropertyName("StatusID")]
    public int? StatusID { get; set; }

    [JsonPropertyName("StatusName")]
    public string? StatusName { get; set; }

    [JsonPropertyName("StatusClass")]
    public int? StatusClass { get; set; }

    [JsonPropertyName("ImpactID")]
    public int? ImpactID { get; set; }

    [JsonPropertyName("ImpactName")]
    public string? ImpactName { get; set; }

    [JsonPropertyName("UrgencyID")]
    public int? UrgencyID { get; set; }

    [JsonPropertyName("UrgencyName")]
    public string? UrgencyName { get; set; }

    [JsonPropertyName("PriorityID")]
    public int? PriorityID { get; set; }

    [JsonPropertyName("PriorityName")]
    public string? PriorityName { get; set; }

    [JsonPropertyName("PriorityOrder")]
    public double? PriorityOrder { get; set; }

    [JsonPropertyName("SlaID")]
    public int? SlaID { get; set; }

    [JsonPropertyName("SlaName")]
    public string? SlaName { get; set; }

    [JsonPropertyName("IsSlaViolated")]
    public bool? IsSlaViolated { get; set; }

    [JsonPropertyName("IsSlaRespondByViolated")]
    public bool? IsSlaRespondByViolated { get; set; }

    [JsonPropertyName("IsSlaResolveByViolated")]
    public bool? IsSlaResolveByViolated { get; set; }

    [JsonPropertyName("RespondByDate")]
    public DateTime? RespondByDate { get; set; }

    [JsonPropertyName("ResolveByDate")]
    public DateTime? ResolveByDate { get; set; }

    [JsonPropertyName("SlaBeginDate")]
    public DateTime? SlaBeginDate { get; set; }

    [JsonPropertyName("IsOnHold")]
    public bool? IsOnHold { get; set; }

    [JsonPropertyName("PlacedOnHoldDate")]
    public DateTime? PlacedOnHoldDate { get; set; }

    [JsonPropertyName("GoesOffHoldDate")]
    public DateTime? GoesOffHoldDate { get; set; }

    [JsonPropertyName("CreatedDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("CreatedUid")]
    public string? CreatedUid { get; set; }

    [JsonPropertyName("CreatedFullName")]
    public string? CreatedFullName { get; set; }

    [JsonPropertyName("CreatedEmail")]
    public string? CreatedEmail { get; set; }

    [JsonPropertyName("ModifiedDate")]
    public DateTime? ModifiedDate { get; set; }

    [JsonPropertyName("ModifiedUid")]
    public string? ModifiedUid { get; set; }

    [JsonPropertyName("ModifiedFullName")]
    public string? ModifiedFullName { get; set; }

    [JsonPropertyName("RequestorName")]
    public string? RequestorName { get; set; }

    [JsonPropertyName("RequestorFirstName")]
    public string? RequestorFirstName { get; set; }

    [JsonPropertyName("RequestorLastName")]
    public string? RequestorLastName { get; set; }

    [JsonPropertyName("RequestorEmail")]
    public string? RequestorEmail { get; set; }

    [JsonPropertyName("RequestorPhone")]
    public string? RequestorPhone { get; set; }

    [JsonPropertyName("RequestorUid")]
    public string? RequestorUid { get; set; }

    [JsonPropertyName("ActualMinutes")]
    public int? ActualMinutes { get; set; }

    [JsonPropertyName("EstimatedMinutes")]
    public int? EstimatedMinutes { get; set; }

    [JsonPropertyName("DaysOld")]
    public int? DaysOld { get; set; }

    [JsonPropertyName("StartDate")]
    public object? StartDate { get; set; }

    [JsonPropertyName("EndDate")]
    public object? EndDate { get; set; }

    [JsonPropertyName("ResponsibleUid")]
    public string? ResponsibleUid { get; set; }

    [JsonPropertyName("ResponsibleFullName")]
    public string? ResponsibleFullName { get; set; }

    [JsonPropertyName("ResponsibleEmail")]
    public string? ResponsibleEmail { get; set; }

    [JsonPropertyName("ResponsibleGroupID")]
    public int? ResponsibleGroupID { get; set; }

    [JsonPropertyName("ResponsibleGroupName")]
    public string? ResponsibleGroupName { get; set; }

    [JsonPropertyName("RespondedDate")]
    public DateTime? RespondedDate { get; set; }

    [JsonPropertyName("RespondedUid")]
    public object? RespondedUid { get; set; }

    [JsonPropertyName("RespondedFullName")]
    public string? RespondedFullName { get; set; }

    [JsonPropertyName("CompletedDate")]
    public DateTime? CompletedDate { get; set; }

    [JsonPropertyName("CompletedUid")]
    public string? CompletedUid { get; set; }

    [JsonPropertyName("CompletedFullName")]
    public string? CompletedFullName { get; set; }

    [JsonPropertyName("ReviewerUid")]
    public object? ReviewerUid { get; set; }

    [JsonPropertyName("ReviewerFullName")]
    public string? ReviewerFullName { get; set; }

    [JsonPropertyName("ReviewerEmail")]
    public string? ReviewerEmail { get; set; }

    [JsonPropertyName("ReviewingGroupID")]
    public int? ReviewingGroupID { get; set; }

    [JsonPropertyName("ReviewingGroupName")]
    public string? ReviewingGroupName { get; set; }

    [JsonPropertyName("TimeBudget")]
    public double? TimeBudget { get; set; }

    [JsonPropertyName("ExpensesBudget")]
    public double? ExpensesBudget { get; set; }

    [JsonPropertyName("TimeBudgetUsed")]
    public double? TimeBudgetUsed { get; set; }

    [JsonPropertyName("ExpensesBudgetUsed")]
    public double? ExpensesBudgetUsed { get; set; }

    [JsonPropertyName("IsConvertedToTask")]
    public bool? IsConvertedToTask { get; set; }

    [JsonPropertyName("ConvertedToTaskDate")]
    public DateTime? ConvertedToTaskDate { get; set; }

    [JsonPropertyName("ConvertedToTaskUid")]
    public object? ConvertedToTaskUid { get; set; }

    [JsonPropertyName("ConvertedToTaskFullName")]
    public string? ConvertedToTaskFullName { get; set; }

    [JsonPropertyName("TaskProjectID")]
    public int? TaskProjectID { get; set; }

    [JsonPropertyName("TaskProjectName")]
    public string? TaskProjectName { get; set; }

    [JsonPropertyName("TaskPlanID")]
    public int? TaskPlanID { get; set; }

    [JsonPropertyName("TaskPlanName")]
    public string? TaskPlanName { get; set; }

    [JsonPropertyName("TaskID")]
    public int? TaskID { get; set; }

    [JsonPropertyName("TaskTitle")]
    public string? TaskTitle { get; set; }

    [JsonPropertyName("TaskStartDate")]
    public DateTime? TaskStartDate { get; set; }

    [JsonPropertyName("TaskEndDate")]
    public DateTime? TaskEndDate { get; set; }

    [JsonPropertyName("TaskPercentComplete")]
    public int? TaskPercentComplete { get; set; }

    [JsonPropertyName("LocationID")]
    public int? LocationID { get; set; }

    [JsonPropertyName("LocationName")]
    public string? LocationName { get; set; }

    [JsonPropertyName("LocationRoomID")]
    public int? LocationRoomID { get; set; }

    [JsonPropertyName("LocationRoomName")]
    public string? LocationRoomName { get; set; }

    [JsonPropertyName("RefCode")]
    public string? RefCode { get; set; }

    [JsonPropertyName("ServiceID")]
    public int? ServiceID { get; set; }

    [JsonPropertyName("ServiceName")]
    public string? ServiceName { get; set; }

    [JsonPropertyName("ServiceOfferingID")]
    public int? ServiceOfferingID { get; set; }

    [JsonPropertyName("ServiceOfferingName")]
    public string? ServiceOfferingName { get; set; }

    [JsonPropertyName("ServiceCategoryID")]
    public int? ServiceCategoryID { get; set; }

    [JsonPropertyName("ServiceCategoryName")]
    public string? ServiceCategoryName { get; set; }

    [JsonPropertyName("ArticleID")]
    public int? ArticleID { get; set; }

    [JsonPropertyName("ArticleSubject")]
    public string? ArticleSubject { get; set; }

    [JsonPropertyName("ArticleStatus")]
    public int? ArticleStatus { get; set; }

    [JsonPropertyName("ArticleCategoryPathNames")]
    public string? ArticleCategoryPathNames { get; set; }

    [JsonPropertyName("ArticleAppID")]
    public int? ArticleAppID { get; set; }

    [JsonPropertyName("ArticleShortcutID")]
    public object? ArticleShortcutID { get; set; }

    [JsonPropertyName("AppID")]
    public int? AppID { get; set; }

    [JsonPropertyName("Attributes")]
    public List<object>? Attributes { get; set; }

    [JsonPropertyName("Attachments")]
    public List<object>? Attachments { get; set; }

    [JsonPropertyName("Tasks")]
    public List<object>? Tasks { get; set; }

    [JsonPropertyName("Notify")]
    public List<Notify>? Notify { get; set; }

    [JsonPropertyName("WorkflowID")]
    public int? WorkflowID { get; set; }

    [JsonPropertyName("WorkflowConfigurationID")]
    public int? WorkflowConfigurationID { get; set; }

    [JsonPropertyName("WorkflowName")]
    public string? WorkflowName { get; set; }
}
