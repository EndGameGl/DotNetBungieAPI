namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class TagMetadataDefinition
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("order")]
    public int? Order { get; set; }

    [JsonPropertyName("items")]
    public List<Content.Models.TagMetadataItem> Items { get; set; }

    [JsonPropertyName("datatype")]
    public string? Datatype { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("isRequired")]
    public bool? IsRequired { get; set; }
}
