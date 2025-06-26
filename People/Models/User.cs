using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.People.Models;
public class User
{
#pragma warning disable CA1507 // Use nameof to express symbol names
    [JsonProperty("UID")]

    public string? Uid { get; set; }

    [JsonProperty("ReferenceID")]
    public int ReferenceId { get; set; }

    [JsonProperty("BEID")]
    public string? BeId { get; set; }

    [JsonProperty("BEIDInt")]
    public int BeIdInt { get; set; }

    [JsonProperty("IsActive")]
    public bool IsActive { get; set; }

    [JsonProperty("IsConfidential")]
    public bool IsConfidential { get; set; }

    [JsonProperty("UserName")]
    public string? UserName { get; set; }

    [JsonProperty("FullName")]
    public string? FullName { get; set; }

    [JsonProperty("FirstName")]
    public string? FirstName { get; set; }

    [JsonProperty("LastName")]
    public string? LastName { get; set; }

    [JsonProperty("MiddleName")]
    public string? MiddleName { get; set; }

    [JsonProperty("Salutation")]
    public string? Salutation { get; set; }

    [JsonProperty("Nickname")]
    public string? Nickname { get; set; }

    [JsonProperty("DefaultAccountID")]
    public int DefaultAccountId { get; set; }

    [JsonProperty("DefaultAccountName")]
    public string? DefaultAccountName { get; set; }

    [JsonProperty("PrimaryEmail")]
    public string? PrimaryEmail { get; set; }

    [JsonProperty("AlternateEmail")]
    public string? AlternateEmail { get; set; }

    [JsonProperty("ExternalID")]
    public string? ExternalId { get; set; }

    [JsonProperty("AlternateID")]
    public string? AlternateId { get; set; }

    [JsonProperty("Applications")]
    public List<object>? Applications { get; set; }

    [JsonProperty("SecurityRoleName")]
    public string? SecurityRoleName { get; set; }

    [JsonProperty("SecurityRoleID")]
    public string? SecurityRoleId { get; set; }

    [JsonProperty("Permissions")]
    public List<object>? Permissions { get; set; }

    [JsonProperty("OrgApplications")]
    public object? OrgApplications { get; set; }

    [JsonProperty("PrimaryClientPortalApplicationID")]
    public object? PrimaryClientPortalApplicationId { get; set; }

    [JsonProperty("GroupIDs")]
    public List<object>? GroupIds { get; set; }

    [JsonProperty("AlertEmail")]
    public string? AlertEmail { get; set; }

    [JsonProperty("ProfileImageFileName")]
    public string? ProfileImageFileName { get; set; }

    [JsonProperty("Company")]
    public string? Company { get; set; }

    [JsonProperty("Title")]
    public string? Title { get; set; }

    [JsonProperty("HomePhone")]
    public string? HomePhone { get; set; }

    [JsonProperty("PrimaryPhone")]
    public string? PrimaryPhone { get; set; }

    [JsonProperty("WorkPhone")]
    public string? WorkPhone { get; set; }

    [JsonProperty("Pager")]
    public string? Pager { get; set; }

    [JsonProperty("OtherPhone")]
    public string? OtherPhone { get; set; }

    [JsonProperty("MobilePhone")]
    public string? MobilePhone { get; set; }

    [JsonProperty("Fax")]
    public string? Fax { get; set; }

    [JsonProperty("DefaultPriorityID")]
    public int DefaultPriorityID { get; set; }

    [JsonProperty("DefaultPriorityName")]
    public string? DefaultPriorityName { get; set; }

    [JsonProperty("AboutMe")]
    public string? AboutMe { get; set; }

    [JsonProperty("TechnicianSignature")]
    public object? TechnicianSignature { get; set; }

    [JsonProperty("ApplyTechnicianSignatureToUpdatesAndComments")]
    public bool ApplyTechnicianSignatureToUpdatesAndComments { get; set; }

    [JsonProperty("ApplyTechnicianSignatureToReplies")]
    public bool ApplyTechnicianSignatureToReplies { get; set; }

    [JsonProperty("WorkAddress")]
    public string? WorkAddress { get; set; }

    [JsonProperty("WorkCity")]
    public string? WorkCity { get; set; }

    [JsonProperty("WorkState")]
    public string? WorkState { get; set; }

    [JsonProperty("WorkZip")]
    public string? WorkZip { get; set; }

    [JsonProperty("WorkCountry")]
    public string? WorkCountry { get; set; }

    [JsonProperty("HomeAddress")]
    public string? HomeAddress { get; set; }

    [JsonProperty("HomeCity")]
    public string? HomeCity { get; set; }

    [JsonProperty("HomeState")]
    public string? HomeState { get; set; }

    [JsonProperty("HomeZip")]
    public string? HomeZip { get; set; }

    [JsonProperty("HomeCountry")]
    public string? HomeCountry { get; set; }

    [JsonProperty("LocationID")]
    public int LocationID { get; set; }

    [JsonProperty("LocationName")]
    public object? LocationName { get; set; }

    [JsonProperty("LocationRoomID")]
    public int LocationRoomID { get; set; }

    [JsonProperty("LocationRoomName")]
    public object? LocationRoomName { get; set; }

    [JsonProperty("DefaultRate")]
    public double DefaultRate { get; set; }

    [JsonProperty("CostRate")]
    public double CostRate { get; set; }

    [JsonProperty("IsEmployee")]
    public bool IsEmployee { get; set; }

    [JsonProperty("WorkableHours")]
    public double WorkableHours { get; set; }

    [JsonProperty("IsCapacityManaged")]
    public bool IsCapacityManaged { get; set; }

    [JsonProperty("ReportTimeAfterDate")]
    public DateTime ReportTimeAfterDate { get; set; }

    [JsonProperty("EndDate")]
    public DateTime EndDate { get; set; }

    [JsonProperty("ShouldReportTime")]
    public bool ShouldReportTime { get; set; }

    [JsonProperty("ReportsToUID")]
    public string? ReportsToUid { get; set; }

    [JsonProperty("ReportsToFullName")]
    public string? ReportsToFullName { get; set; }

    [JsonProperty("ResourcePoolID")]
    public int ResourcePoolId { get; set; }

    [JsonProperty("ResourcePoolName")]
    public string? ResourcePoolName { get; set; }

    [JsonProperty("TZID")]
    public int Tzid { get; set; }

    [JsonProperty("TZName")]
    public string? TzName { get; set; }

    [JsonProperty("TypeID")]
    public int TypeId { get; set; }

    [JsonProperty("AuthenticationUserName")]
    public string? AuthenticationUserName { get; set; }

    [JsonProperty("AuthenticationProviderID")]
    public int AuthenticationProviderId { get; set; }

    [JsonProperty("Attributes")]
    public List<object>? Attributes { get; set; }

    [JsonProperty("IMProvider")]
    public string? ImProvider { get; set; }

    [JsonProperty("IMHandle")]
    public string? ImHandle { get; set; }
}
#pragma warning restore CA1507 // Use nameof to express symbol names
