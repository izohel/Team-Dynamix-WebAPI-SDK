using Itsm.Tdx.WebApi.CustomAttributes.Models;
using Newtonsoft.Json;


namespace Itsm.Tdx.WebApi.Accounts.Models;
/// <summary>
/// 
/// </summary>
public class Account
{
    /// <summary>
    /// The ID of the account.
    /// </summary>
    [JsonProperty("ID")]
    public required int Id { get; set; }

    /// <summary>
    /// The name of the account. This field is required and editable via the API.
    /// </summary>
    [JsonProperty(nameof(Name))]
    public string? Name { get; set; }

    /// <summary>
    /// The ID of the parent associated with the account, or null if the account has no parent. Editable via the API.
    /// </summary>
    [JsonProperty("ParentID")]
    public int? ParentId { get; set; }

    /// <summary>
    /// The name of the parent associated with the account, or null if the account has no parent.
    /// </summary>
    [JsonProperty(nameof(ParentName))]
    public string? ParentName { get; set; }

    /// <summary>
    /// The active status of the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(IsActive))]
    public bool IsActive { get; set; }

    /// <summary>
    /// The first address line of the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(Address1))]
    public string? Address1 { get; set; }

    /// <summary>
    /// The second address line of the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(Address2))]
    public string? Address2 { get; set; }

    /// <summary>
    /// The third address line of the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(Address3))]
    public string? Address3 { get; set; }

    /// <summary>
    /// The fourth address line of the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(Address4))]
    public string? Address4 { get; set; }

    /// <summary>
    /// The city of the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(City))]
    public string? City { get; set; }

    /// <summary>
    /// The state/province of the account.
    /// </summary>
    [JsonProperty(nameof(StateName))]
    public string? StateName { get; set; }

    /// <summary>
    /// The abbreviation of the state/province associated with the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(StateAbbr))]
    public string? StateAbbr { get; set; }

    /// <summary>
    /// The postal code of the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(PostalCode))]
    public string? PostalCode { get; set; }

    /// <summary>
    /// The country of the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(Country))]
    public string? Country { get; set; }

    /// <summary>
    /// The phone number of the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(Phone))]
    public string? Phone { get; set; }

    /// <summary>
    /// The fax number of the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(Fax))]
    public string? Fax { get; set; }

    /// <summary>
    /// The website URL of the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(Url))]
    public string? Url { get; set; }

    /// <summary>
    /// Notes for the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(Notes))]
    public string? Notes { get; set; }

    /// <summary>
    /// The date the account was created.
    /// </summary>
    [JsonProperty(nameof(CreatedDate))]
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// The last modified date of the account.
    /// </summary>
    [JsonProperty(nameof(ModifiedDate))]
    public DateTime ModifiedDate { get; set; }

    /// <summary>
    /// The code for the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(Code))]
    public string? Code { get; set; }

    /// <summary>
    /// The ID of the industry associated with the account. Editable via the API.
    /// </summary>
    [JsonProperty("IndustryID")]
    public int IndustryId { get; set; }

    /// <summary>
    /// The name of the industry associated with the account.
    /// </summary>
    [JsonProperty(nameof(IndustryName))]
    public string? IndustryName { get; set; }

    /// <summary>
    /// The UID of the manager for the account. Editable via the API.
    /// </summary>
    [JsonProperty("ManagerUID")]
    public string? ManagerUid { get; set; }

    /// <summary>
    /// The full name of the manager for the account.
    /// </summary>
    [JsonProperty(nameof(ManagerFullName))]
    public string? ManagerFullName { get; set; }

    /// <summary>
    /// The custom attributes of the account. Editable via the API.
    /// </summary>
    [JsonProperty(nameof(Attributes))]
    public List<CustomAttribute>? Attributes { get; set; }
}
