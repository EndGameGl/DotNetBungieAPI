namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     These are the definitions for Vendors.
/// <para />
///     In Destiny, a Vendor can be a lot of things - some things that you wouldn't expect, and some things that you don't even see directly in the game. Vendors are the Dolly Levi of the Destiny universe.
/// <para />
///     - Traditional Vendors as you see in game: people who you come up to and who give you quests, rewards, or who you can buy things from.
/// <para />
///     - Kiosks/Collections, which are really just Vendors that don't charge currency (or charge some pittance of a currency) and whose gating for purchases revolves more around your character's state.
/// <para />
///     - Previews for rewards or the contents of sacks. These are implemented as Vendors, where you can't actually purchase from them but the items that they have for sale and the categories of sale items reflect the rewards or contents of the sack. This is so that the game could reuse the existing Vendor display UI for rewards and save a bunch of wheel reinvention.
/// <para />
///     - Item Transfer capabilities, like the Vault and Postmaster. Vendors can have "acceptedItem" buckets that determine the source and destination buckets for transfers. When you interact with such a vendor, these buckets are what gets shown in the UI instead of any items that the Vendor would have for sale. Yep, the Vault is a vendor.
/// <para />
///     It is pretty much guaranteed that they'll be used for even more features in the future. They have come to be seen more as generic categorized containers for items than "vendors" in a traditional sense, for better or worse.
/// <para />
///     Where possible and time allows, we'll attempt to split those out into their own more digestible derived "Definitions": but often time does not allow that, as you can see from the above ways that vendors are used which we never split off from Vendor Definitions externally.
/// <para />
///     Since Vendors are so many things to so many parts of the game, the definition is understandably complex. You will want to combine this data with live Vendor information from the API when it is available.
/// </summary>
public class DestinyVendorDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.DestinyVendorDisplayPropertiesDefinition? DisplayProperties { get; set; }

    /// <summary>
    ///     The type of reward progression that this vendor has. Default - The original rank progression from token redemption. Ritual - Progression from ranks in ritual content. For example: Crucible (Shaxx), Gambit (Drifter), and Battlegrounds (War Table).
    /// </summary>
    [JsonPropertyName("vendorProgressionType")]
    public Destiny.DestinyVendorProgressionType VendorProgressionType { get; set; }

    /// <summary>
    ///     If the vendor has a custom localized string describing the "buy" action, that is returned here.
    /// </summary>
    [JsonPropertyName("buyString")]
    public string BuyString { get; set; }

    /// <summary>
    ///     Ditto for selling. Not that you can sell items to a vendor anymore. Will it come back? Who knows. The string's still there.
    /// </summary>
    [JsonPropertyName("sellString")]
    public string SellString { get; set; }

    /// <summary>
    ///     If the vendor has an item that should be displayed as the "featured" item, this is the hash identifier for that DestinyVendorItemDefinition.
    /// <para />
    ///     Apparently this is usually a related currency, like a reputation token. But it need not be restricted to that.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("displayItemHash")]
    public uint DisplayItemHash { get; set; }

    /// <summary>
    ///     If this is true, you aren't allowed to buy whatever the vendor is selling.
    /// </summary>
    [JsonPropertyName("inhibitBuying")]
    public bool InhibitBuying { get; set; }

    /// <summary>
    ///     If this is true, you're not allowed to sell whatever the vendor is buying.
    /// </summary>
    [JsonPropertyName("inhibitSelling")]
    public bool InhibitSelling { get; set; }

    /// <summary>
    ///     If the Vendor has a faction, this hash will be valid and point to a DestinyFactionDefinition.
    /// <para />
    ///     The game UI and BNet often mine the faction definition for additional elements and details to place on the screen, such as the faction's Progression status (aka "Reputation").
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyFactionDefinition>("Destiny.Definitions.DestinyFactionDefinition")]
    [JsonPropertyName("factionHash")]
    public uint FactionHash { get; set; }

    /// <summary>
    ///     A number used for calculating the frequency of a vendor's inventory resetting/refreshing.
    /// <para />
    ///     Don't worry about calculating this - we do it on the server side and send you the next refresh date with the live data.
    /// </summary>
    [JsonPropertyName("resetIntervalMinutes")]
    public int ResetIntervalMinutes { get; set; }

    /// <summary>
    ///     Again, used for reset/refreshing of inventory. Don't worry too much about it. Unless you want to.
    /// </summary>
    [JsonPropertyName("resetOffsetMinutes")]
    public int ResetOffsetMinutes { get; set; }

    /// <summary>
    ///     If an item can't be purchased from the vendor, there may be many "custom"/game state specific reasons why not.
    /// <para />
    ///     This is a list of localized strings with messages for those custom failures. The live BNet data will return a failureIndexes property for items that can't be purchased: using those values to index into this array, you can show the user the appropriate failure message for the item that can't be bought.
    /// </summary>
    [JsonPropertyName("failureStrings")]
    public string[]? FailureStrings { get; set; }

    /// <summary>
    ///     If we were able to predict the dates when this Vendor will be visible/available, this will be the list of those date ranges. Sadly, we're not able to predict this very frequently, so this will often be useless data.
    /// </summary>
    [JsonPropertyName("unlockRanges")]
    public Dates.DateRange[]? UnlockRanges { get; set; }

    /// <summary>
    ///     The internal identifier for the Vendor. A holdover from the old days of Vendors, but we don't have time to refactor it away.
    /// </summary>
    [JsonPropertyName("vendorIdentifier")]
    public string VendorIdentifier { get; set; }

    /// <summary>
    ///     A portrait of the Vendor's smiling mug. Or frothing tentacles.
    /// </summary>
    [JsonPropertyName("vendorPortrait")]
    public string VendorPortrait { get; set; }

    /// <summary>
    ///     If the vendor has a custom banner image, that can be found here.
    /// </summary>
    [JsonPropertyName("vendorBanner")]
    public string VendorBanner { get; set; }

    /// <summary>
    ///     If a vendor is not enabled, we won't even save the vendor's definition, and we won't return any items or info about them. It's as if they don't exist.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    /// <summary>
    ///     If a vendor is not visible, we still have and will give vendor definition info, but we won't use them for things like Advisors or UI.
    /// </summary>
    [JsonPropertyName("visible")]
    public bool Visible { get; set; }

    /// <summary>
    ///     The identifier of the VendorCategoryDefinition for this vendor's subcategory.
    /// </summary>
    [JsonPropertyName("vendorSubcategoryIdentifier")]
    public string VendorSubcategoryIdentifier { get; set; }

    /// <summary>
    ///     If TRUE, consolidate categories that only differ by trivial properties (such as having minor differences in name)
    /// </summary>
    [JsonPropertyName("consolidateCategories")]
    public bool ConsolidateCategories { get; set; }

    /// <summary>
    ///     Describes "actions" that can be performed on a vendor. Currently, none of these exist. But theoretically a Vendor could let you interact with it by performing actions. We'll see what these end up looking like if they ever get used.
    /// </summary>
    [JsonPropertyName("actions")]
    public Destiny.Definitions.DestinyVendorActionDefinition[]? Actions { get; set; }

    /// <summary>
    ///     These are the headers for sections of items that the vendor is selling. When you see items organized by category in the header, it is these categories that it is showing.
    /// <para />
    ///     Well, technically not *exactly* these. On BNet, it doesn't make sense to have categories be "paged" as we do in Destiny, so we run some heuristics to attempt to aggregate pages of categories together. 
    /// <para />
    ///     These are the categories post-concatenation, if the vendor had concatenation applied. If you want the pre-aggregated category data, use originalCategories.
    /// </summary>
    [JsonPropertyName("categories")]
    public Destiny.Definitions.DestinyVendorCategoryEntryDefinition[]? Categories { get; set; }

    /// <summary>
    ///     See the categories property for a description of categories and why originalCategories exists.
    /// </summary>
    [JsonPropertyName("originalCategories")]
    public Destiny.Definitions.DestinyVendorCategoryEntryDefinition[]? OriginalCategories { get; set; }

    /// <summary>
    ///     Display Categories are different from "categories" in that these are specifically for visual grouping and display of categories in Vendor UI. 
    /// <para />
    ///     The "categories" structure is for validation of the contained items, and can be categorized entirely separately from "Display Categories", there need be and often will be no meaningful relationship between the two.
    /// </summary>
    [JsonPropertyName("displayCategories")]
    public Destiny.Definitions.DestinyDisplayCategoryDefinition[]? DisplayCategories { get; set; }

    /// <summary>
    ///     In addition to selling items, vendors can have "interactions": UI where you "talk" with the vendor and they offer you a reward, some item, or merely acknowledge via dialog that you did something cool.
    /// </summary>
    [JsonPropertyName("interactions")]
    public Destiny.Definitions.DestinyVendorInteractionDefinition[]? Interactions { get; set; }

    /// <summary>
    ///     If the vendor shows you items from your own inventory - such as the Vault vendor does - this data describes the UI around showing those inventory buckets and which ones get shown.
    /// </summary>
    [JsonPropertyName("inventoryFlyouts")]
    public Destiny.Definitions.DestinyVendorInventoryFlyoutDefinition[]? InventoryFlyouts { get; set; }

    /// <summary>
    ///     If the vendor sells items (or merely has a list of items to show like the "Sack" vendors do), this is the list of those items that the vendor can sell. From this list, only a subset will be available from the vendor at any given time, selected randomly and reset on the vendor's refresh interval.
    /// <para />
    ///     Note that a vendor can sell the same item multiple ways: for instance, nothing stops a vendor from selling you some specific weapon but using two different currencies, or the same weapon at multiple "item levels".
    /// </summary>
    [JsonPropertyName("itemList")]
    public Destiny.Definitions.DestinyVendorItemDefinition[]? ItemList { get; set; }

    /// <summary>
    ///     BNet doesn't use this data yet, but it appears to be an optional list of flavor text about services that the Vendor can provide.
    /// </summary>
    [JsonPropertyName("services")]
    public Destiny.Definitions.DestinyVendorServiceDefinition[]? Services { get; set; }

    /// <summary>
    ///     If the Vendor is actually a vehicle for the transferring of items (like the Vault and Postmaster vendors), this defines the list of source->destination buckets for transferring.
    /// </summary>
    [JsonPropertyName("acceptedItems")]
    public Destiny.Definitions.DestinyVendorAcceptedItemDefinition[]? AcceptedItems { get; set; }

    /// <summary>
    ///     As many of you know, Vendor data has historically been pretty brutal on the BNet servers. In an effort to reduce this workload, only Vendors with this flag set will be returned on Vendor requests. This allows us to filter out Vendors that don't dynamic data that's particularly useful: things like "Preview/Sack" vendors, for example, that you can usually suss out the details for using just the definitions themselves.
    /// </summary>
    [JsonPropertyName("returnWithVendorRequest")]
    public bool ReturnWithVendorRequest { get; set; }

    /// <summary>
    ///     A vendor can be at different places in the world depending on the game/character/account state. This is the list of possible locations for the vendor, along with conditions we use to determine which one is currently active.
    /// </summary>
    [JsonPropertyName("locations")]
    public Destiny.Definitions.Vendors.DestinyVendorLocationDefinition[]? Locations { get; set; }

    /// <summary>
    ///     A vendor can be a part of 0 or 1 "groups" at a time: a group being a collection of Vendors related by either location or function/purpose. It's used for our our Companion Vendor UI. Only one of these can be active for a Vendor at a time.
    /// </summary>
    [JsonPropertyName("groups")]
    public Destiny.Definitions.DestinyVendorGroupReference[]? Groups { get; set; }

    /// <summary>
    ///     Some items don't make sense to return in the API, for example because they represent an action to be performed rather than an item being sold. I'd rather we not do this, but at least in the short term this is a workable workaround.
    /// </summary>
    [JsonPropertyName("ignoreSaleItemHashes")]
    public uint[]? IgnoreSaleItemHashes { get; set; }

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
