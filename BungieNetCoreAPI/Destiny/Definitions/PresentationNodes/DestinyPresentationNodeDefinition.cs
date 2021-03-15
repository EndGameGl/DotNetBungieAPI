using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.Objectives;
using NetBungieAPI.Destiny.Definitions.Records;
using NetBungieAPI.Destiny.Definitions.Traits;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.PresentationNodes
{
    /// <summary>
    /// A PresentationNode is an entity that represents a logical grouping of other entities visually/organizationally.
    /// <para/>
    /// For now, Presentation Nodes may contain the following...but it may be used for more in the future:
    /// <para/>
    /// - Collectibles - Records(Or, as the public will call them, "Triumphs." Don't ask me why we're overloading the term "Triumph", it still hurts me to think about it) - Metrics(aka Stat Trackers) - Other Presentation Nodes, allowing a tree of Presentation Nodes to be created
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyPresentationNodeDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyPresentationNodeDefinition : IDestinyDefinition, IDeepEquatable<DestinyPresentationNodeDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// The child entities contained by this presentation node.
        /// </summary>
        public PresentationChildNode Children { get; }
        /// <summary>
        /// If this presentation node has children, but the game doesn't let you inspect the details of those children, that is indicated here.
        /// </summary>
        public bool DisableChildSubscreenNavigation { get; }
        /// <summary>
        /// A hint for how to display this presentation node when it's shown in a list.
        /// </summary>
        public PresentationDisplayStyle DisplayStyle { get; }
        public int MaxCategoryRecordScore { get; }
        public int NodeType { get; }
        /// <summary>
        /// If this presentation node shows a related objective (for instance, if it tracks the progress of its children), the objective being tracked is indicated here.
        /// </summary>
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentNodes { get; }
        public PresentationNodeType PresentationNodeType { get; }
        /// <summary>
        /// The requirements for being able to interact with this presentation node and its children.
        /// </summary>
        public PresentationNodeRequirement Requirements { get; }
        /// <summary>
        /// Indicates whether this presentation node's state is determined on a per-character or on an account-wide basis.
        /// </summary>
        public Scope Scope { get; }
        /// <summary>
        /// A hint for how to display this presentation node when it's shown in its own detail screen.
        /// </summary>
        public int ScreenStyle { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; }
        public ReadOnlyCollection<string> TraitIds { get; }
        /// <summary>
        /// The original icon for this presentation node, before we futzed with it.
        /// </summary>
        public string OriginalIcon { get; }
        /// <summary>
        /// Some presentation nodes are meant to be explicitly shown on the "root" or "entry" screens for the feature to which they are related. You should use this icon when showing them on such a view, if you have a similar "entry point" view in your UI. If you don't have a UI, then I guess it doesn't matter either way does it?
        /// </summary>
        public string RootViewIcon { get; }
        /// <summary>
        /// If this presentation node has an associated "Record" that you can accomplish for completing its children, this is the Record.
        /// </summary>
        public DefinitionHashPointer<DestinyRecordDefinition> CompletionRecord { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyPresentationNodeDefinition(DestinyDefinitionDisplayProperties displayProperties, PresentationChildNode children, bool disableChildSubscreenNavigation,
            PresentationDisplayStyle displayStyle, int maxCategoryRecordScore, int nodeType, uint? objectiveHash, uint[] parentNodeHashes, PresentationNodeType presentationNodeType,
            PresentationNodeRequirement requirements, Scope scope, int screenStyle, uint[] traitHashes, string[] traitIds, string originalIcon, string rootViewIcon,
            uint? completionRecordHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            Children = children;
            DisableChildSubscreenNavigation = disableChildSubscreenNavigation;
            DisplayStyle = displayStyle;
            MaxCategoryRecordScore = maxCategoryRecordScore;
            NodeType = nodeType;
            Objective = new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
            ParentNodes = parentNodeHashes.DefinitionsAsReadOnlyOrEmpty<DestinyPresentationNodeDefinition>(DefinitionsEnum.DestinyPresentationNodeDefinition);
            PresentationNodeType = presentationNodeType;
            Requirements = requirements;
            Scope = scope;
            ScreenStyle = screenStyle;
            Traits = traitHashes.DefinitionsAsReadOnlyOrEmpty<DestinyTraitDefinition>(DefinitionsEnum.DestinyTraitDefinition);
            TraitIds = traitIds.AsReadOnlyOrEmpty();
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
            OriginalIcon = originalIcon;
            RootViewIcon = rootViewIcon;
            CompletionRecord = new DefinitionHashPointer<DestinyRecordDefinition>(completionRecordHash, DefinitionsEnum.DestinyRecordDefinition);
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyPresentationNodeDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   (Children != null ? Children.DeepEquals(other.Children) : other.Children == null) &&
                   DisableChildSubscreenNavigation == other.DisableChildSubscreenNavigation &&
                   DisplayStyle == other.DisplayStyle &&
                   MaxCategoryRecordScore == other.MaxCategoryRecordScore &&
                   NodeType == other.NodeType &&
                   Objective.DeepEquals(other.Objective) &&
                   ParentNodes.DeepEqualsReadOnlyCollections(other.ParentNodes) &&
                   PresentationNodeType == other.PresentationNodeType &&
                   (Requirements != null ? Requirements.DeepEquals(other.Requirements) : other.Requirements == null) &&
                   Scope == other.Scope &&
                   ScreenStyle == other.ScreenStyle &&
                   Traits.DeepEqualsReadOnlyCollections(other.Traits) &&
                   TraitIds.DeepEqualsReadOnlySimpleCollection(other.TraitIds) &&
                   OriginalIcon == other.OriginalIcon &&
                   RootViewIcon == other.RootViewIcon &&
                   CompletionRecord.DeepEquals(other.CompletionRecord) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public void MapValues()
        {
            if (Children != null)
            {
                foreach (var collectible in Children.Collectibles)
                {
                    collectible.Collectible.TryMapValue();
                }
                foreach (var metric in Children.Metrics)
                {
                    metric.Metric.TryMapValue();
                }
                foreach (var node in Children.PresentationNodes)
                {
                    node.PresentationNode.TryMapValue();
                }
                foreach (var record in Children.Records)
                {
                    record.Record.TryMapValue();
                }
            }
            Objective.TryMapValue();
            foreach (var node in ParentNodes)
            {
                node.TryMapValue();
            }
            foreach (var trait in Traits)
            {
                trait.TryMapValue();
            }
            CompletionRecord.TryMapValue();
        }
    }
}
