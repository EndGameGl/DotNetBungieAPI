using BungieNetCoreAPI.Destiny.Definitions.Destinations;
using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Factions
{
    /// <summary>
    /// These definitions represent faction vendors at different points in the game.
    /// <para/>
    /// A single faction may contain multiple vendors, or the same vendor available at two different locations.
    /// </summary>
    public class FactionVendor : IDeepEquatable<FactionVendor>
    {
        /// <summary>
        /// The relative path to the background image representing this Vendor at this location, for use in a banner.
        /// </summary>
        public string BackgroundImagePath { get; }
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; }
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }

        [JsonConstructor]
        internal FactionVendor(string backgroundImagePath, uint destinationHash, uint vendorHash)
        {
            BackgroundImagePath = backgroundImagePath;
            Destination = new DefinitionHashPointer<DestinyDestinationDefinition>(destinationHash, DefinitionsEnum.DestinyDestinationDefinition);
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, DefinitionsEnum.DestinyVendorDefinition);
        }

        public bool DeepEquals(FactionVendor other)
        {
            return other != null &&
                   BackgroundImagePath == other.BackgroundImagePath &&
                   Destination.DeepEquals(other.Destination) &&
                   Vendor.DeepEquals(other.Vendor);
        }
    }
}
