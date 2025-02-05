﻿using DotNetBungieAPI.Models.Destiny.Components;

namespace DotNetBungieAPI.Models.Destiny.Responses;

/// <summary>
///     The response for GetDestinyProfile, with components for character and item-level data.
/// </summary>
public sealed record DestinyProfileResponse
{
    /// <summary>
    ///     Recent, refundable purchases you have made from vendors. When will you use it? Couldn't say...
    /// </summary>
    [JsonPropertyName("vendorReceipts")]
    public SingleComponentResponseOfDestinyVendorReceiptsComponent VendorReceipts { get; init; }

    /// <summary>
    ///     The profile-level inventory of the Destiny Profile.
    /// </summary>
    [JsonPropertyName("profileInventory")]
    public SingleComponentResponseOfDestinyInventoryComponent ProfileInventory { get; init; }

    /// <summary>
    ///     The profile-level currencies owned by the Destiny Profile.
    /// </summary>
    [JsonPropertyName("profileCurrencies")]
    public SingleComponentResponseOfDestinyInventoryComponent ProfileCurrencies { get; init; }

    /// <summary>
    ///     The basic information about the Destiny Profile (formerly "Account").
    /// </summary>
    [JsonPropertyName("profile")]
    public SingleComponentResponseOfDestinyProfileComponent Profile { get; init; }

    /// <summary>
    ///     Silver quantities for any platform on which this Profile plays destiny.
    /// </summary>
    [JsonPropertyName("platformSilver")]
    public SingleComponentResponseOfDestinyPlatformSilverComponent PlatformSilver { get; init; }

    /// <summary>
    ///     Items available from Kiosks that are available Profile-wide (i.e. across all characters)
    ///     <para />
    ///     This component returns information about what Kiosk items are available to you on a *Profile* level. It is
    ///     theoretically possible for Kiosks to have items gated by specific Character as well. If you ever have those, you
    ///     will find them on the characterKiosks property.
    /// </summary>
    [JsonPropertyName("profileKiosks")]
    public SingleComponentResponseOfDestinyKiosksComponent ProfileKiosks { get; init; }

    /// <summary>
    ///     When sockets refer to reusable Plug Sets (see DestinyPlugSetDefinition for more info), this is the set of plugs and
    ///     their states that are profile-scoped.
    ///     <para />
    ///     This comes back with ItemSockets, as it is needed for a complete picture of the sockets on requested items.
    /// </summary>
    [JsonPropertyName("profilePlugSets")]
    public SingleComponentResponseOfDestinyPlugSetsComponent ProfilePlugSets { get; init; }

    /// <summary>
    ///     When we have progression information - such as Checklists - that may apply profile-wide, it will be returned here
    ///     rather than in the per-character progression data.
    /// </summary>
    [JsonPropertyName("profileProgression")]
    public SingleComponentResponseOfDestinyProfileProgressionComponent ProfileProgression { get; init; }

    [JsonPropertyName("profilePresentationNodes")]
    public SingleComponentResponseOfDestinyPresentationNodesComponent ProfilePresentationNodes { get; init; }

    [JsonPropertyName("profileRecords")]
    public SingleComponentResponseOfDestinyProfileRecordsComponent ProfileRecords { get; init; }

    [JsonPropertyName("profileCollectibles")]
    public SingleComponentResponseOfDestinyProfileCollectiblesComponent ProfileCollectibles { get; init; }

    [JsonPropertyName("profileTransitoryData")]
    public SingleComponentResponseOfDestinyProfileTransitoryComponent ProfileTransitoryData { get; init; }

    [JsonPropertyName("metrics")]
    public SingleComponentResponseOfDestinyMetricsComponent Metrics { get; init; }

    [JsonPropertyName("profileStringVariables")]
    public SingleComponentResponseOfDestinyStringVariablesComponent ProfileStringVariables { get; init; }

    /// <summary>
    ///     COMPONENT TYPE: SocialCommendations
    /// </summary>
    [JsonPropertyName("profileCommendations")]
    public SingleComponentResponseOfDestinySocialCommendationsComponent ProfileCommendations { get; init; }

    /// <summary>
    ///     Basic information about each character, keyed by the CharacterId.
    /// </summary>
    [JsonPropertyName("characters")]
    public DictionaryComponentResponseOfint64AndDestinyCharacterComponent Characters { get; init; }

    /// <summary>
    ///     The character-level non-equipped inventory items, keyed by the Character's Id.
    /// </summary>
    [JsonPropertyName("characterInventories")]
    public DictionaryComponentResponseOfint64AndDestinyInventoryComponent CharacterInventories { get; init; }

    /// <summary>
    ///     The character loadouts, keyed by the Character's Id.
    /// <para />
    ///     COMPONENT TYPE: CharacterLoadouts
    /// </summary>
    [JsonPropertyName("characterLoadouts")]
    public DictionaryComponentResponseOfint64AndDestinyLoadoutsComponent CharacterLoadouts { get; init; }

    /// <summary>
    ///     Character-level progression data, keyed by the Character's Id.
    /// </summary>
    [JsonPropertyName("characterProgressions")]
    public DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent CharacterProgressions { get; init; }

    /// <summary>
    ///     Character rendering data - a minimal set of info needed to render a character in 3D - keyed by the Character's Id.
    /// </summary>
    [JsonPropertyName("characterRenderData")]
    public DictionaryComponentResponseOfint64AndDestinyCharacterRenderComponent CharacterRenderData { get; init; }

    /// <summary>
    ///     Character activity data - the activities available to this character and its status, keyed by the Character's Id.
    /// </summary>
    [JsonPropertyName("characterActivities")]
    public DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponent CharacterActivities { get; init; }

    /// <summary>
    ///     The character's equipped items, keyed by the Character's Id.
    /// </summary>
    [JsonPropertyName("characterEquipment")]
    public DictionaryComponentResponseOfint64AndDestinyInventoryComponent CharacterEquipment { get; init; }

    /// <summary>
    ///     Items available from Kiosks that are available to a specific character as opposed to the account as a whole. It
    ///     must be combined with data from the profileKiosks property to get a full picture of the character's available items
    ///     to check out of a kiosk.
    ///     <para />
    ///     This component returns information about what Kiosk items are available to you on a *Character* level. Usually,
    ///     kiosk items will be earned for the entire Profile (all characters) at once. To find those, look in the
    ///     profileKiosks property.
    /// </summary>
    [JsonPropertyName("characterKiosks")]
    public DictionaryComponentResponseOfint64AndDestinyKiosksComponent CharacterKiosks { get; init; }

    /// <summary>
    ///     When sockets refer to reusable Plug Sets (see DestinyPlugSetDefinition for more info), this is the set of plugs and
    ///     their states, per character, that are character-scoped.
    ///     <para />
    ///     This comes back with ItemSockets, as it is needed for a complete picture of the sockets on requested items.
    /// </summary>
    [JsonPropertyName("characterPlugSets")]
    public DictionaryComponentResponseOfint64AndDestinyPlugSetsComponent CharacterPlugSets { get; init; }

    /// <summary>
    ///     Do you ever get the feeling that a system was designed *too* flexibly? That it can be used in so many different
    ///     ways that you end up being unable to provide an easy to use abstraction for the mess that's happening under the
    ///     surface?
    ///     <para />
    ///     Let's talk about character-specific data that might be related to items without instances. These two statements are
    ///     totally unrelated, I promise.
    ///     <para />
    ///     At some point during D2, it was decided that items - such as Bounties - could be given to characters and *not* have
    ///     instance data, but that *could* display and even use relevant state information on your account and character.
    ///     <para />
    ///     Up to now, any item that had meaningful dependencies on character or account state had to be instanced, and thus
    ///     "itemComponents" was all that you needed: it was keyed by item's instance IDs and provided the stateful information
    ///     you needed inside.
    ///     <para />
    ///     Unfortunately, we don't live in such a magical world anymore. This is information held on a per-character basis
    ///     about non-instanced items that the characters have in their inventory - or that reference character-specific state
    ///     information even if it's in Account-level inventory - and the values related to that item's state in relation to
    ///     the given character.
    ///     <para />
    ///     To give a concrete example, look at a Moments of Triumph bounty. They exist in a character's inventory, and
    ///     show/care about a character's progression toward completing the bounty. But the bounty itself is a non-instanced
    ///     item, like a mod or a currency. This returns that data for the characters who have the bounty in their inventory.
    /// </summary>
    [JsonPropertyName("characterUninstancedItemComponents")]
    public ReadOnlyDictionary<
        long,
        DestinyBaseItemComponentSetOfuint32
    > CharacterUninstancedItemComponents { get; init; } =
        ReadOnlyDictionary<long, DestinyBaseItemComponentSetOfuint32>.Empty;

    [JsonPropertyName("characterPresentationNodes")]
    public DictionaryComponentResponseOfint64AndDestinyPresentationNodesComponent CharacterPresentationNodes { get; init; }

    [JsonPropertyName("characterRecords")]
    public DictionaryComponentResponseOfint64AndDestinyCharacterRecordsComponent CharacterRecords { get; init; }

    [JsonPropertyName("characterCollectibles")]
    public DictionaryComponentResponseOfint64AndDestinyCollectiblesComponent CharacterCollectibles { get; init; }

    [JsonPropertyName("characterStringVariables")]
    public DictionaryComponentResponseOfint64AndDestinyStringVariablesComponent CharacterStringVariables { get; init; }

    /// <summary>
    ///     COMPONENT TYPE: Craftables
    /// </summary>
    [JsonPropertyName("characterCraftables")]
    public DictionaryComponentResponseOfint64AndDestinyCraftablesComponent CharacterCraftables { get; init; }

    /// <summary>
    ///     Information about instanced items across all returned characters, keyed by the item's instance ID.
    /// </summary>
    [JsonPropertyName("itemComponents")]
    public DestinyItemComponentSetOfint64 ItemComponents { get; init; }

    /// <summary>
    ///     A "lookup" convenience component that can be used to quickly check if the character has access to items that can be
    ///     used for purchasing.
    /// </summary>
    [JsonPropertyName("characterCurrencyLookups")]
    public DictionaryComponentResponseOfint64AndDestinyCurrenciesComponent CharacterCurrencyLookups { get; init; }

    /// <summary>
    ///     Records the timestamp of when most components were last generated from the world server source. Unless the component type is specified in the documentation for secondaryComponentsMintedTimestamp, this value is sufficient to do data freshness.
    /// </summary>
    [JsonPropertyName("responseMintedTimestamp")]
    public DateTime? ResponseMintedTimestamp { get; init; }

    /// <summary>
    ///     Some secondary components are not tracked in the primary response timestamp and have their timestamp tracked here. If your component is any of the following, this field is where you will find your timestamp value:
    /// <para />
    ///      PresentationNodes, Records, Collectibles, Metrics, StringVariables, Craftables, Transitory
    /// <para />
    ///      All other component types may use the primary timestamp property.
    /// </summary>
    [JsonPropertyName("secondaryComponentsMintedTimestamp")]
    public DateTime? SecondaryComponentsMintedTimestamp { get; init; }
}
