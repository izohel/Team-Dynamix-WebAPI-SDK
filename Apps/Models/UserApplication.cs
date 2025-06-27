using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.Apps.Models;
/// <summary>
/// An association that a user has with an application.
/// </summary>
public class UserApplication
{
    /// <summary>
    /// The ID of the security role that the user has within the application. Nullable.
    /// </summary>
    [JsonProperty(nameof(SecurityRoleId))]
    public string? SecurityRoleId { get; set; }

    /// <summary>
    /// The name of the security role that the user has within the application. Nullable.
    /// </summary>
    [JsonProperty(nameof(SecurityRoleName))]
    public string? SecurityRoleName { get; set; }

    /// <summary>
    /// The administrator status of the user for the application.
    /// </summary>
    [JsonProperty(nameof(IsAdministrator))]
    public bool IsAdministrator { get; set; }

    /// <summary>
    /// The ID of the application.
    /// </summary>
    [JsonProperty(nameof(ID))]
    public int ID { get; set; }

    /// <summary>
    /// The name of the application.
    /// </summary>
    [JsonProperty(nameof(Name))]
    public string? Name { get; set; }

    /// <summary>
    /// The description of the application. Nullable.
    /// </summary>
    [JsonProperty(nameof(Description))]
    public string? Description { get; set; }

    /// <summary>
    /// The system-defined class of the application.
    /// </summary>
    [JsonProperty(nameof(SystemClass))]
    public string? SystemClass { get; set; }

    /// <summary>
    /// The default status of the application.
    /// </summary>
    [JsonProperty(nameof(IsDefault))]
    public bool IsDefault { get; set; }

    /// <summary>
    /// The active status of the application.
    /// </summary>
    [JsonProperty(nameof(IsActive))]
    public bool IsActive { get; set; }
}
