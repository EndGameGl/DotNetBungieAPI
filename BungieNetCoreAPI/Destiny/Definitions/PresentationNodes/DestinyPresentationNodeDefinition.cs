using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using BungieNetCoreAPI.Destiny.Definitions.Traits;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.PresentationNodes
{
    /// <summary>
    /// A PresentationNode is an entity that represents a logical grouping of other entities visually/organizationally.
    /// <para/>
    /// For now, Presentation Nodes may contain the following...but it may be used for more in the future:
    /// <para/>
    /// - Collectibles - Records(Or, as the public will call them, "Triumphs." Don't ask me why we're overloading the term "Triumph", it still hurts me to think about it) - Metrics(aka Stat Trackers) - Other Presentation Nodes, allowing a tree of Presentation Nodes to be created
    /// </summary>
    [DestinyDefinition(type: DefinitionsEnum.DestinyPresentationNodeDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyPresentationNodeDefinition : IDestinyDefinition
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
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyPresentationNodeDefinition(DestinyDefinitionDisplayProperties displayProperties, PresentationChildNode children, bool disableChildSubscreenNavigation,
            int displayStyle, int maxCategoryRecordScore, int nodeType, uint objectiveHash, List<uint> parentNodeHashes, PresentationNodeType presentationNodeType,
            PresentationNodeRequirement requirements, Scope scope, int screenStyle, List<uint> traitHashes, List<string> traitIds,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            Children = children;
            DisableChildSubscreenNavigation = disableChildSubscreenNavigation;
            DisplayStyle = displayStyle;
            MaxCategoryRecordScore = maxCategoryRecordScore;
            NodeType = nodeType;
            Objective = new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
            ParentNodes = new List<DefinitionHashPointer<DestinyPresentationNodeDefinition>>();
            if (parentNodeHashes != null)
            {
                foreach (var parentNodeHash in parentNodeHashes)
                {
                    ParentNodes.Add(new DefinitionHashPointer<DestinyPresentationNodeDefinition>(parentNodeHash, DefinitionsEnum.DestinyObjectiveDefinition));
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
                    Traits.Add(new DefinitionHashPointer<DestinyTraitDefinition>(traitHash, DefinitionsEnum.DestinyTraitDefinition));
                }
            }
            TraitIds = traitIds;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
