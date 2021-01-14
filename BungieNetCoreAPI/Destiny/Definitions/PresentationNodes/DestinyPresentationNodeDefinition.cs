using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using BungieNetCoreAPI.Destiny.Definitions.Traits;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.PresentationNodes
{
    [DestinyDefinition("DestinyPresentationNodeDefinition")]
    public class DestinyPresentationNodeDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public PresentationChildNode Children { get; }
        public bool DisableChildSubscreenNavigation { get; }
        public int DisplayStyle { get; }
        public int MaxCategoryRecordScore { get; }
        public int NodeType { get; }
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; }
        public List<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentNodes { get; }
        public PresentationNodeType PresentationNodeType { get; }
        public PresentationNodeRequirement Requirements { get; }
        public Scope Scope { get; }
        public int ScreenStyle { get; }
        public List<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; }
        public List<string> TraitIds { get; }

        [JsonConstructor]
        private DestinyPresentationNodeDefinition(DestinyDefinitionDisplayProperties displayProperties, PresentationChildNode children, bool disableChildSubscreenNavigation,
            int displayStyle, int maxCategoryRecordScore, int nodeType, uint objectiveHash, List<uint> parentNodeHashes, PresentationNodeType presentationNodeType, 
            PresentationNodeRequirement requirements, Scope scope, int screenStyle, List<uint> traitHashes, List<string> traitIds,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            Children = children;
            DisableChildSubscreenNavigation = disableChildSubscreenNavigation;
            DisplayStyle = displayStyle;
            MaxCategoryRecordScore = maxCategoryRecordScore;
            NodeType = nodeType;
            Objective = new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, "DestinyObjectiveDefinition");
            ParentNodes = new List<DefinitionHashPointer<DestinyPresentationNodeDefinition>>();
            if (parentNodeHashes != null)
            {
                foreach (var parentNodeHash in parentNodeHashes)
                {
                    ParentNodes.Add(new DefinitionHashPointer<DestinyPresentationNodeDefinition>(parentNodeHash, "DestinyObjectiveDefinition"));
                }
            }
            PresentationNodeType = presentationNodeType;
            Requirements = requirements;
            Scope = scope;
            ScreenStyle = screenStyle;
            Traits = new List<DefinitionHashPointer<DestinyTraitDefinition>>();
            if (parentNodeHashes != null)
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
