namespace DotNetBungieAPI.Models.Destiny.Definitions.Common;

public sealed class DestinyPathfinderConstantsDefinition
{
    /// <summary>
    ///     Pathfinder root node for The Pale Heart
    /// </summary>
    [JsonPropertyName("thePaleHeartPathfinderRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> ThePaleHeartPathfinderRootNodeHash { get; init; }

    /// <summary>
    ///     Root presentation nodes for all currently valid Pathfinder boards
    /// </summary>
    [JsonPropertyName("allPathfinderRootNodeHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>[]? AllPathfinderRootNodeHashes { get; init; }

    /// <summary>
    ///     The current shape of Pathfinder boards, where a Pathfinder board is stored as as flat list of Records. The key of this dictionary is the index at which a tier starts, and the value is the total number of objectives in the tier.
    /// </summary>
    [JsonPropertyName("pathfinderTreeTiers")]
    public Dictionary<uint, uint>? PathfinderTreeTiers { get; init; }

    /// <summary>
    ///     The topology of the Pathfinder board. The key is the index of the Record in the Pathfinder board, and the value is a list of the indices of Records that are connected to the Key Record. Using this topology, clients can ascertain if a Record can be unlocked, by checking if the objective of any connected Record has been completed and/or claimed.
    /// </summary>
    [JsonPropertyName("pathfinderTopology")]
    public Dictionary<uint, uint[]>? PathfinderTopology { get; init; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
