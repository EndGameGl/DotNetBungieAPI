using NetBungieApi.Attributes;
using NetBungieApi.Destiny.Definitions.Objectives;
using NetBungieApi.Destiny.Definitions.PresentationNodes;
using NetBungieApi.Destiny.Definitions.Traits;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.Metrics
{
    [DestinyDefinition(DefinitionsEnum.DestinyMetricDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyMetricDefinition : IDestinyDefinition, IDeepEquatable<DestinyMetricDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public bool LowerValueIsBetter { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentNodes { get; }
        public PresentationNodeType PresentationNodeType { get; }
        public DefinitionHashPointer<DestinyObjectiveDefinition> TrackingObjective { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; }
        public ReadOnlyCollection<string> TraitIds { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyMetricDefinition(DestinyDefinitionDisplayProperties displayProperties, bool lowerValueIsBetter, uint[] parentNodeHashes,
            PresentationNodeType presentationNodeType, uint trackingObjectiveHash, uint[] traitHashes, string[] traitIds,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            LowerValueIsBetter = lowerValueIsBetter;
            ParentNodes = parentNodeHashes.DefinitionsAsReadOnlyOrEmpty<DestinyPresentationNodeDefinition>(DefinitionsEnum.DestinyPresentationNodeDefinition);
            PresentationNodeType = presentationNodeType;
            TrackingObjective = new DefinitionHashPointer<DestinyObjectiveDefinition>(trackingObjectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
            Traits = traitHashes.DefinitionsAsReadOnlyOrEmpty<DestinyTraitDefinition>(DefinitionsEnum.DestinyTraitDefinition);
            TraitIds = traitIds.AsReadOnlyOrEmpty();
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

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
        public void MapValues()
        {
            foreach (var node in ParentNodes)
            {
                node.TryMapValue();
            }
            TrackingObjective.TryMapValue();
            foreach (var trait in Traits)
            {
                trait.TryMapValue();
            }
        }
    }
}
