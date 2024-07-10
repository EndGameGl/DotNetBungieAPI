namespace DotNetBungieAPI.Models.Content;

public sealed record TagMetadataItem
{
    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("tagText")]
    public string TagText { get; init; }

    [JsonPropertyName("groups")]
    public ReadOnlyCollection<string> Groups { get; init; } = ReadOnlyCollections<string>.Empty;

    [JsonPropertyName("isDefault")]
    public bool IsDefault { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }
}
