using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Misc;

/// <summary>
///     Represents a color whose RGBA values are all represented as values between 0 and 255.
/// </summary>
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
