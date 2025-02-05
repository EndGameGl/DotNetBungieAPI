using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.SocketCategories;
using DotNetBungieAPI.Models.Destiny.Definitions.SocketTypes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Loadouts;

[DestinyDefinition(DefinitionsEnum.DestinyLoadoutConstantsDefinition)]
public sealed record DestinyLoadoutConstantsDefinition
    : IDestinyDefinition,
        IDeepEquatable<DestinyLoadoutConstantsDefinition>
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyLoadoutConstantsDefinition;

    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

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
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinySocketCategoryDefinition>
    > LoadoutPreviewFilterOutSocketCategories { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinySocketCategoryDefinition>>.Empty;

    /// <summary>
    ///     A list of the socket type hashes to be filtered out of loadout item preview displays.
    /// </summary>
    [JsonPropertyName("loadoutPreviewFilterOutSocketTypeHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinySocketTypeDefinition>
    > LoadoutPreviewFilterOutSocketTypes { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinySocketTypeDefinition>>.Empty;

    /// <summary>
    ///     A list of the loadout name hashes in index order, for convenience.
    /// </summary>
    [JsonPropertyName("loadoutNameHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyLoadoutNameDefinition>
    > LoadoutNames { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinyLoadoutNameDefinition>>.Empty;

    /// <summary>
    ///     A list of the loadout icon hashes in index order, for convenience.
    /// </summary>
    [JsonPropertyName("loadoutIconHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyLoadoutIconDefinition>
    > LoadoutIcons { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinyLoadoutIconDefinition>>.Empty;

    /// <summary>
    ///     A list of the loadout color hashes in index order, for convenience.
    /// </summary>
    [JsonPropertyName("loadoutColorHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyLoadoutColorDefinition>
    > LoadoutColors { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinyLoadoutColorDefinition>>.Empty;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }

    public bool DeepEquals(DestinyLoadoutConstantsDefinition other)
    {
        return other is not null
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && WhiteIconImagePath == other.WhiteIconImagePath
            && BlackIconImagePath == other.BlackIconImagePath
            && LoadoutCountPerCharacter == other.LoadoutCountPerCharacter
            && LoadoutPreviewFilterOutSocketCategories.DeepEqualsReadOnlyCollection(
                other.LoadoutPreviewFilterOutSocketCategories
            )
            && LoadoutPreviewFilterOutSocketTypes.DeepEqualsReadOnlyCollection(
                other.LoadoutPreviewFilterOutSocketTypes
            )
            && LoadoutNames.DeepEqualsReadOnlyCollection(other.LoadoutNames)
            && LoadoutIcons.DeepEqualsReadOnlyCollection(other.LoadoutIcons)
            && LoadoutColors.DeepEqualsReadOnlyCollection(other.LoadoutColors)
            && Blacklisted == other.Blacklisted
            && Hash == other.Hash
            && Index == other.Index
            && Redacted == other.Redacted;
    }
}
