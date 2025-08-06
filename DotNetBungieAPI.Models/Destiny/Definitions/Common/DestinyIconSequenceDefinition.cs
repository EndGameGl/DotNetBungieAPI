namespace DotNetBungieAPI.Models.Destiny.Definitions.Common;

public sealed class DestinyIconSequenceDefinition
{
    [JsonPropertyName("frames")]
    public string[]? Frames { get; init; }
}
