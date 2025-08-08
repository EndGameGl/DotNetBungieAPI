namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     Talent Grids on items have Nodes. These nodes have positions in the talent grid's UI, and contain "Steps" (DestinyTalentNodeStepDefinition), one of whom will be the "Current" step.
/// <para />
///     The Current Step determines the visual properties of the node, as well as what the node grants when it is activated.
/// <para />
///     See DestinyTalentGridDefinition for a more complete overview of how Talent Grids work, and how they are used in Destiny 2 (and how they were used in Destiny 1).
/// </summary>
public sealed class DestinyTalentNodeDefinition
{
    /// <summary>
    ///     The index into the DestinyTalentGridDefinition's "nodes" property where this node is located. Used to uniquely identify the node within the Talent Grid. Note that this is content version dependent: make sure you have the latest version of content before trying to use these properties.
    /// </summary>
    [JsonPropertyName("nodeIndex")]
    public int NodeIndex { get; init; }

    /// <summary>
    ///     The hash identifier for the node, which unfortunately is also content version dependent but can be (and ideally, should be) used instead of the nodeIndex to uniquely identify the node.
    /// <para />
    ///     The two exist side-by-side for backcompat reasons due to the Great Talent Node Restructuring of Destiny 1, and I ran out of time to remove one of them and standardize on the other. Sorry!
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
    ///     Indexes into the DestinyTalentGridDefinition.nodes property for any nodes that must be activated before this one is allowed to be activated.
    /// <para />
    ///     I would have liked to change this to hashes for Destiny 2, but we have run out of time.
    /// </summary>
    [JsonPropertyName("prerequisiteNodeIndexes")]
    public int[]? PrerequisiteNodeIndexes { get; init; }

    /// <summary>
    ///     At one point, Talent Nodes supported the idea of "Binary Pairs": nodes that overlapped each other visually, and where activating one deactivated the other. They ended up not being used, mostly because Exclusive Sets are *almost* a superset of this concept, but the potential for it to be used still exists in theory.
    /// <para />
    ///     If this is ever used, this will be the index into the DestinyTalentGridDefinition.nodes property for the node that is the binary pair match to this node. Activating one deactivates the other.
    /// </summary>
    [JsonPropertyName("binaryPairNodeIndex")]
    public int BinaryPairNodeIndex { get; init; }

    /// <summary>
    ///     If true, this node will automatically unlock when the Talent Grid's level reaches the required level of the current step of this node.
    /// </summary>
    [JsonPropertyName("autoUnlocks")]
    public bool AutoUnlocks { get; init; }

    /// <summary>
    ///     At one point, Nodes were going to be able to be activated multiple times, changing the current step and potentially piling on multiple effects from the previously activated steps. This property would indicate if the last step could be activated multiple times. 
    /// <para />
    ///     This is not currently used, but it isn't out of the question that this could end up being used again in a theoretical future.
    /// </summary>
    [JsonPropertyName("lastStepRepeats")]
    public bool LastStepRepeats { get; init; }

    /// <summary>
    ///     If this is true, the node's step is determined randomly rather than the first step being chosen.
    /// </summary>
    [JsonPropertyName("isRandom")]
    public bool IsRandom { get; init; }

    /// <summary>
    ///     At one point, you were going to be able to repurchase talent nodes that had random steps, to "re-roll" the current step of the node (and thus change the properties of your item). This was to be the activation requirement for performing that re-roll.
    /// <para />
    ///     The system still exists to do this, as far as I know, so it may yet come back around!
    /// </summary>
    [JsonPropertyName("randomActivationRequirement")]
    public Destiny.Definitions.DestinyNodeActivationRequirement? RandomActivationRequirement { get; init; }

    /// <summary>
    ///     If this is true, the node can be "re-rolled" to acquire a different random current step. This is not used, but still exists for a theoretical future of talent grids.
    /// </summary>
    [JsonPropertyName("isRandomRepurchasable")]
    public bool IsRandomRepurchasable { get; init; }

    /// <summary>
    ///     At this point, "steps" have been obfuscated into conceptual entities, aggregating the underlying notions of "properties" and "true steps".
    /// <para />
    ///     If you need to know a step as it truly exists - such as when recreating Node logic when processing Vendor data - you'll have to use the "realSteps" property below.
    /// </summary>
    [JsonPropertyName("steps")]
    public Destiny.Definitions.DestinyNodeStepDefinition[]? Steps { get; init; }

    /// <summary>
    ///     The nodeHash values for nodes that are in an Exclusive Set with this node.
    /// <para />
    ///     See DestinyTalentGridDefinition.exclusiveSets for more info about exclusive sets.
    /// <para />
    ///     Again, note that these are nodeHashes and *not* nodeIndexes.
    /// </summary>
    [JsonPropertyName("exclusiveWithNodeHashes")]
    public uint[]? ExclusiveWithNodeHashes { get; init; }

    /// <summary>
    ///     If the node's step is randomly selected, this is the amount of the Talent Grid's progression experience at which the progression bar for the node should be shown.
    /// </summary>
    [JsonPropertyName("randomStartProgressionBarAtProgression")]
    public int RandomStartProgressionBarAtProgression { get; init; }

    /// <summary>
    ///     A string identifier for a custom visual layout to apply to this talent node. Unfortunately, we do not have any data for rendering these custom layouts. It will be up to you to interpret these strings and change your UI if you want to have custom UI matching these layouts.
    /// </summary>
    [JsonPropertyName("layoutIdentifier")]
    public string LayoutIdentifier { get; init; }

    /// <summary>
    ///     As of Destiny 2, nodes can exist as part of "Exclusive Groups". These differ from exclusive sets in that, within the group, many nodes can be activated. But the act of activating any node in the group will cause "opposing" nodes (nodes in groups that are not allowed to be activated at the same time as this group) to deactivate.
    /// <para />
    ///     See DestinyTalentExclusiveGroup for more information on the details. This is an identifier for this node's group, if it is part of one.
    /// </summary>
    [JsonPropertyName("groupHash")]
    public uint? GroupHash { get; init; }

    /// <summary>
    ///     Talent nodes can be associated with a piece of Lore, generally rendered in a tooltip. This is the hash identifier of the lore element to show, if there is one to be show.
    /// </summary>
    [JsonPropertyName("loreHash")]
    public DefinitionHashPointer<Destiny.Definitions.Lore.DestinyLoreDefinition> LoreHash { get; init; }

    /// <summary>
    ///     Comes from the talent grid node style: this identifier should be used to determine how to render the node in the UI.
    /// </summary>
    [JsonPropertyName("nodeStyleIdentifier")]
    public string NodeStyleIdentifier { get; init; }

    /// <summary>
    ///     Comes from the talent grid node style: if true, then this node should be ignored for determining whether the grid is complete.
    /// </summary>
    [JsonPropertyName("ignoreForCompletion")]
    public bool IgnoreForCompletion { get; init; }
}
