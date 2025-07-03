using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDynamix.Api.Attachments.Models;
/// <summary>
/// An attachment.
/// </summary>
public class Attachment
{
    /// <summary>
    /// The ID of the attachment.
    /// </summary>
    [JsonProperty("ID")]
    public string? Id { get; set; }

    /// <summary>
    /// The type of the attachment.
    /// </summary>
    [JsonProperty(nameof(AttachmentType))]
    public AttachmentType AttachmentType { get; set; }

    /// <summary>
    /// The ID of the item associated with the attachment.
    /// </summary>
    [JsonProperty("ItemID")]
    public int ItemId { get; set; }

    /// <summary>
    /// The UID of the user who uploaded the attachment.
    /// </summary>
    [JsonProperty("CreatedUID")]
    public Guid CreatedUid { get; set; }

    /// <summary>
    /// The full name of the user who uploaded the attachment.
    /// </summary>
    [JsonProperty(nameof(CreatedFullName))]
    public string CreatedFullName { get; set; } = string.Empty;

    /// <summary>
    /// The upload date of the attachment.
    /// </summary>
    [JsonProperty(nameof(CreatedDate))]
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// The file name of the attachment.
    /// </summary>
    [JsonProperty(nameof(Name))]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The size of the attachment, in bytes.
    /// </summary>
    [JsonProperty(nameof(Size))]
    public int Size { get; set; }

    /// <summary>
    /// The URI to retrieve the full details of the attachment via the web API.
    /// </summary>
    [JsonProperty(nameof(Uri))]
    public string Uri { get; set; } = string.Empty;

    /// <summary>
    /// The URI to retrieve the contents of the attachment via the web API.
    /// </summary>
    [JsonProperty(nameof(ContentUri))]
    public string ContentUri { get; set; } = string.Empty;
}
