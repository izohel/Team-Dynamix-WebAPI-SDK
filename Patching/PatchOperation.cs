using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDynamix.Api.Patching;
public class PatchOperation
{
    /// <summary>
    /// The type of operation to perform (e.g., "add", "remove").
    /// </summary>
    [JsonProperty("op")]
    public string Op { get; set; } = null!;

    /// <summary>
    /// The path to the property being modified (e.g., "/name" or "/attributes/1234").
    /// </summary>
    [JsonProperty("path")]
    public string Path { get; set; } = null!;

    /// <summary>
    /// The value to apply. Not required for remove operations.
    /// </summary>
    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public object? Value { get; set; }
}