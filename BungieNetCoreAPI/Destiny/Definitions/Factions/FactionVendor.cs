using BungieNetCoreAPI.Destiny.Definitions.Destinations;
using BungieNetCoreAPI.Destiny.Definitions.Vendors;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Factions
{
    public class FactionVendor
    {
        public string BackgroundImagePath { get; }
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; }
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }

        [JsonConstructor]
        private FactionVendor(string backgroundImagePath, uint destinationHash, uint vendorHash)
        {
            BackgroundImagePath = backgroundImagePath;
            Destination = new DefinitionHashPointer<DestinyDestinationDefinition>(destinationHash, DefinitionsEnum.DestinyDestinationDefinition);
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, DefinitionsEnum.DestinyVendorDefinition);
        }
    }
}
