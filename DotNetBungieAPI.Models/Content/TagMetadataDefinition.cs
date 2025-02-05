namespace DotNetBungieAPI.Models.Content;

public sealed record TagMetadataDefinition
{
    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("order")]
    public int Order { get; init; }

    [JsonPropertyName("items")]
    public ReadOnlyCollection<TagMetadataItem> Items { get; init; } =
        ReadOnlyCollection<TagMetadataItem>.Empty;

    [JsonPropertyName("datatype")]
    public string Datatype { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("isRequired")]
    public bool IsRequired { get; init; }
}
