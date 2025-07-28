namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class TagMetadataItem
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("tagText")]
    public string TagText { get; set; }

    [JsonPropertyName("groups")]
    public string[]? Groups { get; set; }

    [JsonPropertyName("isDefault")]
    public bool IsDefault { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}
