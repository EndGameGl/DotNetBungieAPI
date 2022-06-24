using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.Objectives;
using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using DotNetBungieAPI.Models.Destiny.Definitions.Traits;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Metrics;

[DestinyDefinition(DefinitionsEnum.DestinyMetricDefinition)]
public sealed record DestinyMetricDefinition : IDestinyDefinition, IDeepEquatable<DestinyMetricDefinition>
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("trackingObjectiveHash")]
    public DefinitionHashPointer<DestinyObjectiveDefinition> TrackingObjective { get; init; } =
        DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;

    [JsonPropertyName("lowerValueIsBetter")]
    public bool LowerValueIsBetter { get; init; }

    [JsonPropertyName("presentationNodeType")]
    public DestinyPresentationNodeType PresentationNodeType { get; init; }

    [JsonPropertyName("traitIds")]
    public ReadOnlyCollection<string> TraitIds { get; init; } = ReadOnlyCollections<string>.Empty;

    [JsonPropertyName("traitHashes")]
    public ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyTraitDefinition>>.Empty;

    /// <summary>
    ///     A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under
    ///     multiple parents.
    /// </summary>
    [JsonPropertyName("parentNodeHashes")]
    public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentNodes { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyPresentationNodeDefinition>>.Empty;

    public bool DeepEquals(DestinyMetricDefinition other)
    {
        return other != null &&
               DisplayProperties.DeepEquals(other.DisplayProperties) &&
               LowerValueIsBetter == other.LowerValueIsBetter &&
               ParentNodes.DeepEqualsReadOnlyCollections(other.ParentNodes) &&
               PresentationNodeType == other.PresentationNodeType &&
               TrackingObjective.DeepEquals(other.TrackingObjective) &&
               Traits.DeepEqualsReadOnlyCollections(other.Traits) &&
               TraitIds.DeepEqualsReadOnlySimpleCollection(other.TraitIds) &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyMetricDefinition;
    [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
    [JsonPropertyName("hash")] public uint Hash { get; init; }
    [JsonPropertyName("index")] public int Index { get; init; }
    [JsonPropertyName("redacted")] public bool Redacted { get; init; }
}