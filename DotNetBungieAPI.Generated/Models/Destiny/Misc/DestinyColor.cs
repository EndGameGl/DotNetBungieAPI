using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Misc;

public sealed class DestinyColor
{

    [JsonPropertyName("red")]
    public string Red { get; init; }

    [JsonPropertyName("green")]
    public string Green { get; init; }

    [JsonPropertyName("blue")]
    public string Blue { get; init; }

    [JsonPropertyName("alpha")]
    public string Alpha { get; init; }
}
