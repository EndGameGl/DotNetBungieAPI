namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class ContentPreview : IDeepEquatable<ContentPreview>
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("itemInSet")]
    public bool ItemInSet { get; set; }

    [JsonPropertyName("setTag")]
    public string SetTag { get; set; }

    [JsonPropertyName("setNesting")]
    public int SetNesting { get; set; }

    [JsonPropertyName("useSetId")]
    public int UseSetId { get; set; }

    public bool DeepEquals(ContentPreview? other)
    {
        return other is not null &&
               Name == other.Name &&
               Path == other.Path &&
               ItemInSet == other.ItemInSet &&
               SetTag == other.SetTag &&
               SetNesting == other.SetNesting &&
               UseSetId == other.UseSetId;
    }
}