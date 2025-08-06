namespace DotNetBungieAPI.Models.Destiny.Definitions.Loadouts;

[DestinyDefinition(DefinitionsEnum.DestinyLoadoutConstantsDefinition)]
public sealed class DestinyLoadoutConstantsDefinition : IDestinyDefinition, IDisplayProperties
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyLoadoutConstantsDefinition;

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    /// <summary>
    ///     This is the same icon as the one in the display properties, offered here as well with a more descriptive name.
    /// </summary>
    [JsonPropertyName("whiteIconImagePath")]
    public string WhiteIconImagePath { get; init; }

    /// <summary>
    ///     This is a color-inverted version of the whiteIconImagePath.
    /// </summary>
    [JsonPropertyName("blackIconImagePath")]
    public string BlackIconImagePath { get; init; }

    /// <summary>
    ///     The maximum number of loadouts available to each character. The loadouts component API response can return fewer loadouts than this, as more loadouts are unlocked by reaching higher Guardian Ranks.
    /// </summary>
    [JsonPropertyName("loadoutCountPerCharacter")]
    public int LoadoutCountPerCharacter { get; init; }

    /// <summary>
    ///     A list of the socket category hashes to be filtered out of loadout item preview displays.
    /// </summary>
    [JsonPropertyName("loadoutPreviewFilterOutSocketCategoryHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Sockets.DestinySocketCategoryDefinition>[]? LoadoutPreviewFilterOutSocketCategoryHashes { get; init; }

    /// <summary>
    ///     A list of the socket type hashes to be filtered out of loadout item preview displays.
    /// </summary>
    [JsonPropertyName("loadoutPreviewFilterOutSocketTypeHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Sockets.DestinySocketTypeDefinition>[]? LoadoutPreviewFilterOutSocketTypeHashes { get; init; }

    /// <summary>
    ///     A list of the loadout name hashes in index order, for convenience.
    /// </summary>
    [JsonPropertyName("loadoutNameHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Loadouts.DestinyLoadoutNameDefinition>[]? LoadoutNameHashes { get; init; }

    /// <summary>
    ///     A list of the loadout icon hashes in index order, for convenience.
    /// </summary>
    [JsonPropertyName("loadoutIconHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Loadouts.DestinyLoadoutIconDefinition>[]? LoadoutIconHashes { get; init; }

    /// <summary>
    ///     A list of the loadout color hashes in index order, for convenience.
    /// </summary>
    [JsonPropertyName("loadoutColorHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Loadouts.DestinyLoadoutColorDefinition>[]? LoadoutColorHashes { get; init; }

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
