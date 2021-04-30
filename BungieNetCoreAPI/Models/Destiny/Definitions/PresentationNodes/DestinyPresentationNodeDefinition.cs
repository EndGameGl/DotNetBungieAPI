using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.Objectives;
using NetBungieAPI.Models.Destiny.Definitions.Records;
using NetBungieAPI.Models.Destiny.Definitions.Traits;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.PresentationNodes
{
    /// <summary>
    /// A PresentationNode is an entity that represents a logical grouping of other entities visually/organizationally.
    /// <para/>
    /// For now, Presentation Nodes may contain the following...but it may be used for more in the future:
    /// <para/>
    /// - Collectibles - Records(Or, as the public will call them, "Triumphs." Don't ask me why we're overloading the term "Triumph", it still hurts me to think about it) - Metrics(aka Stat Trackers) - Other Presentation Nodes, allowing a tree of Presentation Nodes to be created
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyPresentationNodeDefinition)]
    public sealed record DestinyPresentationNodeDefinition : IDestinyDefinition, IDeepEquatable<DestinyPresentationNodeDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        /// <summary>
        /// The original icon for this presentation node, before we futzed with it.
        /// </summary>
        [JsonPropertyName("originalIcon")]
        public string OriginalIcon { get; init; }
        /// <summary>
        /// Some presentation nodes are meant to be explicitly shown on the "root" or "entry" screens for the feature to which they are related. You should use this icon when showing them on such a view, if you have a similar "entry point" view in your UI. If you don't have a UI, then I guess it doesn't matter either way does it?
        /// </summary>
        [JsonPropertyName("rootViewIcon")]
        public string RootViewIcon { get; init; }
        [JsonPropertyName("nodeType")]
        public int NodeType { get; init; }
        /// <summary>
        /// Indicates whether this presentation node's state is determined on a per-character or on an account-wide basis.
        /// </summary>
        [JsonPropertyName("scope")]
        public DestinyScope Scope { get; init; }
        /// <summary>
        /// If this presentation node shows a related objective (for instance, if it tracks the progress of its children), the objective being tracked is indicated here.
        /// </summary>
        [JsonPropertyName("objectiveHash")]
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; init; } = DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;
        /// <summary>
        /// If this presentation node has an associated "Record" that you can accomplish for completing its children, this is the Record.
        /// </summary>
        [JsonPropertyName("completionRecordHash")]
        public DefinitionHashPointer<DestinyRecordDefinition> CompletionRecord { get; init; } = DefinitionHashPointer<DestinyRecordDefinition>.Empty;
        /// <summary>
        /// The child entities contained by this presentation node.
        /// </summary>
        [JsonPropertyName("children")]
        public DestinyPresentationNodeChildrenBlock Children { get; init; }
        /// <summary>
        /// A hint for how to display this presentation node when it's shown in a list.
        /// </summary>
        [JsonPropertyName("displayStyle")]
        public DestinyPresentationDisplayStyle DisplayStyle { get; init; }
        /// <summary>
        /// A hint for how to display this presentation node when it's shown in its own detail screen.
        /// </summary>
        [JsonPropertyName("screenStyle")]
        public int ScreenStyle { get; init; }
        /// <summary>
        /// The requirements for being able to interact with this presentation node and its children.
        /// </summary>
        [JsonPropertyName("requirements")]
        public DestinyPresentationNodeRequirementsBlock Requirements { get; init; }
        /// <summary>
        /// If this presentation node has children, but the game doesn't let you inspect the details of those children, that is indicated here.
        /// </summary>
        [JsonPropertyName("disableChildSubscreenNavigation")]
        public bool DisableChildSubscreenNavigation { get; init; }
        [JsonPropertyName("maxCategoryRecordScore")]
        public int MaxCategoryRecordScore { get; init; }
        [JsonPropertyName("presentationNodeType")]
        public DestinyPresentationNodeType PresentationNodeType { get; init; }
        [JsonPropertyName("traitIds")]
        public ReadOnlyCollection<string> TraitIds { get; init; } = Defaults.EmptyReadOnlyCollection<string>();
        [JsonPropertyName("traitHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>>();
        [JsonPropertyName("parentNodeHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentNodes { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>>();        
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

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
