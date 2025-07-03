using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDynamix.Api.KnowledgeBase.Models;
/// <summary>
/// Describes the different article statuses.
/// </summary>
public enum ArticleStatus
{
    /// <summary>
    /// A "none" status for filtering purposes. Should not be used in normal operations.
    /// </summary>
    None = 0,

    /// <summary>
    /// Used for articles that have not been submitted.
    /// </summary>
    NotSubmitted = 1,

    /// <summary>
    /// Used for articles that have been submitted.
    /// </summary>
    Submitted = 2,

    /// <summary>
    /// Used for articles that have been approved.
    /// </summary>
    Approved = 3,

    /// <summary>
    /// Used for articles that have been rejected.
    /// </summary>
    Rejected = 4,

    /// <summary>
    /// Used for articles that have been archived.
    /// </summary>
    Archived = 5
}