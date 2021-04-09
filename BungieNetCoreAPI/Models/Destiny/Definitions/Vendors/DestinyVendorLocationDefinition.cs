using NetBungieAPI.Models.Destiny.Definitions.Destinations;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorLocationDefinition : IDeepEquatable<DestinyVendorLocationDefinition>
    {
        [JsonPropertyName("backgroundImagePath")]
        public string BackgroundImagePath { get; init; }
        [JsonPropertyName("destinationHash")]
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; init; } = DefinitionHashPointer<DestinyDestinationDefinition>.Empty;

        public bool DeepEquals(DestinyVendorLocationDefinition other)
        {
            return other != null &&
                   BackgroundImagePath == other.BackgroundImagePath &&
                   Destination.DeepEquals(other.Destination);
        }
    }
}
