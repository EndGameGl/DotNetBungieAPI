namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

/// <summary>
///     The response for GetDestinyProfile, with components for character and item-level data.
/// </summary>
public class DestinyProfileResponse
{
    /// <summary>
    ///     Recent, refundable purchases you have made from vendors. When will you use it? Couldn't say...
    /// <para />
    ///     COMPONENT TYPE: VendorReceipts
    /// </summary>
    [JsonPropertyName("vendorReceipts")]
    public object VendorReceipts { get; set; }

    /// <summary>
    ///     The profile-level inventory of the Destiny Profile.
    /// <para />
    ///     COMPONENT TYPE: ProfileInventories
    /// </summary>
    [JsonPropertyName("profileInventory")]
    public object ProfileInventory { get; set; }

    /// <summary>
    ///     The profile-level currencies owned by the Destiny Profile.
    /// <para />
    ///     COMPONENT TYPE: ProfileCurrencies
    /// </summary>
    [JsonPropertyName("profileCurrencies")]
    public object ProfileCurrencies { get; set; }

    /// <summary>
    ///     The basic information about the Destiny Profile (formerly "Account").
    /// <para />
    ///     COMPONENT TYPE: Profiles
    /// </summary>
    [JsonPropertyName("profile")]
    public object Profile { get; set; }

    /// <summary>
    ///     Silver quantities for any platform on which this Profile plays destiny.
    /// <para />
    ///      COMPONENT TYPE: PlatformSilver
    /// </summary>
    [JsonPropertyName("platformSilver")]
    public object PlatformSilver { get; set; }

    /// <summary>
    ///     Items available from Kiosks that are available Profile-wide (i.e. across all characters)
    /// <para />
    ///     This component returns information about what Kiosk items are available to you on a *Profile* level. It is theoretically possible for Kiosks to have items gated by specific Character as well. If you ever have those, you will find them on the characterKiosks property.
    /// <para />
    ///     COMPONENT TYPE: Kiosks
    /// </summary>
    [JsonPropertyName("profileKiosks")]
    public object ProfileKiosks { get; set; }

    /// <summary>
    ///     When sockets refer to reusable Plug Sets (see DestinyPlugSetDefinition for more info), this is the set of plugs and their states that are profile-scoped.
    /// <para />
    ///     This comes back with ItemSockets, as it is needed for a complete picture of the sockets on requested items.
    /// <para />
    ///     COMPONENT TYPE: ItemSockets
    /// </summary>
    [JsonPropertyName("profilePlugSets")]
    public object ProfilePlugSets { get; set; }

    /// <summary>
    ///     When we have progression information - such as Checklists - that may apply profile-wide, it will be returned here rather than in the per-character progression data.
    /// <para />
    ///     COMPONENT TYPE: ProfileProgression
    /// </summary>
    [JsonPropertyName("profileProgression")]
    public object ProfileProgression { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: PresentationNodes
    /// </summary>
    [JsonPropertyName("profilePresentationNodes")]
    public object ProfilePresentationNodes { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: Records
    /// </summary>
    [JsonPropertyName("profileRecords")]
    public object ProfileRecords { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: Collectibles
    /// </summary>
    [JsonPropertyName("profileCollectibles")]
    public object ProfileCollectibles { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: Transitory
    /// </summary>
    [JsonPropertyName("profileTransitoryData")]
    public object ProfileTransitoryData { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: Metrics
    /// </summary>
    [JsonPropertyName("metrics")]
    public object Metrics { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: StringVariables
    /// </summary>
    [JsonPropertyName("profileStringVariables")]
    public object ProfileStringVariables { get; set; }

    /// <summary>
    ///     Basic information about each character, keyed by the CharacterId.
    /// <para />
    ///     COMPONENT TYPE: Characters
    /// </summary>
    [JsonPropertyName("characters")]
    public object Characters { get; set; }

    /// <summary>
    ///     The character-level non-equipped inventory items, keyed by the Character's Id.
    /// <para />
    ///     COMPONENT TYPE: CharacterInventories
    /// </summary>
    [JsonPropertyName("characterInventories")]
    public object CharacterInventories { get; set; }

    /// <summary>
    ///     Character-level progression data, keyed by the Character's Id.
    /// <para />
    ///     COMPONENT TYPE: CharacterProgressions
    /// </summary>
    [JsonPropertyName("characterProgressions")]
    public object CharacterProgressions { get; set; }

    /// <summary>
    ///     Character rendering data - a minimal set of info needed to render a character in 3D - keyed by the Character's Id.
    /// <para />
    ///     COMPONENT TYPE: CharacterRenderData
    /// </summary>
    [JsonPropertyName("characterRenderData")]
    public object CharacterRenderData { get; set; }

    /// <summary>
    ///     Character activity data - the activities available to this character and its status, keyed by the Character's Id.
    /// <para />
    ///     COMPONENT TYPE: CharacterActivities
    /// </summary>
    [JsonPropertyName("characterActivities")]
    public object CharacterActivities { get; set; }

    /// <summary>
    ///     The character's equipped items, keyed by the Character's Id.
    /// <para />
    ///     COMPONENT TYPE: CharacterEquipment
    /// </summary>
    [JsonPropertyName("characterEquipment")]
    public object CharacterEquipment { get; set; }

    /// <summary>
    ///     Items available from Kiosks that are available to a specific character as opposed to the account as a whole. It must be combined with data from the profileKiosks property to get a full picture of the character's available items to check out of a kiosk.
    /// <para />
    ///     This component returns information about what Kiosk items are available to you on a *Character* level. Usually, kiosk items will be earned for the entire Profile (all characters) at once. To find those, look in the profileKiosks property.
    /// <para />
    ///     COMPONENT TYPE: Kiosks
    /// </summary>
    [JsonPropertyName("characterKiosks")]
    public object CharacterKiosks { get; set; }

    /// <summary>
    ///     When sockets refer to reusable Plug Sets (see DestinyPlugSetDefinition for more info), this is the set of plugs and their states, per character, that are character-scoped.
    /// <para />
    ///     This comes back with ItemSockets, as it is needed for a complete picture of the sockets on requested items.
    /// <para />
    ///     COMPONENT TYPE: ItemSockets
    /// </summary>
    [JsonPropertyName("characterPlugSets")]
    public object CharacterPlugSets { get; set; }

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
    public Dictionary<long, DestinyBaseItemComponentSetOfuint32> CharacterUninstancedItemComponents { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: PresentationNodes
    /// </summary>
    [JsonPropertyName("characterPresentationNodes")]
    public object CharacterPresentationNodes { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: Records
    /// </summary>
    [JsonPropertyName("characterRecords")]
    public object CharacterRecords { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: Collectibles
    /// </summary>
    [JsonPropertyName("characterCollectibles")]
    public object CharacterCollectibles { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: StringVariables
    /// </summary>
    [JsonPropertyName("characterStringVariables")]
    public object CharacterStringVariables { get; set; }

    /// <summary>
    ///     COMPONENT TYPE: Craftables
    /// </summary>
    [JsonPropertyName("characterCraftables")]
    public object CharacterCraftables { get; set; }

    /// <summary>
    ///     Information about instanced items across all returned characters, keyed by the item's instance ID.
    /// <para />
    ///     COMPONENT TYPE: [See inside the DestinyItemComponentSet contract for component types.]
    /// </summary>
    [JsonPropertyName("itemComponents")]
    public object ItemComponents { get; set; }

    /// <summary>
    ///     A "lookup" convenience component that can be used to quickly check if the character has access to items that can be used for purchasing.
    /// <para />
    ///     COMPONENT TYPE: CurrencyLookups
    /// </summary>
    [JsonPropertyName("characterCurrencyLookups")]
    public object CharacterCurrencyLookups { get; set; }
}
