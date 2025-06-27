using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itsm.Tdx.WebApi.CustomAttributes.Models;

    /// <summary>
    /// Represents a custom attribute in the TeamDynamix system.
    /// </summary>
    public class CustomAttribute
    {
        /// <summary>
        /// The ID of the attribute.
        /// </summary>
        [JsonProperty("ID")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the attribute.
        /// </summary>
        [JsonProperty(nameof(Name))]
        public string? Name { get; set; }

        /// <summary>
        /// The explicit sort order of the attribute.
        /// </summary>
        [JsonProperty(nameof(Order))]
        public int Order { get; set; }

        /// <summary>
        /// The description of the attribute. Nullable.
        /// </summary>
        [JsonProperty("Description")]
        public string? Description { get; set; }

        /// <summary>
        /// The ID of the section associated with the attribute.
        /// </summary>
        [JsonProperty("SectionID")]
        public int SectionId { get; set; }

        /// <summary>
        /// The name of the section associated with the attribute. Nullable.
        /// </summary>
        [JsonProperty("SectionName")]
        public string? SectionName { get; set; }

        /// <summary>
        /// The field type of the attribute.
        /// </summary>
        [JsonProperty(nameof(FieldType))]
        public string? FieldType { get; set; }

        /// <summary>
        /// The data type of the attribute.
        /// </summary>
        [JsonProperty("DataType")]
        public string? DataType { get; set; }

        /// <summary>
        /// The choices associated with the attribute. Nullable.
        /// </summary>
        [JsonProperty(nameof(Choices))]
        public List<CustomAttributeChoice>? Choices { get; set; }

        /// <summary>
        /// The required status of the attribute.
        /// </summary>
        [JsonProperty(nameof(IsRequired))]
        public bool IsRequired { get; set; }

        /// <summary>
        /// The updatable status of the attribute.
        /// </summary>
        [JsonProperty(nameof(IsUpdatable))]
        public bool IsUpdatable { get; set; }

        /// <summary>
        /// The current value of the attribute. Nullable.
        /// </summary>
        [JsonProperty(nameof(Value))]
        public string? Value { get; set; }

        /// <summary>
        /// The current value of the attribute in read-only text format. Nullable.
        /// </summary>
        [JsonProperty(nameof(ValueText))]
        public string? ValueText { get; set; }

        /// <summary>
        /// Not used. Nullable.
        /// </summary>
        [JsonProperty(nameof(ChoicesText))]
        public string? ChoicesText { get; set; }

        /// <summary>
        /// The item types (represented as IDs) associated with the attribute. Nullable.
        /// </summary>
        [JsonProperty("AssociatedItemIDs")]
        public List<int>? AssociatedItemIds { get; set; }
    }

