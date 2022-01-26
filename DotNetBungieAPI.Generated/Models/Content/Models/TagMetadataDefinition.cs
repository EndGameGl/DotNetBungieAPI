namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class TagMetadataDefinition : IDeepEquatable<TagMetadataDefinition>
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("items")]
    public List<Content.Models.TagMetadataItem> Items { get; set; }

    [JsonPropertyName("datatype")]
    public string Datatype { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("isRequired")]
    public bool IsRequired { get; set; }

    public bool DeepEquals(TagMetadataDefinition? other)
    {
        return other is not null &&
               Description == other.Description &&
               Order == other.Order &&
               Items.DeepEqualsList(other.Items) &&
               Datatype == other.Datatype &&
               Name == other.Name &&
               IsRequired == other.IsRequired;
    }
}