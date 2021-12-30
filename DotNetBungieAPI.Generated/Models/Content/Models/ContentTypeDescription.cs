using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Content.Models;

public sealed class ContentTypeDescription
{

    [JsonPropertyName("cType")]
    public string CType { get; init; }

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
    public List<Content.Models.ContentTypeProperty> Properties { get; init; }

    [JsonPropertyName("tagMetadata")]
    public List<Content.Models.TagMetadataDefinition> TagMetadata { get; init; }

    [JsonPropertyName("tagMetadataItems")]
    public Dictionary<string, Content.Models.TagMetadataItem> TagMetadataItems { get; init; }

    [JsonPropertyName("usageExamples")]
    public List<string> UsageExamples { get; init; }

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
    public List<Content.Models.ContentPreview> Previews { get; init; }

    [JsonPropertyName("suppressCmsPath")]
    public bool SuppressCmsPath { get; init; }

    [JsonPropertyName("propertySections")]
    public List<Content.Models.ContentTypePropertySection> PropertySections { get; init; }
}
