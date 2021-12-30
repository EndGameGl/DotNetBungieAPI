using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public sealed class DestinyMilestoneActivityDefinition
{

    [JsonPropertyName("conceptualActivityHash")]
    public uint ConceptualActivityHash { get; init; }

    [JsonPropertyName("variants")]
    public Dictionary<uint, Destiny.Definitions.Milestones.DestinyMilestoneActivityVariantDefinition> Variants { get; init; }
}
