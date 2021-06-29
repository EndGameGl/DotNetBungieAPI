using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.Objectives;
using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using NetBungieAPI.Models.Destiny.Definitions.Traits;

namespace NetBungieAPI.Models.Destiny.Definitions.Metrics
{
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
        public ReadOnlyCollection<string> TraitIds { get; init; } = Defaults.EmptyReadOnlyCollection<string>();

        [JsonPropertyName("traitHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>>();

        /// <summary>
        ///     A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under
        ///     multiple parents.
        /// </summary>
        [JsonPropertyName("parentNodeHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentNodes { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>>();

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

        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
            foreach (var node in ParentNodes) node.TryMapValue();

            TrackingObjective.TryMapValue();
            foreach (var trait in Traits) trait.TryMapValue();
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}