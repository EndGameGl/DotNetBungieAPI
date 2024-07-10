namespace DotNetBungieAPI.Models.Destiny.Definitions.Common;

public sealed record DestinyPositionDefinition : IDeepEquatable<DestinyPositionDefinition>
{
    [JsonPropertyName("x")]
    public int X { get; init; }

    [JsonPropertyName("y")]
    public int Y { get; init; }

    [JsonPropertyName("z")]
    public int Z { get; init; }

    public bool DeepEquals(DestinyPositionDefinition other)
    {
        return other != null && X == other.X && Y == other.Y && Z == other.Z;
    }
}
