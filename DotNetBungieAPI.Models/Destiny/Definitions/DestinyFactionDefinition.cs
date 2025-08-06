namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     These definitions represent Factions in the game. Factions have ended up unilaterally being related to Vendors that represent them, but that need not necessarily be the case.
/// <para />
///     A Faction is really just an entity that has a related progression for which a character can gain experience. In Destiny 1, Dead Orbit was an example of a Faction: there happens to be a Vendor that represents Dead Orbit (and indeed, DestinyVendorDefinition.factionHash defines to this relationship), but Dead Orbit could theoretically exist without the Vendor that provides rewards.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyFactionDefinition)]
public sealed class DestinyFactionDefinition : IDestinyDefinition, IDisplayProperties
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyFactionDefinition;

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    /// <summary>
    ///     The hash identifier for the DestinyProgressionDefinition that indicates the character's relationship with this faction in terms of experience and levels.
    /// </summary>
    [JsonPropertyName("progressionHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyProgressionDefinition> ProgressionHash { get; init; }

    /// <summary>
    ///     The faction token item hashes, and their respective progression values.
    /// </summary>
    [JsonPropertyName("tokenValues")]
    public Dictionary<uint, uint>? TokenValues { get; init; }

    /// <summary>
    ///     The faction reward item hash, usually an engram.
    /// </summary>
    [JsonPropertyName("rewardItemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition> RewardItemHash { get; init; }

    /// <summary>
    ///     The faction reward vendor hash, used for faction engram previews.
    /// </summary>
    [JsonPropertyName("rewardVendorHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyVendorDefinition> RewardVendorHash { get; init; }

    /// <summary>
    ///     List of vendors that are associated with this faction. The last vendor that passes the unlock flag checks is the one that should be shown.
    /// </summary>
    [JsonPropertyName("vendors")]
    public Destiny.Definitions.DestinyFactionVendorDefinition[]? Vendors { get; init; }

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
