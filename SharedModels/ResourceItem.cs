using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.SharedModels;

/// <summary>
/// A single person, group, or account/department.
/// </summary>
public class ResourceItem
{
    /// <summary>
    /// Extension for internal usage not an included property
    /// </summary>
    public string? GroupId{ get; set; }
    /// <summary>
    /// The role the resource has on the associated item.
    /// </summary>
    public string? ItemRole { get; set; } = "Responsible Group";

    /// <summary>
    /// The name of the resource.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The initials to be displayed if no profile image is specified for the resource.
    /// </summary>
    public string? Initials { get; set; }

    /// <summary>
    /// The value of the resource.
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// The integer ID of the resource.
    /// </summary>
    public int RefValue { get; set; }

    /// <summary>
    /// The profile image file name of the resource.
    /// </summary>
    public string? ProfileImageFileName { get; set; }
}

