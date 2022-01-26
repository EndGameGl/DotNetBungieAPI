namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     Nodes on a graph can be visually connected: this appears to be the information about which nodes to link. It appears to lack more detailed information, such as the path for that linking.
/// </summary>
public class DestinyActivityGraphConnectionDefinition : IDeepEquatable<DestinyActivityGraphConnectionDefinition>
{
    [JsonPropertyName("sourceNodeHash")]
    public uint SourceNodeHash { get; set; }

    [JsonPropertyName("destNodeHash")]
    public uint DestNodeHash { get; set; }

    public bool DeepEquals(DestinyActivityGraphConnectionDefinition? other)
    {
        return other is not null &&
               SourceNodeHash == other.SourceNodeHash &&
               DestNodeHash == other.DestNodeHash;
    }
}