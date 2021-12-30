using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

public sealed class DestinyActivityGraphNodeDefinition
{

    [JsonPropertyName("nodeId")]
    public uint NodeId { get; init; }

    [JsonPropertyName("overrideDisplay")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition OverrideDisplay { get; init; }

    [JsonPropertyName("position")]
    public Destiny.Definitions.Common.DestinyPositionDefinition Position { get; init; }

    [JsonPropertyName("featuringStates")]
    public List<Destiny.Definitions.Director.DestinyActivityGraphNodeFeaturingStateDefinition> FeaturingStates { get; init; }

    [JsonPropertyName("activities")]
    public List<Destiny.Definitions.Director.DestinyActivityGraphNodeActivityDefinition> Activities { get; init; }

    [JsonPropertyName("states")]
    public List<Destiny.Definitions.Director.DestinyActivityGraphNodeStateEntry> States { get; init; }
}
