namespace DotNetBungieAPI.Generated.Models.Destiny.Misc;

/// <summary>
///     Represents a color whose RGBA values are all represented as values between 0 and 255.
/// </summary>
public class DestinyColor
{
    [JsonPropertyName("red")]
    public byte Red { get; set; }

    [JsonPropertyName("green")]
    public byte Green { get; set; }

    [JsonPropertyName("blue")]
    public byte Blue { get; set; }

    [JsonPropertyName("alpha")]
    public byte Alpha { get; set; }
}
