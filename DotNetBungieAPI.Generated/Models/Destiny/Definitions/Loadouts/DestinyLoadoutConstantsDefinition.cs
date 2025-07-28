namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Loadouts;

public class DestinyLoadoutConstantsDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    /// <summary>
    ///     This is the same icon as the one in the display properties, offered here as well with a more descriptive name.
    /// </summary>
    [JsonPropertyName("whiteIconImagePath")]
    public string WhiteIconImagePath { get; set; }

    /// <summary>
    ///     This is a color-inverted version of the whiteIconImagePath.
    /// </summary>
    [JsonPropertyName("blackIconImagePath")]
    public string BlackIconImagePath { get; set; }

    /// <summary>
    ///     The maximum number of loadouts available to each character. The loadouts component API response can return fewer loadouts than this, as more loadouts are unlocked by reaching higher Guardian Ranks.
    /// </summary>
    [JsonPropertyName("loadoutCountPerCharacter")]
    public int LoadoutCountPerCharacter { get; set; }

    /// <summary>
    ///     A list of the socket category hashes to be filtered out of loadout item preview displays.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Sockets.DestinySocketCategoryDefinition>("Destiny.Definitions.Sockets.DestinySocketCategoryDefinition")]
    [JsonPropertyName("loadoutPreviewFilterOutSocketCategoryHashes")]
    public uint[]? LoadoutPreviewFilterOutSocketCategoryHashes { get; set; }

    /// <summary>
    ///     A list of the socket type hashes to be filtered out of loadout item preview displays.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Sockets.DestinySocketTypeDefinition>("Destiny.Definitions.Sockets.DestinySocketTypeDefinition")]
    [JsonPropertyName("loadoutPreviewFilterOutSocketTypeHashes")]
    public uint[]? LoadoutPreviewFilterOutSocketTypeHashes { get; set; }

    /// <summary>
    ///     A list of the loadout name hashes in index order, for convenience.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Loadouts.DestinyLoadoutNameDefinition>("Destiny.Definitions.Loadouts.DestinyLoadoutNameDefinition")]
    [JsonPropertyName("loadoutNameHashes")]
    public uint[]? LoadoutNameHashes { get; set; }

    /// <summary>
    ///     A list of the loadout icon hashes in index order, for convenience.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Loadouts.DestinyLoadoutIconDefinition>("Destiny.Definitions.Loadouts.DestinyLoadoutIconDefinition")]
    [JsonPropertyName("loadoutIconHashes")]
    public uint[]? LoadoutIconHashes { get; set; }

    /// <summary>
    ///     A list of the loadout color hashes in index order, for convenience.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Loadouts.DestinyLoadoutColorDefinition>("Destiny.Definitions.Loadouts.DestinyLoadoutColorDefinition")]
    [JsonPropertyName("loadoutColorHashes")]
    public uint[]? LoadoutColorHashes { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }
}
