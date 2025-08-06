namespace DotNetBungieAPI.Models.Destiny.Definitions.Common;

public sealed class DestinyPositionDefinition
{
    [JsonPropertyName("x")]
    public int X { get; init; }

    [JsonPropertyName("y")]
    public int Y { get; init; }

    [JsonPropertyName("z")]
    public int Z { get; init; }
}
