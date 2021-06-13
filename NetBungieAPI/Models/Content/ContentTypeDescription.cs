using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Content
{
    public sealed record ContentTypeDescription
    {
        [JsonPropertyName("cType")]
        public string ContentType { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("contentDescription")]
        public string ContentDescription { get; init; }

        [JsonPropertyName("previewImage")]
        public string PreviewImage { get; init; }

        [JsonPropertyName("priority")]
        public int Priority { get; init; }

        [JsonPropertyName("reminder")]
        public string Reminder { get; init; }

        [JsonPropertyName("properties")]
        public ReadOnlyCollection<ContentTypeProperty> Properties { get; init; } = Defaults.EmptyReadOnlyCollection<ContentTypeProperty>();

        [JsonPropertyName("tagMetadata")]
        public ReadOnlyCollection<TagMetadataDefinition> TagMetadata { get; init; } = Defaults.EmptyReadOnlyCollection<TagMetadataDefinition>();

        [JsonPropertyName("tagMetadataItems")]
        public ReadOnlyDictionary<string, TagMetadataItem> TagMetadataItems { get; init; } = Defaults.EmptyReadOnlyDictionary<string, TagMetadataItem>();

        [JsonPropertyName("usageExamples")]
        public ReadOnlyCollection<string> UsageExamples { get; init; } = Defaults.EmptyReadOnlyCollection<string>();

        [JsonPropertyName("showInContentEditor")]
        public bool ShowInContentEditor { get; init; }

        [JsonPropertyName("typeOf")]
        public string TypeOf { get; init; }

        [JsonPropertyName("bindIdentifierToProperty")]
        public string BindIdentifierToProperty { get; init; }

        [JsonPropertyName("boundRegex")]
        public string BoundRegex { get; init; }

        [JsonPropertyName("forceIdentifierBinding")]
        public bool ForceIdentifierBinding { get; init; }

        [JsonPropertyName("allowComments")]
        public bool AllowComments { get; init; }

        [JsonPropertyName("autoEnglishPropertyFallback")]
        public bool AutoEnglishPropertyFallback { get; init; }

        [JsonPropertyName("bulkUploadable")]
        public bool BulkUploadable { get; init; }

        [JsonPropertyName("previews")]
        public ReadOnlyCollection<ContentPreview> Previews { get; init; } = Defaults.EmptyReadOnlyCollection<ContentPreview>();

        [JsonPropertyName("suppressCmsPath")]
        public bool SuppressCmsPath { get; init; }

        [JsonPropertyName("propertySections")]
        public ReadOnlyCollection<ContentTypePropertySection> PropertySections { get; init; } = Defaults.EmptyReadOnlyCollection<ContentTypePropertySection>();
    }
}
