namespace DotNetBungieAPI.Models.Destiny.Definitions.Metrics;

[DestinyDefinition(DefinitionsEnum.DestinyMetricDefinition)]
public sealed class DestinyMetricDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyMetricDefinition;

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    [JsonPropertyName("trackingObjectiveHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyObjectiveDefinition> TrackingObjectiveHash { get; init; }

    [JsonPropertyName("lowerValueIsBetter")]
    public bool LowerValueIsBetter { get; init; }

    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; init; }

    [JsonPropertyName("traitIds")]
    public string[]? TraitIds { get; init; }

    [JsonPropertyName("traitHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Traits.DestinyTraitDefinition>[]? TraitHashes { get; init; }

    /// <summary>
    ///     A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.
    /// </summary>
    [JsonPropertyName("parentNodeHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>[]? ParentNodeHashes { get; init; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
