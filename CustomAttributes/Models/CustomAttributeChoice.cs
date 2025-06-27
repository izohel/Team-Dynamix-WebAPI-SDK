using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.CustomAttributes.Models;

/// <summary>
/// Represents a selectable choice for a custom attribute in the TeamDynamix system.
/// </summary>
public class CustomAttributeChoice
{
    /// <summary>
    /// The ID of the attribute choice.
    /// </summary>
    [JsonProperty("ID")]
    public int Id { get; set; }

    /// <summary>
    /// The name of the attribute choice. This doubles as the display text.
    /// Editable via the API. Required.
    /// </summary>
    [JsonProperty(nameof(Name))]
    public string? Name { get; set; }

    /// <summary>
    /// The active status of the attribute choice.
    /// Editable via the API. Required.
    /// </summary>
    [JsonProperty(nameof(IsActive))]
    public bool IsActive { get; set; }

    /// <summary>
    /// The created date of the attribute choice.
    /// </summary>
    [JsonProperty(nameof(DateCreated))]
    public DateTime DateCreated { get; set; }

    /// <summary>
    /// The last modified date of the attribute choice.
    /// </summary>
    [JsonProperty(nameof(DateModified))]
    public DateTime DateModified { get; set; }

    /// <summary>
    /// The sort order of the attribute choice in the list.
    /// Editable via the API. Required.
    /// </summary>
    [JsonProperty(nameof(Order))]
    public int Order { get; set; }

}
