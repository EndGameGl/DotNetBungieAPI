using BungieNetCoreAPI.Destiny.Definitions.Destinations;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Factions
{
    public class FactionVendorEntry
    {
        public string BackgroundImagePath { get; }
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; }
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; }

        [JsonConstructor]
        private FactionVendorEntry(string backgroundImagePath, uint destinationHash, uint vendorHash)
        {
            BackgroundImagePath = backgroundImagePath;
            Destination = new DefinitionHashPointer<DestinyDestinationDefinition>(destinationHash, "DestinyDestinationDefinition");
            Vendor = new DefinitionHashPointer<DestinyVendorDefinition>(vendorHash, "DestinyVendorDefinition");
        }
    }
}
