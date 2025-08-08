namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     As of Destiny 2, nodes can exist as part of "Exclusive Groups". These differ from exclusive sets in that, within the group, many nodes can be activated. But the act of activating any node in the group will cause "opposing" nodes (nodes in groups that are not allowed to be activated at the same time as this group) to deactivate.
/// </summary>
public sealed class DestinyTalentExclusiveGroup
{
    /// <summary>
    ///     The identifier for this exclusive group. Only guaranteed unique within the talent grid, not globally.
    /// </summary>
    [JsonPropertyName("groupHash")]
    public uint GroupHash { get; init; }

    /// <summary>
    ///     If this group has an associated piece of lore to show next to it, this will be the identifier for that DestinyLoreDefinition.
    /// </summary>
    [JsonPropertyName("loreHash")]
    public DefinitionHashPointer<Destiny.Definitions.Lore.DestinyLoreDefinition> LoreHash { get; init; }

    /// <summary>
    ///     A quick reference of the talent nodes that are part of this group, by their Talent Node hashes. (See DestinyTalentNodeDefinition.nodeHash)
    /// </summary>
    [JsonPropertyName("nodeHashes")]
    public uint[]? NodeHashes { get; init; }

    /// <summary>
    ///     A quick reference of Groups whose nodes will be deactivated if any node in this group is activated.
    /// </summary>
    [JsonPropertyName("opposingGroupHashes")]
    public uint[]? OpposingGroupHashes { get; init; }

    /// <summary>
    ///     A quick reference of Nodes that will be deactivated if any node in this group is activated, by their Talent Node hashes. (See DestinyTalentNodeDefinition.nodeHash)
    /// </summary>
    [JsonPropertyName("opposingNodeHashes")]
    public uint[]? OpposingNodeHashes { get; init; }
}
