namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class ContentTypeDescription
{
    [JsonPropertyName("cType")]
    public string CType { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("contentDescription")]
    public string ContentDescription { get; set; }

    [JsonPropertyName("previewImage")]
    public string PreviewImage { get; set; }

    [JsonPropertyName("priority")]
    public int Priority { get; set; }

    [JsonPropertyName("reminder")]
    public string Reminder { get; set; }

    [JsonPropertyName("properties")]
    public List<Content.Models.ContentTypeProperty> Properties { get; set; }

    [JsonPropertyName("tagMetadata")]
    public List<Content.Models.TagMetadataDefinition> TagMetadata { get; set; }

    [JsonPropertyName("tagMetadataItems")]
    public Dictionary<string, Content.Models.TagMetadataItem> TagMetadataItems { get; set; }

    [JsonPropertyName("usageExamples")]
    public List<string> UsageExamples { get; set; }

    [JsonPropertyName("showInContentEditor")]
    public bool ShowInContentEditor { get; set; }

    [JsonPropertyName("typeOf")]
    public string TypeOf { get; set; }

    [JsonPropertyName("bindIdentifierToProperty")]
    public string BindIdentifierToProperty { get; set; }

    [JsonPropertyName("boundRegex")]
    public string BoundRegex { get; set; }

    [JsonPropertyName("forceIdentifierBinding")]
    public bool ForceIdentifierBinding { get; set; }

    [JsonPropertyName("allowComments")]
    public bool AllowComments { get; set; }

    [JsonPropertyName("autoEnglishPropertyFallback")]
    public bool AutoEnglishPropertyFallback { get; set; }

    [JsonPropertyName("bulkUploadable")]
    public bool BulkUploadable { get; set; }

    [JsonPropertyName("previews")]
    public List<Content.Models.ContentPreview> Previews { get; set; }

    [JsonPropertyName("suppressCmsPath")]
    public bool SuppressCmsPath { get; set; }

    [JsonPropertyName("propertySections")]
    public List<Content.Models.ContentTypePropertySection> PropertySections { get; set; }
}
