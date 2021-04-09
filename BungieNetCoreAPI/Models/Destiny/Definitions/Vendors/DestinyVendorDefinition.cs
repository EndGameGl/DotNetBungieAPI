using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Dates;
using NetBungieAPI.Models.Destiny.Definitions.Factions;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    [DestinyDefinition(DefinitionsEnum.DestinyVendorDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinyVendorDefinition : IDestinyDefinition, IDeepEquatable<DestinyVendorDefinition>
    {
        /// <summary>
        /// Display properties of this vendor
        /// </summary>
        [JsonPropertyName("displayProperties")]
        public DestinyVendorDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("vendorProgressionType")]
        public DestinyVendorProgressionType VendorProgressionType { get; init; }
        [JsonPropertyName("buyString")]
        public string BuyString { get; init; }
        [JsonPropertyName("sellString")]
        public string SellString { get; init; }
        /// <summary>
        /// Item that is featured on this vendor, or a related currency
        /// </summary>
        [JsonPropertyName("displayItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> DisplayItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        /// <summary>
        /// Whether you can buy items from this vendor or not
        /// </summary>
        [JsonPropertyName("inhibitBuying")]
        public bool InhibitBuying { get; init; }
        /// <summary>
        /// Whether you can buy sell items to this vendor or not
        /// </summary>
        [JsonPropertyName("inhibitSelling")]
        public bool InhibitSelling { get; init; }
        /// <summary>
        /// If this vendor has a faction, this is it
        /// </summary>
        [JsonPropertyName("factionHash")]
        public DefinitionHashPointer<DestinyFactionDefinition> Faction { get; init; } = DefinitionHashPointer<DestinyFactionDefinition>.Empty;
        /// <summary>
        /// How frequently this vendor refreshes
        /// </summary>
        [JsonPropertyName("resetIntervalMinutes")]
        public int ResetIntervalMinutes { get; init; }
        /// <summary>
        /// Vendor reset offset in minutes
        /// </summary>
        [JsonPropertyName("resetOffsetMinutes")]
        public int ResetOffsetMinutes { get; init; }
        /// <summary>
        /// Possible reasons for getting items failure
        /// </summary>
        [JsonPropertyName("failureStrings")]
        public ReadOnlyCollection<string> FailureStrings { get; init; } = Defaults.EmptyReadOnlyCollection<string>();
        /// <summary>
        /// Information about when this vendor is available
        /// </summary>
        [JsonPropertyName("unlockRanges")]
        public ReadOnlyCollection<DateRange> UnlockRanges { get; init; } = Defaults.EmptyReadOnlyCollection<DateRange>();
        /// <summary>
        /// Internal vendor identifier
        /// </summary>
        [JsonPropertyName("vendorIdentifier")]
        public string VendorIdentifier { get; init; }
        [JsonPropertyName("vendorPortrait")]
        public string VendorPortrait { get; init; }
        [JsonPropertyName("vendorBanner")]
        public string VendorBanner { get; init; }
        /// <summary>
        /// Whether this vendor is currently enabled
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; init; }
        /// <summary>
        /// Whether this vendor is visible in UI
        /// </summary>
        [JsonPropertyName("visible")]
        public bool Visible { get; init; }
        [JsonPropertyName("vendorSubcategoryIdentifier")]
        public string VendorSubcategoryIdentifier { get; init; }
        /// <summary>
        /// Whether you should consolidate categories with minor differences
        /// </summary>
        [JsonPropertyName("consolidateCategories")]
        public bool ConsolidateCategories { get; init; }
        /// <summary>
        /// Actions that can be performed with this vendor
        /// </summary>
        [JsonPropertyName("actions")]
        public ReadOnlyCollection<DestinyVendorActionDefinition> Actions { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorActionDefinition>();
        /// <summary>
        /// Info about how vendor groups items for display
        /// </summary>
        [JsonPropertyName("categories")]
        public ReadOnlyCollection<DestinyVendorCategoryEntryDefinition> Categories { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorCategoryEntryDefinition>();
        /// <summary>
        /// Pre-aggregated category data, before it was turned into <see cref="DestinyVendorDefinition.Categories"/>
        /// </summary>
        [JsonPropertyName("originalCategories")]
        public ReadOnlyCollection<DestinyVendorCategoryEntryDefinition> OriginalCategories { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorCategoryEntryDefinition>();
        /// <summary>
        ///  Info about which groups are displayed by vendor
        /// </summary>
        [JsonPropertyName("displayCategories")]
        public ReadOnlyCollection<DestinyDisplayCategoryDefinition> DisplayCategories { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyDisplayCategoryDefinition>();
        /// <summary>
        /// Information about any interactions with this vendor, such as dialogs with NPC
        /// </summary>
        [JsonPropertyName("interactions")]
        public ReadOnlyCollection<DestinyVendorInteractionDefinition> Interactions { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorInteractionDefinition>();
        /// <summary>
        /// Information for displaying your own items to you from this vendor
        /// </summary>
        [JsonPropertyName("inventoryFlyouts")]
        public ReadOnlyCollection<DestinyVendorInventoryFlyoutDefinition> InventoryFlyouts { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorInventoryFlyoutDefinition>();
        /// <summary>
        /// Items that this vendors can sell to the player
        /// </summary>
        [JsonPropertyName("itemList")]
        public ReadOnlyCollection<DestinyVendorItemDefinition> ItemList { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorItemDefinition>();
        /// <summary>
        /// Additional info about what services this vendor does
        /// </summary>
        [JsonPropertyName("services")]
        public ReadOnlyCollection<DestinyVendorServiceDefinition> Services { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorServiceDefinition>();
        /// <summary>
        /// If vendor can transer items, this field points out transfer destinations
        /// </summary>
        [JsonPropertyName("acceptedItems")]
        public ReadOnlyCollection<DestinyVendorAcceptedItemDefinition> AcceptedItems { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorAcceptedItemDefinition>();
        /// <summary>
        /// Whether this vendor is returned on vendor request
        /// </summary>
        [JsonPropertyName("returnWithVendorRequest")]
        public bool ReturnWithVendorRequest { get; init; }
        /// <summary>
        /// Possible locations for this vendor to be
        /// </summary>
        [JsonPropertyName("locations")]
        public ReadOnlyCollection<DestinyVendorLocationDefinition> Locations { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorLocationDefinition>();
        /// <summary>
        /// Group that this vendor belongs to
        /// </summary>
        [JsonPropertyName("groups")]
        public ReadOnlyCollection<DestinyVendorGroupReference> Groups { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyVendorGroupReference>();
        /// <summary>
        /// Items that should be ignored when selling something
        /// </summary>
        [JsonPropertyName("ignoreSaleItemHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>> IgnoreSaleItems { get; init; }
        [JsonPropertyName("unlockValueHash")]
        public uint UnlockValueHash { get; init; }
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public void MapValues()
        {
            DisplayItem.TryMapValue();
            Faction.TryMapValue();
            foreach (var category in Categories)
            {
                category.Overlay?.CurrencyItem.TryMapValue();
            }
            foreach (var category in OriginalCategories)
            {
                category.Overlay?.CurrencyItem.TryMapValue();
            }
            foreach (var category in DisplayCategories)
            {
                category.Progression.TryMapValue();
            }
            foreach (var interaction in Interactions)
            {
                interaction.QuestlineItem.TryMapValue();
            }
            foreach (var flyout in InventoryFlyouts)
            {
                flyout.EquipmentSlot.TryMapValue();
                foreach (var bucket in flyout.Buckets)
                {
                    bucket.InventoryBucket.TryMapValue();
                }
            }
            foreach (var item in ItemList)
            {
                item.Item.TryMapValue();
                foreach (var currency in item.Currencies)
                {
                    currency.Item.TryMapValue();
                }
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
            foreach (var location in Locations)
            {
                location.Destination.TryMapValue();
            }
            foreach (var group in Groups)
            {
                group.Group.TryMapValue();
            }
            foreach (var item in IgnoreSaleItems)
            {
                item.TryMapValue();
            }
        }

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
    }
}
