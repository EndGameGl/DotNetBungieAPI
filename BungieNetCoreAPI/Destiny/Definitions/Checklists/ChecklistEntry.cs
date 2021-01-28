using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.Destinations;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.Locations;
using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Checklists
{
    /// <summary>
    /// The properties of an individual checklist item. Note that almost everything is optional: it is *highly* variable what kind of data we'll actually be able to return: at times we may have no other relationships to entities at all.
    /// <para/>
    /// Whatever UI you build, do it with the knowledge that any given entry might not actually be able to be associated with some other Destiny entity.
    /// </summary>
    public class ChecklistEntry : IDeepEquatable<ChecklistEntry>
    {
        /// <summary>
        /// Note that a Bubble's hash doesn't uniquely identify a "top level" entity in Destiny. Only the combination of location and bubble can uniquely identify a place in the world of Destiny: so if bubbleHash is populated, locationHash must too be populated for it to have any meaning.
        /// </summary>
        public uint? BubbleHash { get; }
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; }
        /// <summary>
        /// Even if no other associations exist, we will give you *something* for display properties. In cases where we have no associated entities, it may be as simple as a numerical identifier.
        /// </summary>
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// The identifier for this Checklist entry. Guaranteed unique only within this Checklist Definition, and not globally/for all checklists.
        /// </summary>
        public uint Hash { get; }
        public Scope Scope { get; }
        public DefinitionHashPointer<DestinyLocationDefinition> Location { get; }
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }
        public int? VendorInteractionIndex { get; }

        [JsonConstructor]
        internal ChecklistEntry(uint? bubbleHash, uint? destinationHash, DestinyDefinitionDisplayProperties displayProperties, uint hash, Scope scope,
            uint? locationHash, uint? activityHash, uint? itemHash, uint? vendorHash, int? vendorInteractionIndex)
        {
            BubbleHash = bubbleHash;
            Destination = new DefinitionHashPointer<DestinyDestinationDefinition>(destinationHash, DefinitionsEnum.DestinyDestinationDefinition);
            DisplayProperties = displayProperties;
            Hash = hash;
            Scope = scope;
            Location = new DefinitionHashPointer<DestinyLocationDefinition>(locationHash, DefinitionsEnum.DestinyLocationDefinition);
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, DefinitionsEnum.DestinyVendorDefinition);
            VendorInteractionIndex = vendorInteractionIndex;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}";
        }
        public bool DeepEquals(ChecklistEntry other)
        {
            return other != null &&
                   BubbleHash == other.BubbleHash &&
                   Destination.DeepEquals(other.Destination) &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Hash == other.Hash &&
                   Scope == other.Scope &&
                   Location.DeepEquals(other.Location) &&
                   Activity.DeepEquals(other.Activity) &&
                   Item.DeepEquals(other.Item) &&
                   Vendor.DeepEquals(other.Vendor) &&
                   VendorInteractionIndex == other.VendorInteractionIndex;
        }
    }
}
