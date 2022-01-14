namespace DotNetBungieAPI.Generated.Models.Content.Models;

public sealed class TagMetadataItem
{

    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("tagText")]
    public string TagText { get; init; }

    [JsonPropertyName("groups")]
    public List<string> Groups { get; init; }

    [JsonPropertyName("isDefault")]
    public bool IsDefault { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }
}
