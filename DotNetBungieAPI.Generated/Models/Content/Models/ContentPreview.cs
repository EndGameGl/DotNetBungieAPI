using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Content.Models;

public sealed class ContentPreview
{

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("path")]
    public string Path { get; init; }

    [JsonPropertyName("itemInSet")]
    public bool ItemInSet { get; init; }

    [JsonPropertyName("setTag")]
    public string SetTag { get; init; }

    [JsonPropertyName("setNesting")]
    public int SetNesting { get; init; }

    [JsonPropertyName("useSetId")]
    public int UseSetId { get; init; }
}
