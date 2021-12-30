using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     Nodes on a graph can be visually connected: this appears to be the information about which nodes to link. It appears to lack more detailed information, such as the path for that linking.
/// </summary>
public sealed class DestinyActivityGraphConnectionDefinition
{

    [JsonPropertyName("sourceNodeHash")]
    public uint SourceNodeHash { get; init; }

    [JsonPropertyName("destNodeHash")]
    public uint DestNodeHash { get; init; }
}
