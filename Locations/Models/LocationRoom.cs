using TeamDynamix.Api.CustomAttributes.Models;

namespace TeamDynamix.Api.Locations.Models;

/// <summary>
/// Represents a room at a specific location in the TeamDynamix system.
/// </summary>
public class LocationRoom
{
    /// <summary>
    /// Gets or sets the ID of the location room.
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Gets or sets the name of the location room.
    /// This field is required and editable through the API.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the external ID of the location room.
    /// This field is editable and nullable.
    /// </summary>
    public string? ExternalID { get; set; }

    /// <summary>
    /// Gets or sets the description of the location room.
    /// This field is editable and nullable.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the floor information associated with the location room.
    /// This field is editable and nullable.
    /// </summary>
    public string? Floor { get; set; }

    /// <summary>
    /// Gets or sets the capacity of the location room.
    /// This field is editable and nullable.
    /// </summary>
    public int? Capacity { get; set; }

    /// <summary>
    /// Gets or sets the number of assets associated with the location room.
    /// </summary>
    public int AssetsCount { get; set; }

    /// <summary>
    /// Gets or sets the number of configuration items associated with the location room.
    /// </summary>
    public int ConfigurationItemsCount { get; set; }

    /// <summary>
    /// Gets or sets the number of tickets associated with the location room.
    /// </summary>
    public int TicketsCount { get; set; }

    /// <summary>
    /// Gets or sets the number of users associated with the location room.
    /// </summary>
    public int UsersCount { get; set; }

    /// <summary>
    /// Gets or sets the date the location room was created.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the UID of the user who created the location room.
    /// </summary>
    public Guid CreatedUID { get; set; }

    /// <summary>
    /// Gets or sets the full name of the user who created the location room.
    /// </summary>
    public string CreatedFullName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the custom attributes associated with the location room.
    /// This field is editable and nullable.
    /// </summary>
    public List<CustomAttribute>? Attributes { get; set; }
}