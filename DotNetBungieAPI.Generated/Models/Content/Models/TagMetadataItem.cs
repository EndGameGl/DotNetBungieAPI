namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class TagMetadataItem : IDeepEquatable<TagMetadataItem>
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("tagText")]
    public string TagText { get; set; }

    [JsonPropertyName("groups")]
    public List<string> Groups { get; set; }

    [JsonPropertyName("isDefault")]
    public bool IsDefault { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    public bool DeepEquals(TagMetadataItem? other)
    {
        return other is not null &&
               Description == other.Description &&
               TagText == other.TagText &&
               Groups.DeepEqualsListNaive(other.Groups) &&
               IsDefault == other.IsDefault &&
               Name == other.Name;
    }
}