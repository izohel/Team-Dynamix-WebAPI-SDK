using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TeamDynamix.Api.CustomAttributes.Models;

namespace TeamDynamix.Api.Assets.Models;
/// <summary>
/// A set of filtering options used for searching assets.
/// </summary>
public class AssetSearchOptions
{
    /// <summary>
    /// The text to perform a LIKE search on the asset serial number and service tag.
    /// </summary>
    [JsonProperty(nameof(SerialLike))]
    public string? SerialLike { get; set; }

    /// <summary>
    /// The search text to filter on. When specified, results will be sorted by their text relevancy.
    /// </summary>
    /// <remarks>
    /// Pass an empty string to return everything
    /// </remarks>
    [JsonProperty(nameof(SearchText))]
    public string? SearchText { get; set; }

    /// <summary>
    /// The ID of the saved search associated with this search.
    /// </summary>
    [JsonProperty("SavedSearchID")]
    public int SavedSearchId { get; set; }

    /// <summary>
    /// The current status IDs to filter on.
    /// </summary>
    [JsonProperty("StatusIDs")]
    public int[]? StatusIds { get; set; }

    /// <summary>
    /// The external IDs to filter on.
    /// </summary>
    [JsonProperty("ExternalIds")]
    public string[]? ExternalIDs { get; set; }

    /// <summary>
    /// The "in service" status to filter on.
    /// </summary>
    [JsonProperty(nameof(IsInService))]
    public bool? IsInService { get; set; }

    /// <summary>
    /// The past status IDs to filter on.
    /// </summary>
    [JsonProperty("StatusIDsPast")]
    public int[]? StatusIdsPast { get; set; }

    /// <summary>
    /// The supplier IDs to filter on.
    /// </summary>
    [JsonProperty("SupplierIDs")]
    public int[]? SupplierIds { get; set; }

    /// <summary>
    /// The manufacturer IDs to filter on.
    /// </summary>
    [JsonProperty("ManufacturerIDs")]
    public int[]? ManufacturerIds { get; set; }

    /// <summary>
    /// The location IDs to filter on.
    /// </summary>
    [JsonProperty("LocationIDs")]
    public int[]? LocationIds { get; set; }

    /// <summary>
    /// The location room ID to filter on.
    /// </summary>
    [JsonProperty("RoomID")]
    public int RoomId { get; set; }

    /// <summary>
    /// The parent asset IDs to filter on.
    /// </summary>
    [JsonProperty("ParentIDs")]
    public int[]? ParentIds { get; set; }

    /// <summary>
    /// The contract IDs to filter on.
    /// </summary>
    [JsonProperty("ContractIDs")]
    public int[]? ContractIds { get; set; }

    /// <summary>
    /// The contract IDs to exclude on.
    /// </summary>
    [JsonProperty("ExcludeContractIDs")]
    public int[]? ExcludeContractIds { get; set; }

    /// <summary>
    /// The ticket IDs to filter on.
    /// </summary>
    [JsonProperty("TicketIDs")]
    public int[]? TicketIds { get; set; }

    /// <summary>
    /// The ticket IDs to exclude on.
    /// </summary>
    [JsonProperty("ExcludeTicketIDs")]
    public int[]? ExcludeTicketIds { get; set; }

    /// <summary>
    /// The form IDs to filter on.
    /// </summary>
    [JsonProperty("FormIDs")]
    public int[]? FormIds { get; set; }

    /// <summary>
    /// The product model IDs to filter on.
    /// </summary>
    [JsonProperty("ProductModelIDs")]
    public int[]? ProductModelIds { get; set; }

    /// <summary>
    /// The maintenance window IDs to filter on.
    /// </summary>
    [JsonProperty("MaintenanceScheduleIDs")]
    public int[]? MaintenanceScheduleIds { get; set; }

    /// <summary>
    /// The using account/department IDs to filter on.
    /// </summary>
    [JsonProperty("UsingDepartmentIDs")]
    public int[]? UsingDepartmentIds { get; set; }

    /// <summary>
    /// The requesting account/department IDs to filter on.
    /// </summary>
    [JsonProperty("RequestingDepartmentIDs")]
    public int[]? RequestingDepartmentIds { get; set; }

    /// <summary>
    /// The owning account/department IDs to filter on.
    /// </summary>
    [JsonProperty("OwningDepartmentIDs")]
    public int[]? OwningDepartmentIds { get; set; }

    /// <summary>
    /// The past owning account/department IDs to filter on.
    /// </summary>
    [JsonProperty("OwningDepartmentIDsPast")]
    public int[]? OwningDepartmentIdsPast { get; set; }

    /// <summary>
    /// The using person UIDs to filter on.
    /// </summary>
    [JsonProperty("UsingCustomerIDs")]
    public Guid[]? UsingCustomerIds { get; set; }

    /// <summary>
    /// The requestor UIDs to filter on.
    /// </summary>
    [JsonProperty("RequestingCustomerIDs")]
    public Guid[]? RequestingCustomerIds { get; set; }

    /// <summary>
    /// The owner UIDs to filter on.
    /// </summary>
    [JsonProperty("OwningCustomerIDs")]
    public Guid[]? OwningCustomerIds { get; set; }

    /// <summary>
    /// The past owner UIDs to filter on.
    /// </summary>
    [JsonProperty("OwningCustomerIDsPast")]
    public Guid[]? OwningCustomerIdsPast { get; set; }

    /// <summary>
    /// The custom attributes to filter on.
    /// </summary>
    [JsonProperty(nameof(CustomAttributes))]
    public List<CustomAttribute>? CustomAttributes { get; set; }

    /// <summary>
    /// The minimum purchase cost to filter on.
    /// </summary>
    [JsonProperty(nameof(PurchaseCostFrom))]
    public double PurchaseCostFrom { get; set; }

    /// <summary>
    /// The maximum purchase cost to filter on.
    /// </summary>
    [JsonProperty(nameof(PurchaseCostTo))]
    public double PurchaseCostTo { get; set; }

    /// <summary>
    /// The contract provider ID to filter on.
    /// </summary>
    [JsonProperty("ContractProviderID")]
    public int ContractProviderId { get; set; }

    /// <summary>
    /// The minimum acquisition date to filter on.
    /// </summary>
    [JsonProperty(nameof(AcquisitionDateFrom))]
    public DateTime AcquisitionDateFrom { get; set; }

    /// <summary>
    /// The maximum acquisition date to filter on.
    /// </summary>
    [JsonProperty(nameof(AcquisitionDateTo))]
    public DateTime AcquisitionDateTo { get; set; }

    /// <summary>
    /// The minimum expected replacement date to filter on.
    /// </summary>
    [JsonProperty(nameof(ExpectedReplacementDateFrom))]
    public DateTime ExpectedReplacementDateFrom { get; set; }

    /// <summary>
    /// The maximum expected replacement date to filter on.
    /// </summary>
    [JsonProperty(nameof(ExpectedReplacementDateTo))]
    public DateTime ExpectedReplacementDateTo { get; set; }

    /// <summary>
    /// The minimum contract end date to filter on.
    /// </summary>
    [JsonProperty(nameof(ContractEndDateFrom))]
    public DateTime ContractEndDateFrom { get; set; }

    /// <summary>
    /// The maximum contract end date to filter on.
    /// </summary>
    [JsonProperty(nameof(ContractEndDateTo))]
    public DateTime ContractEndDateTo { get; set; }

    /// <summary>
    /// The minimum created date to filter on.
    /// </summary>
    [JsonProperty(nameof(CreatedDateFrom))]
    public DateTime CreatedDateFrom { get; set; }

    /// <summary>
    /// The maximum created date to filter on.
    /// </summary>
    [JsonProperty(nameof(CreatedDateTo))]
    public DateTime CreatedDateTo { get; set; }

    /// <summary>
    /// The minimum modified date to filter on.
    /// </summary>
    [JsonProperty(nameof(ModifiedDateFrom))]
    public DateTime ModifiedDateFrom { get; set; }

    /// <summary>
    /// The maximum modified date to filter on.
    /// </summary>
    [JsonProperty(nameof(ModifiedDateTo))]
    public DateTime ModifiedDateTo { get; set; }

    /// <summary>
    /// Whether only parent assets should be returned.
    /// </summary>
    [JsonProperty(nameof(OnlyParentAssets))]
    public bool OnlyParentAssets { get; set; }

    /// <summary>
    /// The maximum number of records to return.
    /// </summary>
    /// <remarks> 
    /// As a note when using this: The TDX API does not offer paging
    /// </remarks>
    [JsonProperty(nameof(MaxResults))]
    public int? MaxResults { get; set; }
}
