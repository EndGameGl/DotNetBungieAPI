using NetBungieAPI.Destiny.Definitions.Destinations;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorLocation : IDeepEquatable<VendorLocation>
    {
        public string BackgroundImagePath { get; }
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; }

        [JsonConstructor]
        internal VendorLocation(string backgroundImagePath, uint destinationHash)
        {
            BackgroundImagePath = backgroundImagePath;
            Destination = new DefinitionHashPointer<DestinyDestinationDefinition>(destinationHash, DefinitionsEnum.DestinyDestinationDefinition);
        }

        public bool DeepEquals(VendorLocation other)
        {
            return other != null &&
                   BackgroundImagePath == other.BackgroundImagePath &&
                   Destination.DeepEquals(other.Destination);
        }
    }
}
