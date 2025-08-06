namespace DotNetBungieAPI.Models.Destiny.Misc;

/// <summary>
///     Represents a color whose RGBA values are all represented as values between 0 and 255.
/// </summary>
public sealed class DestinyColor
{
    [JsonPropertyName("red")]
    public byte Red { get; init; }

    [JsonPropertyName("green")]
    public byte Green { get; init; }

    [JsonPropertyName("blue")]
    public byte Blue { get; init; }

    [JsonPropertyName("alpha")]
    public byte Alpha { get; init; }
}
