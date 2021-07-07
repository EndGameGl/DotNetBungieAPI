using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Dates;
using NetBungieAPI.Models.Destiny.Definitions.Factions;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    /// <summary>
    ///     These are the definitions for Vendors.
    ///     <para />
    ///     In Destiny, a Vendor can be a lot of things - some things that you wouldn't expect, and some things that you don't
    ///     even see directly in the game. Vendors are the Dolly Levi of the Destiny universe.
    ///     <para />
    ///     - Traditional Vendors as you see in game: people who you come up to and who give you quests, rewards, or who you
    ///     can buy things from.
    ///     <para />
    ///     - Kiosks/Collections, which are really just Vendors that don't charge currency (or charge some pittance of a
    ///     currency) and whose gating for purchases revolves more around your character's state.
    ///     <para />
    ///     - Previews for rewards or the contents of sacks. These are implemented as Vendors, where you can't actually
    ///     purchase from them but the items that they have for sale and the categories of sale items reflect the rewards or
    ///     contents of the sack. This is so that the game could reuse the existing Vendor display UI for rewards and save a
    ///     bunch of wheel reinvention.
    ///     <para />
    ///     - Item Transfer capabilities, like the Vault and Postmaster. Vendors can have "acceptedItem" buckets that determine
    ///     the source and destination buckets for transfers. When you interact with such a vendor, these buckets are what gets
    ///     shown in the UI instead of any items that the Vendor would have for sale. Yep, the Vault is a vendor.
    ///     <para />
    ///     It is pretty much guaranteed that they'll be used for even more features in the future. They have come to be seen
    ///     more as generic categorized containers for items than "vendors" in a traditional sense, for better or worse.
    ///     <para />
    ///     Where possible and time allows, we'll attempt to split those out into their own more digestible derived
    ///     "Definitions": but often time does not allow that, as you can see from the above ways that vendors are used which
    ///     we never split off from Vendor Definitions externally.
    ///     <para />
    ///     Since Vendors are so many things to so many parts of the game, the definition is understandably complex. You will
    ///     want to combine this data with live Vendor information from the API when it is available.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyVendorDefinition)]
    public sealed record DestinyVendorDefinition : IDestinyDefinition, IDeepEquatable<DestinyVendorDefinition>
    {
        /// <summary>
        ///     Display properties of this vendor
        /// </summary>
        [JsonPropertyName("displayProperties")]
        public DestinyVendorDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        ///     The type of reward progression that this vendor has. Default - The original rank progression from token redemption.
        ///     Ritual - Progression from ranks in ritual content. For example: Crucible (Shaxx), Gambit (Drifter), and
        ///     Battlegrounds (War Table).
        /// </summary>
        [JsonPropertyName("vendorProgressionType")]
        public DestinyVendorProgressionType VendorProgressionType { get; init; }

        /// <summary>
        ///     If the vendor has a custom localized string describing the "buy" action, that is returned here.
        /// </summary>
        [JsonPropertyName("buyString")]
        public string BuyString { get; init; }

        /// <summary>
        ///     Ditto for selling. Not that you can sell items to a vendor anymore. Will it come back? Who knows. The string's
        ///     still there.
        /// </summary>
        [JsonPropertyName("sellString")]
        public string SellString { get; init; }

        /// <summary>
        ///     If the vendor has an item that should be displayed as the "featured" item, this is the hash identifier for that
        ///     DestinyVendorItemDefinition.
        ///     <para />
        ///     Apparently this is usually a related currency, like a reputation token. But it need not be restricted to that.
        /// </summary>
        [JsonPropertyName("displayItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> DisplayItem { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        /// <summary>
        ///     If this is true, you aren't allowed to buy whatever the vendor is selling.
        /// </summary>
        [JsonPropertyName("inhibitBuying")]
        public bool InhibitBuying { get; init; }

        /// <summary>
        ///     If this is true, you're not allowed to sell whatever the vendor is buying.
        /// </summary>
        [JsonPropertyName("inhibitSelling")]
        public bool InhibitSelling { get; init; }

        /// <summary>
        ///     If the Vendor has a faction, this hash will be valid and point to a DestinyFactionDefinition.
        ///     <para />
        ///     The game UI and BNet often mine the faction definition for additional elements and details to place on the screen,
        ///     such as the faction's Progression status (aka "Reputation").
        /// </summary>
        [JsonPropertyName("factionHash")]
        public DefinitionHashPointer<DestinyFactionDefinition> Faction { get; init; } =
            DefinitionHashPointer<DestinyFactionDefinition>.Empty;

        /// <summary>
        ///     A number used for calculating the frequency of a vendor's inventory resetting/refreshing.
        ///     <para />
        ///     Don't worry about calculating this - we do it on the server side and send you the next refresh date with the live
        ///     data.
        /// </summary>
        [JsonPropertyName("resetIntervalMinutes")]
        public int ResetIntervalMinutes { get; init; }

        /// <summary>
        ///     Again, used for reset/refreshing of inventory. Don't worry too much about it. Unless you want to.
        /// </summary>
        [JsonPropertyName("resetOffsetMinutes")]
        public int ResetOffsetMinutes { get; init; }

        /// <summary>
        ///     If an item can't be purchased from the vendor, there may be many "custom"/game state specific reasons why not.
        ///     <para />
        ///     This is a list of localized strings with messages for those custom failures. The live BNet data will return a
        ///     failureIndexes property for items that can't be purchased: using those values to index into this array, you can
        ///     show the user the appropriate failure message for the item that can't be bought.
        /// </summary>
        [JsonPropertyName("failureStrings")]
        public ReadOnlyCollection<string> FailureStrings { get; init; } = Defaults.EmptyReadOnlyCollection<string>();

        /// <summary>
        ///     If we were able to predict the dates when this Vendor will be visible/available, this will be the list of those
        ///     date ranges. Sadly, we're not able to predict this very frequently, so this will often be useless data.
        /// </summary>
        [JsonPropertyName("unlockRanges")]
        public ReadOnlyCollection<DateRange> UnlockRanges { get; init; } =
            Defaults.EmptyReadOnlyCollection<DateRange>();

        /// <summary>
        ///     The internal identifier for the Vendor. A holdover from the old days of Vendors, but we don't have time to refactor
        ///     it away.
        /// </summary>
        [JsonPropertyName("vendorIdentifier")]
        public string VendorIdentifier { get; init; }

        /// <summary>
        ///     A portrait of the Vendor's smiling mug. Or frothing tentacles.
        /// </summary>
        [JsonPropertyName("vendorPortrait")]
        public DestinyResource VendorPortrait { get; init; }

        /// <summary>
        ///     If the vendor has a custom banner image, that can be found here.
        /// </summary>
        [JsonPropertyName("vendorBanner")]
        public DestinyResource VendorBanner { get; init; }

        /// <summary>
        ///     If a vendor is not enabled, we won't even save the vendor's definition, and we won't return any items or info about
        ///     them. It's as if they don't exist.
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; init; }

        /// <summary>
        ///     If a vendor is not visible, we still have and will give vendor definition info, but we won't use them for things
        ///     like Advisors or UI.
        /// </summary>
        [JsonPropertyName("visible")]
        public bool Visible { get; init; }

        /// <summary>
        ///     The identifier of the VendorCategoryDefinition for this vendor's subcategory.
        /// </summary>
        [JsonPropertyName("vendorSubcategoryIdentifier")]
        public string VendorSubcategoryIdentifier { get; init; }

        /// <summary>
        ///     If TRUE, consolidate categories that only differ by trivial properties (such as having minor differences in name)
        /// </summary>
        [JsonPropertyName("consolidateCategories")]
        public bool ConsolidateCategories { get; init; }

        /// <summary>
        ///     Describes "actions" that can be performed on a vendor. Currently, none of these exist. But theoretically a Vendor
        ///     could let you interact with it by performing actions. We'll see what these end up looking like if they ever get
        ///     used.
        /// </summary>
        [JsonPropertyName("actions")]
        public ReadOnlyCollection<DestinyVendorActionDefinition> Actions { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyVendorActionDefinition>();

        /// <summary>
        ///     These are the headers for sections of items that the vendor is selling. When you see items organized by category in
        ///     the header, it is these categories that it is showing.
        ///     <para />
        ///     Well, technically not *exactly* these. On BNet, it doesn't make sense to have categories be "paged" as we do in
        ///     Destiny, so we run some heuristics to attempt to aggregate pages of categories together.
        ///     <para />
        ///     These are the categories post-concatenation, if the vendor had concatenation applied. If you want the
        ///     pre-aggregated category data, use originalCategories.
        /// </summary>
        [JsonPropertyName("categories")]
        public ReadOnlyCollection<DestinyVendorCategoryEntryDefinition> Categories { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyVendorCategoryEntryDefinition>();

        /// <summary>
        ///     See the categories property for a description of categories and why OriginalCategories exists.
        /// </summary>
        [JsonPropertyName("originalCategories")]
        public ReadOnlyCollection<DestinyVendorCategoryEntryDefinition> OriginalCategories { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyVendorCategoryEntryDefinition>();

        /// <summary>
        ///     Display Categories are different from "categories" in that these are specifically for visual grouping and display
        ///     of categories in Vendor UI.
        ///     <para />
        ///     The "categories" structure is for validation of the contained items, and can be categorized entirely separately
        ///     from "Display Categories", there need be and often will be no meaningful relationship between the two.
        /// </summary>
        [JsonPropertyName("displayCategories")]
        public ReadOnlyCollection<DestinyDisplayCategoryDefinition> DisplayCategories { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyDisplayCategoryDefinition>();

        /// <summary>
        ///     In addition to selling items, vendors can have "interactions": UI where you "talk" with the vendor and they offer
        ///     you a reward, some item, or merely acknowledge via dialog that you did something cool.
        /// </summary>
        [JsonPropertyName("interactions")]
        public ReadOnlyCollection<DestinyVendorInteractionDefinition> Interactions { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyVendorInteractionDefinition>();

        /// <summary>
        ///     If the vendor shows you items from your own inventory - such as the Vault vendor does - this data describes the UI
        ///     around showing those inventory buckets and which ones get shown.
        /// </summary>
        [JsonPropertyName("inventoryFlyouts")]
        public ReadOnlyCollection<DestinyVendorInventoryFlyoutDefinition> InventoryFlyouts { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyVendorInventoryFlyoutDefinition>();

        /// <summary>
        ///     If the vendor sells items (or merely has a list of items to show like the "Sack" vendors do), this is the list of
        ///     those items that the vendor can sell. From this list, only a subset will be available from the vendor at any given
        ///     time, selected randomly and reset on the vendor's refresh interval.
        ///     <para />
        ///     Note that a vendor can sell the same item multiple ways: for instance, nothing stops a vendor from selling you some
        ///     specific weapon but using two different currencies, or the same weapon at multiple "item levels".
        /// </summary>
        [JsonPropertyName("itemList")]
        public ReadOnlyCollection<DestinyVendorItemDefinition> ItemList { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyVendorItemDefinition>();

        /// <summary>
        ///     BNet doesn't use this data yet, but it appears to be an optional list of flavor text about services that the Vendor
        ///     can provide.
        /// </summary>
        [JsonPropertyName("services")]
        public ReadOnlyCollection<DestinyVendorServiceDefinition> Services { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyVendorServiceDefinition>();

        /// <summary>
        ///     If the Vendor is actually a vehicle for the transferring of items (like the Vault and Postmaster vendors), this
        ///     defines the list of source->destination buckets for transferring.
        /// </summary>
        [JsonPropertyName("acceptedItems")]
        public ReadOnlyCollection<DestinyVendorAcceptedItemDefinition> AcceptedItems { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyVendorAcceptedItemDefinition>();

        /// <summary>
        ///     As many of you know, Vendor data has historically been pretty brutal on the BNet servers. In an effort to reduce
        ///     this workload, only Vendors with this flag set will be returned on Vendor requests. This allows us to filter out
        ///     Vendors that don't dynamic data that's particularly useful: things like "Preview/Sack" vendors, for example, that
        ///     you can usually suss out the details for using just the definitions themselves.
        /// </summary>
        [JsonPropertyName("returnWithVendorRequest")]
        public bool ReturnWithVendorRequest { get; init; }

        /// <summary>
        ///     A vendor can be at different places in the world depending on the game/character/account state. This is the list of
        ///     possible locations for the vendor, along with conditions we use to determine which one is currently active.
        /// </summary>
        [JsonPropertyName("locations")]
        public ReadOnlyCollection<DestinyVendorLocationDefinition> Locations { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyVendorLocationDefinition>();

        /// <summary>
        ///     A vendor can be a part of 0 or 1 "groups" at a time: a group being a collection of Vendors related by either
        ///     location or function/purpose. It's used for our our Companion Vendor UI. Only one of these can be active for a
        ///     Vendor at a time.
        /// </summary>
        [JsonPropertyName("groups")]
        public ReadOnlyCollection<DestinyVendorGroupReference> Groups { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyVendorGroupReference>();

        /// <summary>
        ///     Some items don't make sense to return in the API, for example because they represent an action to be performed
        ///     rather than an item being sold. I'd rather we not do this, but at least in the short term this is a workable
        ///     workaround.
        /// </summary>
        [JsonPropertyName("ignoreSaleItemHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>>
            IgnoreSaleItems { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>>();

        [JsonPropertyName("unlockValueHash")] public uint UnlockValueHash { get; init; }

        public bool DeepEquals(DestinyVendorDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   VendorProgressionType == other.VendorProgressionType &&
                   BuyString == other.BuyString &&
                   SellString == other.SellString &&
                   DisplayItem.DeepEquals(other.DisplayItem) &&
                   InhibitBuying == other.InhibitBuying &&
                   InhibitSelling == other.InhibitSelling &&
                   Faction.DeepEquals(other.Faction) &&
                   ResetIntervalMinutes == other.ResetIntervalMinutes &&
                   ResetOffsetMinutes == other.ResetOffsetMinutes &&
                   FailureStrings.DeepEqualsReadOnlySimpleCollection(other.FailureStrings) &&
                   UnlockRanges.DeepEqualsReadOnlyCollections(other.UnlockRanges) &&
                   VendorIdentifier == other.VendorIdentifier &&
                   VendorPortrait == other.VendorPortrait &&
                   VendorBanner == other.VendorBanner &&
                   Enabled == other.Enabled &&
                   Visible == other.Visible &&
                   VendorSubcategoryIdentifier == other.VendorSubcategoryIdentifier &&
                   ConsolidateCategories == other.ConsolidateCategories &&
                   Actions.DeepEqualsReadOnlyCollections(other.Actions) &&
                   Categories.DeepEqualsReadOnlyCollections(other.Categories) &&
                   OriginalCategories.DeepEqualsReadOnlyCollections(other.OriginalCategories) &&
                   DisplayCategories.DeepEqualsReadOnlyCollections(other.DisplayCategories) &&
                   Interactions.DeepEqualsReadOnlyCollections(other.Interactions) &&
                   InventoryFlyouts.DeepEqualsReadOnlyCollections(other.InventoryFlyouts) &&
                   ItemList.DeepEqualsReadOnlyCollections(other.ItemList) &&
                   Services.DeepEqualsReadOnlyCollections(other.Services) &&
                   AcceptedItems.DeepEqualsReadOnlyCollections(other.AcceptedItems) &&
                   ReturnWithVendorRequest == other.ReturnWithVendorRequest &&
                   Locations.DeepEqualsReadOnlyCollections(other.Locations) &&
                   Groups.DeepEqualsReadOnlyCollections(other.Groups) &&
                   IgnoreSaleItems.DeepEqualsReadOnlyCollections(other.IgnoreSaleItems) &&
                   UnlockValueHash == other.UnlockValueHash &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyVendorDefinition;
        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }

        public void MapValues()
        {
            DisplayItem.TryMapValue();
            Faction.TryMapValue();
            foreach (var category in Categories) category.Overlay?.CurrencyItem.TryMapValue();

            foreach (var category in OriginalCategories) category.Overlay?.CurrencyItem.TryMapValue();

            foreach (var category in DisplayCategories) category.Progression.TryMapValue();

            foreach (var interaction in Interactions) interaction.QuestlineItem.TryMapValue();

            foreach (var flyout in InventoryFlyouts)
            {
                flyout.EquipmentSlot.TryMapValue();
                foreach (var bucket in flyout.Buckets) bucket.InventoryBucket.TryMapValue();
            }

            foreach (var item in ItemList)
            {
                item.Item.TryMapValue();
                foreach (var currency in item.Currencies) currency.Item.TryMapValue();

                item.InventoryBucket.TryMapValue();
                foreach (var socketOverride in item.SocketOverrides)
                {
                    socketOverride.SingleItem.TryMapValue();
                    socketOverride.SocketType.TryMapValue();
                }
            }

            foreach (var item in AcceptedItems)
            {
                item.AcceptedInventoryBucket.TryMapValue();
                item.DestinationInventoryBucket.TryMapValue();
            }

            foreach (var location in Locations) location.Destination.TryMapValue();

            foreach (var group in Groups) @group.Group.TryMapValue();


            foreach (var item in IgnoreSaleItems) item.TryMapValue();
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}