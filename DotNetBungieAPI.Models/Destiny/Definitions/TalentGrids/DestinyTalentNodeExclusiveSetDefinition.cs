namespace DotNetBungieAPI.Models.Destiny.Definitions.TalentGrids;

/// <summary>
///     The list of indexes into the Talent Grid's "nodes" property for nodes in this exclusive set. (See
///     DestinyTalentNodeDefinition.nodeIndex)
/// </summary>
public sealed record DestinyTalentNodeExclusiveSetDefinition
    : IDeepEquatable<DestinyTalentNodeExclusiveSetDefinition>
{
    /// <summary>
    ///     The list of node indexes for the exclusive set. Historically, these were indexes.
    /// </summary>
    [JsonPropertyName("nodeIndexes")]
    public ReadOnlyCollection<int> NodeIndexes { get; init; } = ReadOnlyCollections<int>.Empty;

    public bool DeepEquals(DestinyTalentNodeExclusiveSetDefinition other)
    {
        return other != null && NodeIndexes.DeepEqualsReadOnlySimpleCollection(other.NodeIndexes);
    }
}
