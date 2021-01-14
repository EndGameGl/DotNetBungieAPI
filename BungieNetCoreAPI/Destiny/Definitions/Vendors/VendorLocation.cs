using BungieNetCoreAPI.Clients;
using BungieNetCoreAPI.Destiny.Definitions.Destinations;
using BungieNetCoreAPI.Repositories;
using BungieNetCoreAPI.Services;
using Newtonsoft.Json;
using Unity;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorLocation
    {
        public string BackgroundImagePath { get; }
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; }

        [JsonConstructor]
        private VendorLocation(string backgroundImagePath, uint destinationHash)
        {
            BackgroundImagePath = backgroundImagePath;
            Destination = new DefinitionHashPointer<DestinyDestinationDefinition>(destinationHash, "DestinyDestinationDefinition");
        }
    }
}
