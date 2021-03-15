using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.Factions;
using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    [DestinyDefinition(DefinitionsEnum.DestinyVendorDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyVendorDefinition : IDestinyDefinition, IDeepEquatable<DestinyVendorDefinition>
    {
        /// <summary>
        /// Display properties of this vendor
        /// </summary>
        public VendorDisplayProperties DisplayProperties { get; }
        public VendorProgressionType VendorProgressionType { get; }
        public string BuyString { get; }
        public string SellString { get; }
        /// <summary>
        /// Item that is featured on this vendor, or a related currency
        /// </summary>
        public DefinitionHashPointer<DestinyInventoryItemDefinition> DisplayItem { get; }
        /// <summary>
        /// Whether you can buy items from this vendor or not
        /// </summary>
        public bool InhibitBuying { get; }
        /// <summary>
        /// Whether you can buy sell items to this vendor or not
        /// </summary>
        public bool InhibitSelling { get; }
        /// <summary>
        /// If this vendor has a faction, this is it
        /// </summary>
        public DefinitionHashPointer<DestinyFactionDefinition> Faction { get; }
        /// <summary>
        /// How frequently this vendor refreshes
        /// </summary>
        public int ResetIntervalMinutes { get; }
        /// <summary>
        /// Vendor reset offset in minutes
        /// </summary>
        public int ResetOffsetMinutes { get; }
        /// <summary>
        /// Possible reasons for getting items failure
        /// </summary>
        public ReadOnlyCollection<string> FailureStrings { get; }
        /// <summary>
        /// Information about when this vendor is available
        /// </summary>
        public ReadOnlyCollection<VendorUnlockRange> UnlockRanges { get; }
        /// <summary>
        /// Internal vendor identifier
        /// </summary>
        public string VendorIdentifier { get; }
        public string VendorPortrait { get; }
        public string VendorBanner { get; }
        /// <summary>
        /// Whether this vendor is currently enabled
        /// </summary>
        public bool Enabled { get; }
        /// <summary>
        /// Whether this vendor is visible in UI
        /// </summary>
        public bool Visible { get; }
        public string VendorSubcategoryIdentifier { get; }
        /// <summary>
        /// Whether you should consolidate categories with minor differences
        /// </summary>
        public bool ConsolidateCategories { get; }
        /// <summary>
        /// Actions that can be performed with this vendor
        /// </summary>
        public ReadOnlyCollection<VendorAction> Actions { get; }
        /// <summary>
        /// Info about how vendor groups items for display
        /// </summary>
        public ReadOnlyCollection<VendorCategory> Categories { get; }
        /// <summary>
        /// Pre-aggregated category data, before it was turned into <see cref="DestinyVendorDefinition.Categories"/>
        /// </summary>
        public ReadOnlyCollection<VendorCategory> OriginalCategories { get; }
        /// <summary>
        ///  Info about which groups are displayed by vendor
        /// </summary>
        public ReadOnlyCollection<VendorDisplayCategory> DisplayCategories { get; }
        /// <summary>
        /// Information about any interactions with this vendor, such as dialogs with NPC
        /// </summary>
        public ReadOnlyCollection<VendorInteraction> Interactions { get; }
        /// <summary>
        /// Information for displaying your own items to you from this vendor
        /// </summary>
        public ReadOnlyCollection<VendorInventoryFlyout> InventoryFlyouts { get; }
        /// <summary>
        /// Items that this vendors can sell to the player
        /// </summary>
        public ReadOnlyCollection<VendorItem> ItemList { get; }
        /// <summary>
        /// Additional info about what services this vendor does
        /// </summary>
        public ReadOnlyCollection<VendorService> Services { get; }
        /// <summary>
        /// If vendor can transer items, this field points out transfer destinations
        /// </summary>
        public ReadOnlyCollection<VendorAcceptedItem> AcceptedItems { get; }
        /// <summary>
        /// Whether this vendor is returned on vendor request
        /// </summary>
        public bool ReturnWithVendorRequest { get; }
        /// <summary>
        /// Possible locations for this vendor to be
        /// </summary>
        public ReadOnlyCollection<VendorLocation> Locations { get; }
        /// <summary>
        /// Group that this vendor belongs to
        /// </summary>
        public ReadOnlyCollection<VendorGroup> Groups { get; }
        /// <summary>
        /// Items that should be ignored when selling something
        /// </summary>
        public ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>> IgnoreSaleItems { get; }
        /// <summary>
        /// 
        /// </summary>
        public uint UnlockValueHash { get; }      
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyVendorDefinition(bool consolidateCategories, uint displayItemHash, uint factionHash, string[] failureStrings, bool inhibitBuying, bool inhibitSelling,
            int resetIntervalMinutes, int resetOffsetMinutes, bool returnWithVendorRequest, uint unlockValueHash, bool visible, VendorDisplayProperties displayProperties,
            VendorCategory[] categories, VendorDisplayCategory[] displayCategories, VendorCategory[] originalCategories, VendorItem[] itemList,
            VendorAcceptedItem[] acceptedItems, VendorAction[] actions, uint[] ignoreSaleItemHashes, VendorInteraction[] interactions, string vendorSubcategoryIdentifier,
            VendorInventoryFlyout[] inventoryFlyouts, VendorService[] services, VendorUnlockRange[] unlockRanges, string vendorIdentifier, string vendorBanner,
            VendorLocation[] locations, VendorGroup[] groups, VendorProgressionType vendorProgressionType, string buyString, string sellString, string vendorPortrait,
            bool enabled, bool blacklisted, uint hash, int index, bool redacted)
        {
            ConsolidateCategories = consolidateCategories;
            DisplayItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(displayItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Faction = new DefinitionHashPointer<DestinyFactionDefinition>(factionHash, DefinitionsEnum.DestinyFactionDefinition);
            FailureStrings = failureStrings.AsReadOnlyOrEmpty();
            InhibitBuying = inhibitBuying;
            InhibitSelling = inhibitSelling;
            ResetIntervalMinutes = resetIntervalMinutes;
            ResetOffsetMinutes = resetOffsetMinutes;
            ReturnWithVendorRequest = returnWithVendorRequest;
            UnlockValueHash = unlockValueHash;
            DisplayProperties = displayProperties;
            Visible = visible;
            Categories = categories.AsReadOnlyOrEmpty();
            DisplayCategories = displayCategories.AsReadOnlyOrEmpty();
            OriginalCategories = originalCategories.AsReadOnlyOrEmpty();
            ItemList = itemList.AsReadOnlyOrEmpty();
            AcceptedItems = acceptedItems.AsReadOnlyOrEmpty();
            Actions = actions.AsReadOnlyOrEmpty();
            IgnoreSaleItems = ignoreSaleItemHashes.DefinitionsAsReadOnlyOrEmpty<DestinyInventoryItemDefinition>(DefinitionsEnum.DestinyInventoryItemDefinition);
            Interactions = interactions.AsReadOnlyOrEmpty();
            InventoryFlyouts = inventoryFlyouts.AsReadOnlyOrEmpty();
            Services = services.AsReadOnlyOrEmpty();
            UnlockRanges = unlockRanges.AsReadOnlyOrEmpty();
            VendorIdentifier = vendorIdentifier;
            Locations = locations.AsReadOnlyOrEmpty();
            Groups = groups.AsReadOnlyOrEmpty();
            Enabled = enabled;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
            VendorProgressionType = vendorProgressionType;
            BuyString = buyString;
            SellString = sellString;
            VendorPortrait = vendorPortrait;
            VendorBanner = vendorBanner;
            VendorSubcategoryIdentifier = vendorSubcategoryIdentifier;
        }

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
