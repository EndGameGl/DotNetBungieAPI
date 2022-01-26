namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Common;

public class DestinyPositionDefinition : IDeepEquatable<DestinyPositionDefinition>
{
    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }

    [JsonPropertyName("z")]
    public int Z { get; set; }

    public bool DeepEquals(DestinyPositionDefinition? other)
    {
        return other is not null &&
               X == other.X &&
               Y == other.Y &&
               Z == other.Z;
    }
}