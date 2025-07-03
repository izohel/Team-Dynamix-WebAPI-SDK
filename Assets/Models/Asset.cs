using Newtonsoft.Json;
using TeamDynamix.Api.Attachments.Models;
using TeamDynamix.Api.CustomAttributes.Models;

namespace TeamDynamix.Api.Assets.Models;
/// <summary>
/// Represents an asset in the TeamDynamix system.
/// </summary>
public class Asset
{
    /// <summary>The ID of the asset.</summary>
    [JsonProperty("ID")]
    public int Id { get; set; }

    /// <summary>The ID of the asset/CI application containing the asset.</summary>
    [JsonProperty("AppID")]
    public int AppId { get; set; }

    /// <summary>The name of the asset/CI application containing the asset.</summary>
    [JsonProperty(nameof(AppName))]
    public string? AppName { get; set; }

    /// <summary>The ID of the form associated with the asset.</summary>
    [JsonProperty("FormID")]
    public int FormId { get; set; }

    /// <summary>The name of the form associated with the asset.</summary>
    [JsonProperty(nameof(FormName))]
    public string? FormName { get; set; }

    /// <summary>The ID of the product model associated with the asset.</summary>
    [JsonProperty("ProductModelID")]
    public int ProductModelId { get; set; }

    /// <summary>The name of the product model associated with the asset.</summary>
    [JsonProperty(nameof(ProductModelName))]
    public string? ProductModelName { get; set; }

    /// <summary>The ID of the manufacturer associated with the asset.</summary>
    [JsonProperty("ManufacturerID")]
    public int ManufacturerId { get; set; }

    /// <summary>The name of the manufacturer associated with the asset.</summary>
    [JsonProperty(nameof(ManufacturerName))]
    public string? ManufacturerName { get; set; }

    /// <summary>The ID of the supplier associated with the asset.</summary>
    [JsonProperty("SupplierID")]
    public int SupplierId { get; set; }

    /// <summary>The name of the supplier associated with the asset.</summary>
    [JsonProperty(nameof(SupplierName))]
    public string? SupplierName { get; set; }

    /// <summary>The ID of the status associated with the asset.</summary>
    [JsonProperty("StatusID")]
    public int StatusId { get; set; }

    /// <summary>The name of the status associated with the asset.</summary>
    [JsonProperty(nameof(StatusName))]
    public string? StatusName { get; set; }

    /// <summary>The ID of the location associated with the asset.</summary>
    [JsonProperty("LocationID")]
    public int LocationId { get; set; }

    /// <summary>The name of the location associated with the asset.</summary>
    [JsonProperty(nameof(LocationName))]
    public string? LocationName { get; set; }

    /// <summary>The ID of the location room associated with the asset.</summary>
    [JsonProperty("LocationRoomID")]
    public int LocationRoomId { get; set; }

    /// <summary>The name of the location room associated with the asset.</summary>
    [JsonProperty(nameof(LocationRoomName))]
    public string? LocationRoomName { get; set; }

    /// <summary>The service tag of the asset.</summary>
    [JsonProperty(nameof(Tag))]
    public string? Tag { get; set; }

    /// <summary>The serial number of the asset.</summary>
    [JsonProperty(nameof(SerialNumber))]
    public string? SerialNumber { get; set; }

    /// <summary>The name of the asset.</summary>
    [JsonProperty(nameof(Name))]
    public string? Name { get; set; }

    /// <summary>The purchase cost of the asset.</summary>
    [JsonProperty(nameof(PurchaseCost))]
    public double PurchaseCost { get; set; }

    /// <summary>The acquisition date of the asset.</summary>
    [JsonProperty(nameof(AcquisitionDate))]
    public DateTime AcquisitionDate { get; set; }

    /// <summary>The expected replacement date of the asset.</summary>
    [JsonProperty(nameof(ExpectedReplacementDate))]
    public DateTime ExpectedReplacementDate { get; set; }

    /// <summary>The UID of the requesting user associated with the asset.</summary>
    [JsonProperty("RequestingCustomerID")]
    public Guid RequestingCustomerId { get; set; }

    /// <summary>The name of the requesting user associated with the asset.</summary>
    [JsonProperty(nameof(RequestingCustomerName))]
    public string? RequestingCustomerName { get; set; }

    /// <summary>The ID of the requesting account/department associated with the asset.</summary>
    [JsonProperty("RequestingDepartmentID")]
    public int RequestingDepartmentId { get; set; }

    /// <summary>The name of the requesting account/department associated with the asset.</summary>
    [JsonProperty(nameof(RequestingDepartmentName))]
    public string? RequestingDepartmentName { get; set; }

    /// <summary>The UID of the owning user associated with the asset.</summary>
    [JsonProperty("OwningCustomerID")]
    public Guid OwningCustomerId { get; set; }

    /// <summary>The name of the owning user associated with the asset.</summary>
    [JsonProperty(nameof(OwningCustomerName))]
    public string? OwningCustomerName { get; set; }

    /// <summary>The ID of the owning account/department associated with the asset.</summary>
    [JsonProperty("OwningDepartmentID")]
    public int OwningDepartmentId { get; set; }

    /// <summary>The name of the owning account/department associated with the asset.</summary>
    [JsonProperty(nameof(OwningDepartmentName))]
    public string? OwningDepartmentName { get; set; }

    /// <summary>The ID of the parent associated with the asset.</summary>
    [JsonProperty("ParentID")]
    public int ParentId { get; set; }

    /// <summary>The serial number of the parent associated with the asset.</summary>
    [JsonProperty(nameof(ParentSerialNumber))]
    public string? ParentSerialNumber { get; set; }

    /// <summary>The name of the parent associated with the asset.</summary>
    [JsonProperty(nameof(ParentName))]
    public string? ParentName { get; set; }

    /// <summary>The service tag of the parent associated with the asset.</summary>
    [JsonProperty(nameof(ParentTag))]
    public string? ParentTag { get; set; }

    /// <summary>The ID of the maintenance window associated with the asset.</summary>
    [JsonProperty("MaintenanceScheduleID")]
    public int MaintenanceScheduleId { get; set; }

    /// <summary>The name of the maintenance window associated with the asset.</summary>
    [JsonProperty(nameof(MaintenanceScheduleName))]
    public string? MaintenanceScheduleName { get; set; }

    /// <summary>The ID of the configuration item record associated with the asset.</summary>
    [JsonProperty("ConfigurationItemID")]
    public int ConfigurationItemId { get; set; }

    /// <summary>The created date of the asset.</summary>
    [JsonProperty(nameof(CreatedDate))]
    public DateTime CreatedDate { get; set; }

    /// <summary>The UID of the user who created the asset.</summary>
    [JsonProperty("CreatedUID")]
    public Guid CreatedUid { get; set; }

    /// <summary>The full name of the user who created the asset.</summary>
    [JsonProperty(nameof(CreatedFullName))]
    public string? CreatedFullName { get; set; }

    /// <summary>The last modified date of the asset.</summary>
    [JsonProperty(nameof(ModifiedDate))]
    public DateTime ModifiedDate { get; set; }

    /// <summary>The UID of the user who last modified the asset.</summary>
    [JsonProperty("ModifiedUID")]
    public Guid ModifiedUid { get; set; }

    /// <summary>The full name of the user who last modified the asset.</summary>
    [JsonProperty(nameof(ModifiedFullName))]
    public string? ModifiedFullName { get; set; }

    /// <summary>The external ID of the asset used for mapping to external sources.</summary>
    [JsonProperty("ExternalID")]
    public string? ExternalId { get; set; }

    /// <summary>The ID of the configuration item source associated with the asset.</summary>
    [JsonProperty("ExternalSourceID")]
    public int ExternalSourceId { get; set; }

    /// <summary>The name of the configuration item source associated with the asset.</summary>
    [JsonProperty(nameof(ExternalSourceName))]
    public string? ExternalSourceName { get; set; }

    /// <summary>The custom attributes associated with the asset.</summary>
    [JsonProperty(nameof(Attributes))]
    public List<CustomAttribute>? Attributes { get; set; }

    /// <summary>The attachments associated with the asset.</summary>
    [JsonProperty(nameof(Attachments))]
    public List<Attachment>? Attachments { get; set; }

    /// <summary>The URI to retrieve full details of the asset via the API.</summary>
    [JsonProperty(nameof(Uri))]
    public string? Uri { get; set; }
}
