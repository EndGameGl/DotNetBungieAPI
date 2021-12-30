using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Config;

public sealed class ImagePyramidEntry
{

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("factor")]
    public float Factor { get; init; }
}
