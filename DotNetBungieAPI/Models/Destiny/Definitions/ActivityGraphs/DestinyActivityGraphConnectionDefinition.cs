namespace DotNetBungieAPI.Models.Destiny.Definitions.ActivityGraphs;

/// <summary>
///     Nodes on a graph can be visually connected: this appears to be the information about which nodes to link. It
///     appears to lack more detailed information, such as the path for that linking.
/// </summary>
public sealed record
    DestinyActivityGraphConnectionDefinition : IDeepEquatable<DestinyActivityGraphConnectionDefinition>
{
    [JsonPropertyName("sourceNodeHash")] public uint SourceNodeHash { get; init; }

    [JsonPropertyName("destNodeHash")] public uint DestinationNodeHash { get; init; }

    public bool DeepEquals(DestinyActivityGraphConnectionDefinition other)
    {
        return other != null &&
               SourceNodeHash == other.SourceNodeHash &&
               DestinationNodeHash == other.DestinationNodeHash;
    }
}