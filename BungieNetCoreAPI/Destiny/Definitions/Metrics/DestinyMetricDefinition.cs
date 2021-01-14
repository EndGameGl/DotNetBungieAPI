using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using BungieNetCoreAPI.Destiny.Definitions.Traits;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Metrics
{
    [DestinyDefinition("DestinyMetricDefinition")]
    public class DestinyMetricDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public bool LowerValueIsBetter { get; }
        public List<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentNodes { get; }
        public PresentationNodeType PresentationNodeType { get; }
        public DefinitionHashPointer<DestinyObjectiveDefinition> TrackingObjective { get; }
        public List<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; }
        public List<string> TraitIds { get; }

        [JsonConstructor]
        private DestinyMetricDefinition(DestinyDefinitionDisplayProperties displayProperties, bool lowerValueIsBetter, List<uint> parentNodeHashes,
            PresentationNodeType presentationNodeType, uint trackingObjectiveHash, List<uint> traitHashes, List<string> traitIds,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            LowerValueIsBetter = lowerValueIsBetter;
            ParentNodes = new List<DefinitionHashPointer<DestinyPresentationNodeDefinition>>();
            if (parentNodeHashes != null)
            {
                foreach (var parentNodeHash in parentNodeHashes)
                {
                    ParentNodes.Add(new DefinitionHashPointer<DestinyPresentationNodeDefinition>(parentNodeHash, "DestinyPresentationNodeDefinition"));
                }
            }
            PresentationNodeType = presentationNodeType;
            TrackingObjective = new DefinitionHashPointer<DestinyObjectiveDefinition>(trackingObjectiveHash, "DestinyObjectiveDefinition");
            Traits = new List<DefinitionHashPointer<DestinyTraitDefinition>>();
            if (traitHashes != null)
            {
                foreach (var traitHash in traitHashes)
                {
                    Traits.Add(new DefinitionHashPointer<DestinyTraitDefinition>(traitHash, "DestinyTraitDefinition"));
                }
            }
            TraitIds = traitIds;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
