namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     Represents a color whose RGBA values are all represented as values between 0 and 255.
/// </summary>
public sealed record DestinyColor : IDeepEquatable<DestinyColor>
{
    [JsonPropertyName("colorHash")]
    public uint ColorHash { get; init; }

    [JsonPropertyName("alpha")]
    public byte Alpha { get; init; }

    [JsonPropertyName("blue")]
    public byte Blue { get; init; }

    [JsonPropertyName("green")]
    public byte Green { get; init; }

    [JsonPropertyName("red")]
    public byte Red { get; init; }

    public bool DeepEquals(DestinyColor other)
    {
        return other != null
            && ColorHash == other.ColorHash
            && Alpha == other.Alpha
            && Blue == other.Blue
            && Green == other.Green
            && Red == other.Red;
    }
}
