namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Metrics;

public class DestinyMetricDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyObjectiveDefinition>("Destiny.Definitions.DestinyObjectiveDefinition")]
    [JsonPropertyName("trackingObjectiveHash")]
    public uint? TrackingObjectiveHash { get; set; }

    [JsonPropertyName("lowerValueIsBetter")]
    public bool? LowerValueIsBetter { get; set; }

    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType? PresentationNodeType { get; set; }

    [JsonPropertyName("traitIds")]
    public List<string> TraitIds { get; set; }

    [Destiny2DefinitionList<Destiny.Definitions.Traits.DestinyTraitDefinition>("Destiny.Definitions.Traits.DestinyTraitDefinition")]
    [JsonPropertyName("traitHashes")]
    public List<uint> TraitHashes { get; set; }

    /// <summary>
    ///     A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.
    /// </summary>
    [Destiny2DefinitionList<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("parentNodeHashes")]
    public List<uint> ParentNodeHashes { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint? Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool? Redacted { get; set; }
}
