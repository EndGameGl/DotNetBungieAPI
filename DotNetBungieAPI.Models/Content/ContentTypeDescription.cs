namespace DotNetBungieAPI.Models.Content;

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
    public ReadOnlyCollection<ContentTypeProperty> Properties { get; init; } =
        ReadOnlyCollection<ContentTypeProperty>.Empty;

    [JsonPropertyName("tagMetadata")]
    public ReadOnlyCollection<TagMetadataDefinition> TagMetadata { get; init; } =
        ReadOnlyCollection<TagMetadataDefinition>.Empty;

    [JsonPropertyName("tagMetadataItems")]
    public ReadOnlyDictionary<string, TagMetadataItem> TagMetadataItems { get; init; } =
        ReadOnlyDictionary<string, TagMetadataItem>.Empty;

    [JsonPropertyName("usageExamples")]
    public ReadOnlyCollection<string> UsageExamples { get; init; } =
        ReadOnlyCollection<string>.Empty;

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
    public ReadOnlyCollection<ContentPreview> Previews { get; init; } =
        ReadOnlyCollection<ContentPreview>.Empty;

    [JsonPropertyName("suppressCmsPath")]
    public bool SuppressCmsPath { get; init; }

    [JsonPropertyName("propertySections")]
    public ReadOnlyCollection<ContentTypePropertySection> PropertySections { get; init; } =
        ReadOnlyCollection<ContentTypePropertySection>.Empty;
}
