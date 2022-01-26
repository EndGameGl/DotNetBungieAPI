namespace DotNetBungieAPI.Generated.Models.Destiny.Misc;

/// <summary>
///     Represents a color whose RGBA values are all represented as values between 0 and 255.
/// </summary>
public class DestinyColor : IDeepEquatable<DestinyColor>
{
    [JsonPropertyName("red")]
    public string Red { get; set; }

    [JsonPropertyName("green")]
    public string Green { get; set; }

    [JsonPropertyName("blue")]
    public string Blue { get; set; }

    [JsonPropertyName("alpha")]
    public string Alpha { get; set; }

    public bool DeepEquals(DestinyColor? other)
    {
        return other is not null &&
               Red == other.Red &&
               Green == other.Green &&
               Blue == other.Blue &&
               Alpha == other.Alpha;
    }
}