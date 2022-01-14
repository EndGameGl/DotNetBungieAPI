namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

/// <summary>
///     The response for GetDestinyProfile, with components for character and item-level data.
/// </summary>
public sealed class DestinyProfileResponse
{

    /// <summary>
    ///     Recent, refundable purchases you have made from vendors. When will you use it? Couldn't say...
    /// <para />
    ///     COMPONENT TYPE: VendorReceipts
    /// </summary>
    [JsonPropertyName("vendorReceipts")]
    public SingleComponentResponseOfDestinyVendorReceiptsComponent VendorReceipts { get; init; }

    /// <summary>
    ///     The profile-level inventory of the Destiny Profile.
    /// <para />
    ///     COMPONENT TYPE: ProfileInventories
    /// </summary>
    [JsonPropertyName("profileInventory")]
    public SingleComponentResponseOfDestinyInventoryComponent ProfileInventory { get; init; }

    /// <summary>
    ///     The profile-level currencies owned by the Destiny Profile.
    /// <para />
    ///     COMPONENT TYPE: ProfileCurrencies
    /// </summary>
    [JsonPropertyName("profileCurrencies")]
    public SingleComponentResponseOfDestinyInventoryComponent ProfileCurrencies { get; init; }

    /// <summary>
    ///     The basic information about the Destiny Profile (formerly "Account").
    /// <para />
    ///     COMPONENT TYPE: Profiles
    /// </summary>
    [JsonPropertyName("profile")]
    public SingleComponentResponseOfDestinyProfileComponent Profile { get; init; }

    /// <summary>
    ///     Silver quantities for any platform on which this Profile plays destiny.
    /// <para />
    ///      COMPONENT TYPE: PlatformSilver
    /// </summary>
    [JsonPropertyName("platformSilver")]
    public SingleComponentResponseOfDestinyPlatformSilverComponent PlatformSilver { get; init; }

    /// <summary>
    ///     Items available from Kiosks that are available Profile-wide (i.e. across all characters)
    /// <para />
    ///     This component returns information about what Kiosk items are available to you on a *Profile* level. It is theoretically possible for Kiosks to have items gated by specific Character as well. If you ever have those, you will find them on the characterKiosks property.
    /// <para />
    ///     COMPONENT TYPE: Kiosks
    /// </summary>
    [JsonPropertyName("profileKiosks")]
    public SingleComponentResponseOfDestinyKiosksComponent ProfileKiosks { get; init; }

    /// <summary>
    ///     When sockets refer to reusable Plug Sets (see DestinyPlugSetDefinition for more info), this is the set of plugs and their states that are profile-scoped.
    /// <para />
    ///     This comes back with ItemSockets, as it is needed for a complete picture of the sockets on requested items.
    /// <para />
    ///     COMPONENT TYPE: ItemSockets
    /// </summary>
    [JsonPropertyName("profilePlugSets")]
    public SingleComponentResponseOfDestinyPlugSetsComponent ProfilePlugSets { get; init; }

    /// <summary>
    ///     When we have progression information - such as Checklists - that may apply profile-wide, it will be returned here rather than in the per-character progression data.
    /// <para />
    ///     COMPONENT TYPE: ProfileProgression
    /// </summary>
    [JsonPropertyName("profileProgression")]
    public SingleComponentResponseOfDestinyProfileProgressionComponent ProfileProgression { get; init; }

    /// <summary>
    ///     COMPONENT TYPE: PresentationNodes
    /// </summary>
    [JsonPropertyName("profilePresentationNodes")]
    public SingleComponentResponseOfDestinyPresentationNodesComponent ProfilePresentationNodes { get; init; }

    /// <summary>
    ///     COMPONENT TYPE: Records
    /// </summary>
    [JsonPropertyName("profileRecords")]
    public SingleComponentResponseOfDestinyProfileRecordsComponent ProfileRecords { get; init; }

    /// <summary>
    ///     COMPONENT TYPE: Collectibles
    /// </summary>
    [JsonPropertyName("profileCollectibles")]
    public SingleComponentResponseOfDestinyProfileCollectiblesComponent ProfileCollectibles { get; init; }

    /// <summary>
    ///     COMPONENT TYPE: Transitory
    /// </summary>
    [JsonPropertyName("profileTransitoryData")]
    public SingleComponentResponseOfDestinyProfileTransitoryComponent ProfileTransitoryData { get; init; }

    /// <summary>
    ///     COMPONENT TYPE: Metrics
    /// </summary>
    [JsonPropertyName("metrics")]
    public SingleComponentResponseOfDestinyMetricsComponent Metrics { get; init; }

    /// <summary>
    ///     COMPONENT TYPE: StringVariables
    /// </summary>
    [JsonPropertyName("profileStringVariables")]
    public SingleComponentResponseOfDestinyStringVariablesComponent ProfileStringVariables { get; init; }

    /// <summary>
    ///     Basic information about each character, keyed by the CharacterId.
    /// <para />
    ///     COMPONENT TYPE: Characters
    /// </summary>
    [JsonPropertyName("characters")]
    public DictionaryComponentResponseOfint64AndDestinyCharacterComponent Characters { get; init; }

    /// <summary>
    ///     The character-level non-equipped inventory items, keyed by the Character's Id.
    /// <para />
    ///     COMPONENT TYPE: CharacterInventories
    /// </summary>
    [JsonPropertyName("characterInventories")]
    public DictionaryComponentResponseOfint64AndDestinyInventoryComponent CharacterInventories { get; init; }

    /// <summary>
    ///     Character-level progression data, keyed by the Character's Id.
    /// <para />
    ///     COMPONENT TYPE: CharacterProgressions
    /// </summary>
    [JsonPropertyName("characterProgressions")]
    public DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent CharacterProgressions { get; init; }

    /// <summary>
    ///     Character rendering data - a minimal set of info needed to render a character in 3D - keyed by the Character's Id.
    /// <para />
    ///     COMPONENT TYPE: CharacterRenderData
    /// </summary>
    [JsonPropertyName("characterRenderData")]
    public DictionaryComponentResponseOfint64AndDestinyCharacterRenderComponent CharacterRenderData { get; init; }

    /// <summary>
    ///     Character activity data - the activities available to this character and its status, keyed by the Character's Id.
    /// <para />
    ///     COMPONENT TYPE: CharacterActivities
    /// </summary>
    [JsonPropertyName("characterActivities")]
    public DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponent CharacterActivities { get; init; }

    /// <summary>
    ///     The character's equipped items, keyed by the Character's Id.
    /// <para />
    ///     COMPONENT TYPE: CharacterEquipment
    /// </summary>
    [JsonPropertyName("characterEquipment")]
    public DictionaryComponentResponseOfint64AndDestinyInventoryComponent CharacterEquipment { get; init; }

    /// <summary>
    ///     Items available from Kiosks that are available to a specific character as opposed to the account as a whole. It must be combined with data from the profileKiosks property to get a full picture of the character's available items to check out of a kiosk.
    /// <para />
    ///     This component returns information about what Kiosk items are available to you on a *Character* level. Usually, kiosk items will be earned for the entire Profile (all characters) at once. To find those, look in the profileKiosks property.
    /// <para />
    ///     COMPONENT TYPE: Kiosks
    /// </summary>
    [JsonPropertyName("characterKiosks")]
    public DictionaryComponentResponseOfint64AndDestinyKiosksComponent CharacterKiosks { get; init; }

    /// <summary>
    ///     When sockets refer to reusable Plug Sets (see DestinyPlugSetDefinition for more info), this is the set of plugs and their states, per character, that are character-scoped.
    /// <para />
    ///     This comes back with ItemSockets, as it is needed for a complete picture of the sockets on requested items.
    /// <para />
    ///     COMPONENT TYPE: ItemSockets
    /// </summary>
    [JsonPropertyName("characterPlugSets")]
    public DictionaryComponentResponseOfint64AndDestinyPlugSetsComponent CharacterPlugSets { get; init; }

    /// <summary>
    ///     Do you ever get the feeling that a system was designed *too* flexibly? That it can be used in so many different ways that you end up being unable to provide an easy to use abstraction for the mess that's happening under the surface?
    /// <para />
    ///     Let's talk about character-specific data that might be related to items without instances. These two statements are totally unrelated, I promise.
    /// <para />
    ///     At some point during D2, it was decided that items - such as Bounties - could be given to characters and *not* have instance data, but that *could* display and even use relevant state information on your account and character.
    /// <para />
    ///     Up to now, any item that had meaningful dependencies on character or account state had to be instanced, and thus "itemComponents" was all that you needed: it was keyed by item's instance IDs and provided the stateful information you needed inside.
    /// <para />
    ///     Unfortunately, we don't live in such a magical world anymore. This is information held on a per-character basis about non-instanced items that the characters have in their inventory - or that reference character-specific state information even if it's in Account-level inventory - and the values related to that item's state in relation to the given character.
    /// <para />
    ///     To give a concrete example, look at a Moments of Triumph bounty. They exist in a character's inventory, and show/care about a character's progression toward completing the bounty. But the bounty itself is a non-instanced item, like a mod or a currency. This returns that data for the characters who have the bounty in their inventory.
    /// <para />
    ///     I'm not crying, you're crying Okay we're both crying but it's going to be okay I promise Actually I shouldn't promise that, I don't know if it's going to be okay
    /// </summary>
    [JsonPropertyName("characterUninstancedItemComponents")]
    public Dictionary<long, DestinyBaseItemComponentSetOfuint32> CharacterUninstancedItemComponents { get; init; }

    /// <summary>
    ///     COMPONENT TYPE: PresentationNodes
    /// </summary>
    [JsonPropertyName("characterPresentationNodes")]
    public DictionaryComponentResponseOfint64AndDestinyPresentationNodesComponent CharacterPresentationNodes { get; init; }

    /// <summary>
    ///     COMPONENT TYPE: Records
    /// </summary>
    [JsonPropertyName("characterRecords")]
    public DictionaryComponentResponseOfint64AndDestinyCharacterRecordsComponent CharacterRecords { get; init; }

    /// <summary>
    ///     COMPONENT TYPE: Collectibles
    /// </summary>
    [JsonPropertyName("characterCollectibles")]
    public DictionaryComponentResponseOfint64AndDestinyCollectiblesComponent CharacterCollectibles { get; init; }

    /// <summary>
    ///     COMPONENT TYPE: StringVariables
    /// </summary>
    [JsonPropertyName("characterStringVariables")]
    public DictionaryComponentResponseOfint64AndDestinyStringVariablesComponent CharacterStringVariables { get; init; }

    /// <summary>
    ///     Information about instanced items across all returned characters, keyed by the item's instance ID.
    /// <para />
    ///     COMPONENT TYPE: [See inside the DestinyItemComponentSet contract for component types.]
    /// </summary>
    [JsonPropertyName("itemComponents")]
    public DestinyItemComponentSetOfint64 ItemComponents { get; init; }

    /// <summary>
    ///     A "lookup" convenience component that can be used to quickly check if the character has access to items that can be used for purchasing.
    /// <para />
    ///     COMPONENT TYPE: CurrencyLookups
    /// </summary>
    [JsonPropertyName("characterCurrencyLookups")]
    public DictionaryComponentResponseOfint64AndDestinyCurrenciesComponent CharacterCurrencyLookups { get; init; }
}
