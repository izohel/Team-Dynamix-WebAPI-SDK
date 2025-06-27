using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.People.Models;
/// <summary>
/// Describes the different types of users and customers tracked within TeamDynamix.
/// </summary>
public enum UserType
{
    /// <summary>
    /// Indicates that the type of the user could not be determined. Should not be used in normal operations.
    /// </summary>
    None = 0,

    /// <summary>
    /// Indicates that the user is classified as a full TeamDynamix user.
    /// </summary>
    User = 1,

    /// <summary>
    /// Indicates that the user is classified as a customer, which means that they cannot log in to TeamDynamix.
    /// </summary>
    Customer = 2,

    /// <summary>
    /// Indicates that the user is classified as a resource placeholder. 
    /// These users act as a placeholder for actual users when planning out projects without knowing exactly who will be acting as the resource in question.
    /// </summary>
    ResourcePlaceholder = 8,

    /// <summary>
    /// Indicates that the user is classified as a service account. 
    /// These users will be able to authenticate and use the API, but they will not be able to log in to TDNext, TDMobile, TDAdmin, or TDClient.
    /// </summary>
    ServiceAccount = 9
}