using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Definitions.Progressions;
using DotNetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Factions;

/// <summary>
///     These definitions represent Factions in the game. Factions have ended up unilaterally being related to Vendors that
///     represent them, but that need not necessarily be the case.
///     <para />
///     A Faction is really just an entity that has a related progression for which a character can gain experience.In
///     Destiny 1, Dead Orbit was an example of a Faction: there happens to be a Vendor that represents Dead Orbit (and
///     indeed, DestinyVendorDefinition.factionHash defines to this relationship), but Dead Orbit could theoretically exist
///     without the Vendor that provides rewards.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyFactionDefinition)]
public sealed record DestinyFactionDefinition : IDestinyDefinition, IDisplayProperties, IDeepEquatable<DestinyFactionDefinition>
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     DestinyProgressionDefinition that indicates the character's relationship with this faction in terms of experience
    ///     and levels.
    /// </summary>
    [JsonPropertyName("progressionHash")]
    public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; init; } =
        DefinitionHashPointer<DestinyProgressionDefinition>.Empty;

    /// <summary>
    ///     The faction token items, and their respective progression values.
    /// </summary>
    [JsonPropertyName("tokenValues")]
    public
        ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>,
            DefinitionHashPointer<DestinyProgressionDefinition>> TokenValues { get; init; } =
        ReadOnlyDictionaries<DefinitionHashPointer<DestinyInventoryItemDefinition>,
            DefinitionHashPointer<DestinyProgressionDefinition>>.Empty;

    /// <summary>
    ///     The faction reward item hash, usually an engram.
    /// </summary>
    [JsonPropertyName("rewardItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> RewardItem { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    /// <summary>
    ///     The faction reward vendor, used for faction engram previews.
    /// </summary>
    [JsonPropertyName("rewardVendorHash")]
    public DefinitionHashPointer<DestinyVendorDefinition> RewardVendor { get; init; } =
        DefinitionHashPointer<DestinyVendorDefinition>.Empty;

    /// <summary>
    ///     List of vendors that are associated with this faction. The last vendor that passes the unlock flag checks is the
    ///     one that should be shown.
    /// </summary>
    [JsonPropertyName("vendors")]
    public ReadOnlyCollection<DestinyFactionVendorDefinition> Vendors { get; init; } =
        ReadOnlyCollections<DestinyFactionVendorDefinition>.Empty;

    public bool DeepEquals(DestinyFactionDefinition other)
    {
        return other != null &&
               DisplayProperties.DeepEquals(other.DisplayProperties) &&
               Progression.DeepEquals(other.Progression) &&
               RewardItem.DeepEquals(other.RewardItem) &&
               RewardVendor.DeepEquals(other.RewardVendor) &&
               TokenValues.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(other.TokenValues) &&
               Vendors.DeepEqualsReadOnlyCollections(other.Vendors) &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyFactionDefinition;
    [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
    [JsonPropertyName("hash")] public uint Hash { get; init; }
    [JsonPropertyName("index")] public int Index { get; init; }
    [JsonPropertyName("redacted")] public bool Redacted { get; init; }
}