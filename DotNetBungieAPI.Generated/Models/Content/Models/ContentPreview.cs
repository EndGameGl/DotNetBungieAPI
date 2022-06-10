namespace DotNetBungieAPI.Generated.Models.Content.Models;

public class ContentPreview
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("itemInSet")]
    public bool? ItemInSet { get; set; }

    [JsonPropertyName("setTag")]
    public string? SetTag { get; set; }

    [JsonPropertyName("setNesting")]
    public int? SetNesting { get; set; }

    [JsonPropertyName("useSetId")]
    public int? UseSetId { get; set; }
}
