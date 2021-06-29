using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Lores;

namespace NetBungieAPI.Models.Destiny.Definitions.TalentGrids
{
    /// <summary>
    ///     Talent Grids on items have Nodes. These nodes have positions in the talent grid's UI, and contain "Steps"
    ///     (DestinyTalentNodeStepDefinition), one of whom will be the "Current" step.
    ///     <para />
    ///     The Current Step determines the visual properties of the node, as well as what the node grants when it is
    ///     activated.
    ///     <para />
    ///     See DestinyTalentGridDefinition for a more complete overview of how Talent Grids work, and how they are used in
    ///     Destiny 2 (and how they were used in Destiny 1).
    /// </summary>
    public sealed record DestinyTalentNodeDefinition : IDeepEquatable<DestinyTalentNodeDefinition>
    {
        /// <summary>
        ///     The index into the DestinyTalentGridDefinition's "nodes" property where this node is located. Used to uniquely
        ///     identify the node within the Talent Grid. Note that this is content version dependent: make sure you have the
        ///     latest version of content before trying to use these properties.
        /// </summary>
        [JsonPropertyName("nodeIndex")]
        public int NodeIndex { get; init; }

        /// <summary>
        ///     The hash identifier for the node, which unfortunately is also content version dependent but can be (and ideally,
        ///     should be) used instead of the nodeIndex to uniquely identify the node.
        /// </summary>
        [JsonPropertyName("nodeHash")]
        public uint NodeHash { get; init; }

        /// <summary>
        ///     The visual "row" where the node should be shown in the UI. If negative, then the node is hidden.
        /// </summary>
        [JsonPropertyName("row")]
        public int Row { get; init; }

        /// <summary>
        ///     The visual "column" where the node should be shown in the UI. If negative, the node is hidden.
        /// </summary>
        [JsonPropertyName("column")]
        public int Column { get; init; }

        /// <summary>
        ///     Indexes into the DestinyTalentGridDefinition.nodes property for any nodes that must be activated before this one is
        ///     allowed to be activated.
        /// </summary>
        [JsonPropertyName("prerequisiteNodeIndexes")]
        public ReadOnlyCollection<int> PrerequisiteNodeIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();

        /// <summary>
        ///     At one point, Talent Nodes supported the idea of "Binary Pairs": nodes that overlapped each other visually, and
        ///     where activating one deactivated the other. They ended up not being used, mostly because Exclusive Sets are
        ///     *almost* a superset of this concept, but the potential for it to be used still exists in theory.
        ///     <para />
        ///     If this is ever used, this will be the index into the DestinyTalentGridDefinition.nodes property for the node that
        ///     is the binary pair match to this node. Activating one deactivates the other.
        /// </summary>
        [JsonPropertyName("binaryPairNodeIndex")]
        public int BinaryPairNodeIndex { get; init; }

        /// <summary>
        ///     If true, this node will automatically unlock when the Talent Grid's level reaches the required level of the current
        ///     step of this node.
        /// </summary>
        [JsonPropertyName("autoUnlocks")]
        public bool AutoUnlocks { get; init; }

        /// <summary>
        ///     At one point, Nodes were going to be able to be activated multiple times, changing the current step and potentially
        ///     piling on multiple effects from the previously activated steps. This property would indicate if the last step could
        ///     be activated multiple times.
        ///     <para />
        ///     This is not currently used, but it isn't out of the question that this could end up being used again in a
        ///     theoretical future.
        /// </summary>
        [JsonPropertyName("lastStepRepeats")]
        public bool LastStepRepeats { get; init; }

        /// <summary>
        ///     If this is true, the node's step is determined randomly rather than the first step being chosen.
        /// </summary>
        [JsonPropertyName("isRandom")]
        public bool IsRandom { get; init; }

        /// <summary>
        ///     At one point, you were going to be able to repurchase talent nodes that had random steps, to "re-roll" the current
        ///     step of the node (and thus change the properties of your item). This was to be the activation requirement for
        ///     performing that re-roll.
        ///     <para />
        ///     The system still exists to do this, as far as I know, so it may yet come back around!
        /// </summary>
        [JsonPropertyName("randomActivationRequirement")]
        public DestinyNodeActivationRequirement RandomActivationRequirement { get; init; }

        /// <summary>
        ///     If this is true, the node can be "re-rolled" to acquire a different random current step. This is not used, but
        ///     still exists for a theoretical future of talent grids.
        /// </summary>
        [JsonPropertyName("isRandomRepurchasable")]
        public bool IsRandomRepurchasable { get; init; }

        /// <summary>
        ///     At this point, "steps" have been obfuscated into conceptual entities, aggregating the underlying notions of
        ///     "properties" and "true steps".
        ///     <para />
        ///     If you need to know a step as it truly exists - such as when recreating Node logic when processing Vendor data -
        ///     you'll have to use the "realSteps" property below.
        /// </summary>
        [JsonPropertyName("steps")]
        public ReadOnlyCollection<DestinyNodeStepDefinition> Steps { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyNodeStepDefinition>();

        /// <summary>
        ///     The nodeHash values for nodes that are in an Exclusive Set with this node.
        ///     <para />
        ///     See DestinyTalentGridDefinition.exclusiveSets for more info about exclusive sets.
        ///     <para />
        ///     Again, note that these are nodeHashes and *not* nodeIndexes.
        /// </summary>
        [JsonPropertyName("exclusiveWithNodeHashes")]
        public ReadOnlyCollection<uint> ExclusiveWithNodeHashes { get; init; } =
            Defaults.EmptyReadOnlyCollection<uint>();

        /// <summary>
        ///     If the node's step is randomly selected, this is the amount of the Talent Grid's progression experience at which
        ///     the progression bar for the node should be shown.
        /// </summary>
        [JsonPropertyName("randomStartProgressionBarAtProgression")]
        public int RandomStartProgressionBarAtProgression { get; init; }

        /// <summary>
        ///     A string identifier for a custom visual layout to apply to this talent node. Unfortunately, we do not have any data
        ///     for rendering these custom layouts. It will be up to you to interpret these strings and change your UI if you want
        ///     to have custom UI matching these layouts.
        /// </summary>
        [JsonPropertyName("layoutIdentifier")]
        public string LayoutIdentifier { get; init; }

        /// <summary>
        ///     As of Destiny 2, nodes can exist as part of "Exclusive Groups". These differ from exclusive sets in that, within
        ///     the group, many nodes can be activated. But the act of activating any node in the group will cause "opposing" nodes
        ///     (nodes in groups that are not allowed to be activated at the same time as this group) to deactivate.
        ///     <para />
        ///     See DestinyTalentExclusiveGroup for more information on the details. This is an identifier for this node's group,
        ///     if it is part of one.
        /// </summary>
        [JsonPropertyName("groupHash")]
        public uint? GroupHash { get; init; }

        /// <summary>
        ///     Talent nodes can be associated with a piece of Lore, generally rendered in a tooltip. This is the
        ///     DestinyLoreDefinition of the lore element to show, if there is one to be show.
        /// </summary>
        [JsonPropertyName("loreHash")]
        public DefinitionHashPointer<DestinyLoreDefinition> Lore { get; init; } =
            DefinitionHashPointer<DestinyLoreDefinition>.Empty;

        /// <summary>
        ///     Comes from the talent grid node style: this identifier should be used to determine how to render the node in the
        ///     UI.
        /// </summary>
        [JsonPropertyName("nodeStyleIdentifier")]
        public string NodeStyleIdentifier { get; init; }

        /// <summary>
        ///     Comes from the talent grid node style: if true, then this node should be ignored for determining whether the grid
        ///     is complete.
        /// </summary>
        [JsonPropertyName("ignoreForCompletion")]
        public bool IgnoreForCompletion { get; init; }

        [JsonPropertyName("exclusiveSetHash")] public uint ExclusiveSetHash { get; init; }
        [JsonPropertyName("groupScopeIndex")] public int GroupScopeIndex { get; init; }

        [JsonPropertyName("isRealStepSelectionRandom")]
        public bool IsRealStepSelectionRandom { get; init; }

        [JsonPropertyName("originalNodeHash")] public uint OriginalNodeHash { get; init; }
        [JsonPropertyName("talentNodeTypes")] public int TalentNodeTypes { get; init; }

        public bool DeepEquals(DestinyTalentNodeDefinition other)
        {
            return other != null &&
                   NodeIndex == other.NodeIndex &&
                   NodeHash == other.NodeHash &&
                   Row == other.Row &&
                   Column == other.Column &&
                   PrerequisiteNodeIndexes.DeepEqualsReadOnlySimpleCollection(other.PrerequisiteNodeIndexes) &&
                   BinaryPairNodeIndex == other.BinaryPairNodeIndex &&
                   AutoUnlocks == other.AutoUnlocks &&
                   LastStepRepeats == other.LastStepRepeats &&
                   IsRandom == other.IsRandom &&
                   RandomActivationRequirement.DeepEquals(other.RandomActivationRequirement) &&
                   IsRandomRepurchasable == other.IsRandomRepurchasable &&
                   Steps.DeepEqualsReadOnlyCollections(other.Steps) &&
                   ExclusiveWithNodeHashes.DeepEqualsReadOnlySimpleCollection(other.ExclusiveWithNodeHashes) &&
                   RandomStartProgressionBarAtProgression == other.RandomStartProgressionBarAtProgression &&
                   LayoutIdentifier == other.LayoutIdentifier &&
                   GroupHash == other.GroupHash &&
                   Lore.DeepEquals(other.Lore) &&
                   NodeStyleIdentifier == other.NodeStyleIdentifier &&
                   IgnoreForCompletion == other.IgnoreForCompletion &&
                   ExclusiveSetHash == other.ExclusiveSetHash &&
                   GroupScopeIndex == other.GroupScopeIndex &&
                   IsRealStepSelectionRandom == other.IsRealStepSelectionRandom &&
                   OriginalNodeHash == other.OriginalNodeHash &&
                   TalentNodeTypes == other.TalentNodeTypes;
        }
    }
}