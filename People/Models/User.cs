using Itsm.Tdx.WebApi.CustomAttributes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.People.Models;
/// <summary>
/// Represents a user in the TeamDynamix system.
/// </summary>
public class User
{
    /// <summary>
    /// The UID of the user.
    /// </summary>
    [JsonProperty("UID")]
    public required string Uid { get; set; }

    /// <summary>
    /// The integer ID of the user.
    /// </summary>
    [JsonProperty("ReferenceID")]
    public int ReferenceId { get; set; }

    /// <summary>
    /// The UID of the organization associated with the user.
    /// </summary>
    [JsonProperty("BEID")]
    public string? BeId { get; set; }

    /// <summary>
    /// The integer ID of the organization associated with the user.
    /// </summary>
    [JsonProperty("BEIDInt")]
    public int BeIdInt { get; set; }

    /// <summary>
    /// The active status of the user. Editable via API.
    /// </summary>
    [JsonProperty(nameof(IsActive))]
    public bool IsActive { get; set; }

    /// <summary>
    /// The confidential status of the user. Editable via API.
    /// </summary>
    [JsonProperty(nameof(IsConfidential))]
    public bool IsConfidential { get; set; }

    /// <summary>
    /// The username of the user.
    /// </summary>
    [JsonProperty(nameof(UserName))]
    public required string UserName { get; set; }

    /// <summary>
    /// The full name of the user.
    /// </summary>
    [JsonProperty(nameof(FullName))]
    public string? FullName { get; set; }

    /// <summary>
    /// The first name of the user. Editable via API. Required.
    /// </summary>
    [JsonProperty(nameof(FirstName))]
    public string? FirstName { get; set; }

    /// <summary>
    /// The last name of the user. Editable via API. Required.
    /// </summary>
    [JsonProperty(nameof(LastName))]
    public string? LastName { get; set; }

    /// <summary>
    /// The middle name of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(MiddleName))]
    public string? MiddleName { get; set; }

    /// <summary>
    /// The salutation of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(Salutation))]
    public string? Salutation { get; set; }

    /// <summary>
    /// The nickname of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(Nickname))]
    public string? Nickname { get; set; }

    /// <summary>
    /// The ID of the default account/department associated with the user. Editable via API.
    /// </summary>
    [JsonProperty("DefaultAccountID")]
    public int DefaultAccountId { get; set; }

    /// <summary>
    /// The name of the default account/department associated with the user.
    /// </summary>
    [JsonProperty(nameof(DefaultAccountName))]
    public string? DefaultAccountName { get; set; }

    /// <summary>
    /// The primary email address of the user. Editable via API. Required.
    /// </summary>
    [JsonProperty(nameof(PrimaryEmail))]
    public required string PrimaryEmail { get; set; }

    /// <summary>
    /// The alternate email address of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(AlternateEmail))]
    public string? AlternateEmail { get; set; }

    /// <summary>
    /// The organizational ID of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty("ExternalID")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// The alternate ID of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty("AlternateID")]
    public string? AlternateId { get; set; }

    /// <summary>
    /// The system-defined (non-platform) applications associated with the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(Applications))]
    public List<string>? Applications { get; set; }

    /// <summary>
    /// The name of the global security role associated with the user.
    /// </summary>
    [JsonProperty(nameof(SecurityRoleName))]
    public string? SecurityRoleName { get; set; }

    /// <summary>
    /// The UID of the global security role associated with the user. Editable via API.
    /// </summary>
    [JsonProperty("SecurityRoleID")]
    public string? SecurityRoleId { get; set; }

    /// <summary>
    /// The global security role permissions associated with the user. Nullable.
    /// </summary>
    [JsonProperty(nameof(Permissions))]
    public List<string>? Permissions { get; set; }

    /// <summary>
    /// The organizationally-defined (platform) applications associated with the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(OrgApplications))]
    public List<Apps.Models.UserApplication>? OrgApplications { get; set; }

    /// <summary>
    /// The ID of the primary client portal application associated with the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty("PrimaryClientPortalApplicationID")]
    public int? PrimaryClientPortalApplicationId { get; set; }

    /// <summary>
    /// The IDs of the groups associated with the user. Nullable.
    /// </summary>
    [JsonProperty("GroupIDs")]
    public List<int>? GroupIds { get; set; }

    /// <summary>
    /// The alert email address of the user where system notifications are delivered. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(AlertEmail))]
    public string? AlertEmail { get; set; }

    /// <summary>
    /// The profile image file name of the user.
    /// </summary>
    [JsonProperty(nameof(ProfileImageFileName))]
    public string? ProfileImageFileName { get; set; }

    /// <summary>
    /// The company of the user. Editable via API. Required.
    /// </summary>
    [JsonProperty(nameof(Company))]
    public string? Company { get; set; }

    /// <summary>
    /// The title of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(Title))]
    public string? Title { get; set; }

    /// <summary>
    /// The home phone number of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(HomePhone))]
    public string? HomePhone { get; set; }

    /// <summary>
    /// The primary phone number of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(PrimaryPhone))]
    public string? PrimaryPhone { get; set; }

    /// <summary>
    /// The work phone number of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(WorkPhone))]
    public string? WorkPhone { get; set; }

    /// <summary>
    /// The pager number of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(Pager))]
    public string? Pager { get; set; }

    /// <summary>
    /// The other phone number of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(OtherPhone))]
    public string? OtherPhone { get; set; }

    /// <summary>
    /// The mobile phone number of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(MobilePhone))]
    public string? MobilePhone { get; set; }

    /// <summary>
    /// The fax number of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(Fax))]
    public string? Fax { get; set; }

    /// <summary>
    /// The ID of the default priority associated with the user. Editable via API.
    /// </summary>
    [JsonProperty(nameof(DefaultPriorityID))]
    public int DefaultPriorityID { get; set; }

    /// <summary>
    /// The name of the default priority associated with the user.
    /// </summary>
    [JsonProperty(nameof(DefaultPriorityName))]
    public string? DefaultPriorityName { get; set; }

    /// <summary>
    /// The "About Me" information associated with the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(AboutMe))]
    public string? AboutMe { get; set; }

    /// <summary>
    /// The technician signature associated with the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(TechnicianSignature))]
    public string? TechnicianSignature { get; set; }

    /// <summary>
    /// Determines whether the technician signature is applied to the updates and comments for all tickets and ticket tasks. Editable via API.
    /// </summary>
    [JsonProperty(nameof(ApplyTechnicianSignatureToUpdatesAndComments))]
    public bool ApplyTechnicianSignatureToUpdatesAndComments { get; set; }

    /// <summary>
    /// Determines whether the technician signature is applied to the replies for all tickets and ticket tasks. Editable via API.
    /// </summary>
    [JsonProperty(nameof(ApplyTechnicianSignatureToReplies))]
    public bool ApplyTechnicianSignatureToReplies { get; set; }

    /// <summary>
    /// The work address of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(WorkAddress))]
    public string? WorkAddress { get; set; }

    /// <summary>
    /// The work city of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(WorkCity))]
    public string? WorkCity { get; set; }

    /// <summary>
    /// The work state abbreviation of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(WorkState))]
    public string? WorkState { get; set; }

    /// <summary>
    /// The work zip code of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(WorkZip))]
    public string? WorkZip { get; set; }

    /// <summary>
    /// The work country of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(WorkCountry))]
    public string? WorkCountry { get; set; }

    /// <summary>
    /// The home address of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(HomeAddress))]
    public string? HomeAddress { get; set; }

    /// <summary>
    /// The home city of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(HomeCity))]
    public string? HomeCity { get; set; }

    /// <summary>
    /// The home state abbreviation of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(HomeState))]
    public string? HomeState { get; set; }

    /// <summary>
    /// The home zip code of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(HomeZip))]
    public string? HomeZip { get; set; }

    /// <summary>
    /// The home country of the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(HomeCountry))]
    public string? HomeCountry { get; set; }

    /// <summary>
    /// The ID of the location associated with the user. Editable via API.
    /// </summary>
    [JsonProperty("LocationID")]
    public int LocationId { get; set; }

    /// <summary>
    /// The name of the location associated with the user.
    /// </summary>
    [JsonProperty(nameof(LocationName))]
    public string? LocationName { get; set; }

    /// <summary>
    /// The ID of the location room associated with the user. Editable via API.
    /// </summary>
    [JsonProperty("LocationRoomID")]
    public int LocationRoomId { get; set; }

    /// <summary>
    /// The name of the location room associated with the user.
    /// </summary>
    [JsonProperty(nameof(LocationRoomName))]
    public string? LocationRoomName { get; set; }

    /// <summary>
    /// The default bill rate of the user. Editable via API.
    /// </summary>
    [JsonProperty(nameof(DefaultRate))]
    public double DefaultRate { get; set; }

    /// <summary>
    /// The cost rate of the user. Editable via API.
    /// </summary>
    [JsonProperty(nameof(CostRate))]
    public double CostRate { get; set; }

    /// <summary>
    /// The employee status of the user. Editable via API.
    /// </summary>
    [JsonProperty(nameof(IsEmployee))]
    public bool IsEmployee { get; set; }

    /// <summary>
    /// The number of workable hours in a work day for the user. Editable via API.
    /// </summary>
    [JsonProperty(nameof(WorkableHours))]
    public double WorkableHours { get; set; }

    /// <summary>
    /// Whether the user's capacity is managed, meaning they can have capacity and appear on capacity/availability reports. Editable via API.
    /// </summary>
    [JsonProperty(nameof(IsCapacityManaged))]
    public bool IsCapacityManaged { get; set; }

    /// <summary>
    /// The date after which the user should start reporting time, also governs capacity calculations. Editable via API.
    /// </summary>
    [JsonProperty(nameof(ReportTimeAfterDate))]
    public DateTime ReportTimeAfterDate { get; set; }

    /// <summary>
    /// The date after which the user is no longer available for scheduling and no longer required to log time. Editable via API.
    /// </summary>
    [JsonProperty(nameof(EndDate))]
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Whether the user should report time. Editable via API.
    /// </summary>
    [JsonProperty(nameof(ShouldReportTime))]
    public bool ShouldReportTime { get; set; }

    /// <summary>
    /// The UID of the person who the user reports to. Editable via API. Nullable.
    /// </summary>
    [JsonProperty("ReportsToUID")]
    public string? ReportsToUid { get; set; }

    /// <summary>
    /// The full name of the person who the user reports to.
    /// </summary>
    [JsonProperty(nameof(ReportsToFullName))]
    public string? ReportsToFullName { get; set; }

    /// <summary>
    /// The ID of the resource pool associated with the user. Editable via API.
    /// </summary>
    [JsonProperty(nameof(ResourcePoolID))]
    public int ResourcePoolID { get; set; }

    /// <summary>
    /// The name of the resource pool associated with the user.
    /// </summary>
    [JsonProperty(nameof(ResourcePoolName))]
    public string? ResourcePoolName { get; set; }

    /// <summary>
    /// The ID of the time zone associated with the user. Editable via API.
    /// </summary>
    [JsonProperty("TZID")]
    public int Tzid { get; set; }

    /// <summary>
    /// The name of the time zone associated with the user.
    /// </summary>
    [JsonProperty("TZName")]
    public string? TzName { get; set; }

    /// <summary>
    /// The type of the user.
    /// </summary>
    [JsonProperty("TypeID")]
    public UserType TypeId { get; set; }

    /// <summary>
    /// The authentication username of the user, used for authenticating with non-TeamDynamix authentication types. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(AuthenticationUserName))]
    public string? AuthenticationUserName { get; set; }

    /// <summary>
    /// The ID of the authentication provider the new user will use for authentication. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(AuthenticationProviderID))]
    public int? AuthenticationProviderID { get; set; }

    /// <summary>
    /// The custom attributes associated with the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(Attributes))]
    public List<CustomAttribute>? Attributes { get; set; }

    /// <summary>
    /// The Instant Messenger (IM) provider associated with the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(IMProvider))]
    public string? IMProvider { get; set; }

    /// <summary>
    /// The Instant Messenger (IM) username/handle associated with the user. Editable via API. Nullable.
    /// </summary>
    [JsonProperty(nameof(IMHandle))]
    public string? IMHandle { get; set; }
}
