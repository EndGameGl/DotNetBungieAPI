using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Factions;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Repositories;
using BungieNetCoreAPI.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using Unity;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    [DestinyDefinition(DefinitionsEnum.DestinyVendorDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyVendorDefinition : IDestinyDefinition
    {
        /// <summary>
        /// If vendor can transer items, this field points out transfer destinations
        /// </summary>
        public List<VendorAcceptedItem> AcceptedItems { get; }
        /// <summary>
        /// Actions that can be performed with this vendor
        /// </summary>
        public List<VendorAction> Actions { get; }
        /// <summary>
        /// Info about how vendor groups items for display
        /// </summary>
        public List<VendorCategory> Categories { get; }
        /// <summary>
        /// Whether you should consolidate categories with minor differences
        /// </summary>
        public bool ConsolidateCategories { get; }
        /// <summary>
        ///  Info about which groups are displayed by vendor
        /// </summary>
        public List<VendorDisplayCategory> DisplayCategories { get; }
        /// <summary>
        /// Item that is featured on this vendor, or a related currency
        /// </summary>
        public DefinitionHashPointer<DestinyInventoryItemDefinition> DisplayItem { get; }
        /// <summary>
        /// Display properties of this vendor
        /// </summary>
        public VendorDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// Whether this vendor is currently enabled
        /// </summary>
        public bool Enabled { get; }
        /// <summary>
        /// If this vendor has a faction, this is it
        /// </summary>
        public DefinitionHashPointer<DestinyFactionDefinition> Faction { get; }
        /// <summary>
        /// Possible reasons for getting items failure
        /// </summary>
        public List<string> FailureStrings { get; }
        /// <summary>
        /// Group that this vendor belongs to
        /// </summary>
        public List<VendorGroup> Groups { get; }
        /// <summary>
        /// Items that should be ignored when selling something
        /// </summary>
        public List<DefinitionHashPointer<DestinyInventoryItemDefinition>> IgnoreSaleItems { get; }
        /// <summary>
        /// Whether you can buy items from this vendor or not
        /// </summary>
        public bool InhibitBuying { get; }
        /// <summary>
        /// Whether you can buy sell items to this vendor or not
        /// </summary>
        public bool InhibitSelling { get; }
        /// <summary>
        /// Information about any interactions with this vendor, such as dialogs with NPC
        /// </summary>
        public List<VendorInteraction> Interactions { get; }
        /// <summary>
        /// Information for displaying your own items to you from this vendor
        /// </summary>
        public List<VendorInventoryFlyout> InventoryFlyouts { get; }
        /// <summary>
        /// Items that this vendors can sell to the player
        /// </summary>
        public List<VendorItem> ItemList { get; }
        /// <summary>
        /// Possible locations for this vendor to be
        /// </summary>
        public List<VendorLocation> Locations { get; }
        /// <summary>
        /// Pre-aggregated category data, before it was turned into <see cref="DestinyVendorDefinition.Categories"/>
        /// </summary>
        public List<VendorCategory> OriginalCategories { get; }
        /// <summary>
        /// How frequently this vendor refreshes
        /// </summary>
        public int ResetIntervalMinutes { get; }
        /// <summary>
        /// Vendor reset offset in minutes
        /// </summary>
        public int ResetOffsetMinutes { get; }
        /// <summary>
        /// Whether this vendor is returned on vendor request
        /// </summary>
        public bool ReturnWithVendorRequest { get; }
        /// <summary>
        /// Additional info about what services this vendor does
        /// </summary>
        public List<VendorService> Services { get; }
        /// <summary>
        /// Information about when this vendor is available
        /// </summary>
        public List<VendorUnlockRange> UnlockRanges { get; }
        /// <summary>
        /// 
        /// </summary>
        public uint UnlockValueHash { get; }
        /// <summary>
        /// Internal vendor identifier
        /// </summary>
        public string VendorIdentifier { get; }
        /// <summary>
        /// Whether this vendor is visible in UI
        /// </summary>
        public bool Visible { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyVendorDefinition(bool consolidateCategories, uint displayItemHash, uint factionHash, List<string> failureStrings,bool inhibitBuying, bool inhibitSelling, 
            int resetIntervalMinutes, int resetOffsetMinutes, bool returnWithVendorRequest, uint unlockValueHash,bool visible, VendorDisplayProperties displayProperties,
            List<VendorCategory> categories, List<VendorDisplayCategory> displayCategories, List<VendorCategory> originalCategories, List<VendorItem> itemList,
            List<VendorAcceptedItem> acceptedItems, List<VendorAction> actions, List<uint> ignoreSaleItemHashes, List<VendorInteraction> interactions, 
            List<VendorInventoryFlyout> inventoryFlyouts, List<VendorService> services, List<VendorUnlockRange> unlockRanges, string vendorIdentifier, 
            List<VendorLocation> locations, List<VendorGroup> groups, bool enabled, bool blacklisted, uint hash, int index, bool redacted)
        {
            ConsolidateCategories = consolidateCategories;
            DisplayItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(displayItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Faction = new DefinitionHashPointer<DestinyFactionDefinition>(factionHash, DefinitionsEnum.DestinyFactionDefinition);
            FailureStrings = failureStrings;
            InhibitBuying = inhibitBuying;
            InhibitSelling = inhibitSelling;
            ResetIntervalMinutes = resetIntervalMinutes;
            ResetOffsetMinutes = resetOffsetMinutes;
            ReturnWithVendorRequest = returnWithVendorRequest;
            UnlockValueHash = unlockValueHash;
            DisplayProperties = displayProperties;
            Visible = visible;
            Categories = categories;
            DisplayCategories = displayCategories;
            OriginalCategories = originalCategories;
            ItemList = itemList;
            AcceptedItems = acceptedItems;
            Actions = actions;
            IgnoreSaleItems = new List<DefinitionHashPointer<DestinyInventoryItemDefinition>>();
            if (ignoreSaleItemHashes != null)
            {
                foreach (var ignoreSaleItemHash in ignoreSaleItemHashes)
                {
                    IgnoreSaleItems.Add(new DefinitionHashPointer<DestinyInventoryItemDefinition>(ignoreSaleItemHash, DefinitionsEnum.DestinyInventoryItemDefinition));
                }
            }
            Interactions = interactions;
            InventoryFlyouts = inventoryFlyouts;
            Services = services;
            UnlockRanges = unlockRanges;
            VendorIdentifier = vendorIdentifier;
            Locations = locations;
            Groups = groups;
            Enabled = enabled;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
