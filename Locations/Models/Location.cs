using Newtonsoft.Json;
using TeamDynamix.Api.CustomAttributes.Models;

namespace TeamDynamix.Api.Locations.Models;
/// <summary>
/// Represents a physical or virtual location in the TeamDynamix system.
/// </summary>
public class Location
{
    /// <summary>The ID of the location.</summary>
    [JsonProperty("ID")]
    public int Id { get; set; }

    /// <summary>The name of the location.</summary>
    [JsonProperty(nameof(Name))]
    public string Name { get; set; } = null!;

    /// <summary>The description of the location.</summary>
    [JsonProperty(nameof(Description))]
    public string? Description { get; set; }

    /// <summary>The external ID of the location.</summary>
    [JsonProperty("ExternalID")]
    public string? ExternalId { get; set; }

    /// <summary>The active status of the location.</summary>
    [JsonProperty(nameof(IsActive))]
    public bool IsActive { get; set; }

    /// <summary>The address of the location.</summary>
    [JsonProperty(nameof(Address))]
    public string? Address { get; set; }

    /// <summary>The city of the location.</summary>
    [JsonProperty(nameof(City))]
    public string? City { get; set; }

    /// <summary>The state/province of the location.</summary>
    [JsonProperty(nameof(State))]
    public string? State { get; set; }

    /// <summary>The postal code of the location.</summary>
    [JsonProperty(nameof(PostalCode))]
    public string? PostalCode { get; set; }

    /// <summary>The country of the location.</summary>
    [JsonProperty(nameof(Country))]
    public string? Country { get; set; }

    /// <summary>Whether the location requires a room when specified for an asset.</summary>
    [JsonProperty(nameof(IsRoomRequired))]
    public bool IsRoomRequired { get; set; }

    /// <summary>The custom attributes associated with the location.</summary>
    [JsonProperty(nameof(Attributes))]
    public CustomAttribute[]? Attributes { get; set; }

    /// <summary>The number of assets associated with the location.</summary>
    [JsonProperty(nameof(AssetsCount))]
    public int AssetsCount { get; set; }

    /// <summary>The number of standalone configuration items associated with the location.</summary>
    [JsonProperty(nameof(ConfigurationItemsCount))]
    public int ConfigurationItemsCount { get; set; }

    /// <summary>The number of tickets associated with the location.</summary>
    [JsonProperty(nameof(TicketsCount))]
    public int TicketsCount { get; set; }

    /// <summary>The number of rooms associated with the location.</summary>
    [JsonProperty(nameof(RoomsCount))]
    public int RoomsCount { get; set; }

    /// <summary>The number of users associated with the location.</summary>
    [JsonProperty(nameof(UsersCount))]
    public int UsersCount { get; set; }

    /// <summary>The rooms associated with the location. The custom attributes for each room will not be retrieved.</summary>
    [JsonProperty(nameof(Rooms))]
    public LocationRoom[]? Rooms { get; set; }

    /// <summary>The created date of the location.</summary>
    [JsonProperty(nameof(CreatedDate))]
    public DateTime CreatedDate { get; set; }

    /// <summary>The UID of the user who created the location.</summary>
    [JsonProperty("CreatedUID")]
    public Guid CreatedUid { get; set; }

    /// <summary>The full name of the user who created the location.</summary>
    [JsonProperty(nameof(CreatedFullName))]
    public string CreatedFullName { get; set; } = null!;

    /// <summary>The last modified date of the location.</summary>
    [JsonProperty(nameof(ModifiedDate))]
    public DateTime ModifiedDate { get; set; }

    /// <summary>The UID of the user who last modified the location.</summary>
    [JsonProperty("ModifiedUID")]
    public Guid ModifiedUid { get; set; }

    /// <summary>The full name of the user who last modified the location.</summary>
    [JsonProperty(nameof(ModifiedFullName))]
    public string ModifiedFullName { get; set; } = null!;

    /// <summary>The latitude of the location.</summary>
    [JsonProperty(nameof(Latitude))]
    public decimal? Latitude { get; set; }

    /// <summary>The longitude of the location.</summary>
    [JsonProperty(nameof(Longitude))]
    public decimal? Longitude { get; set; }
}

