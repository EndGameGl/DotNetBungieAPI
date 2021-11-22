using DotNetBungieAPI.Models.Destiny.Definitions.Destinations;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Vendors
{
    /// <summary>
    ///     These definitions represent vendors' locations and relevant display information at different times in the game.
    /// </summary>
    public sealed record DestinyVendorLocationDefinition : IDeepEquatable<DestinyVendorLocationDefinition>
    {
        /// <summary>
        ///     The relative path to the background image representing this Vendor at this location, for use in a banner.
        /// </summary>
        [JsonPropertyName("backgroundImagePath")]
        public BungieNetResource BackgroundImagePath { get; init; }

        /// <summary>
        ///     DestinyDestinationDefinition for a Destination at which this vendor may be located. Each destination where a Vendor
        ///     may exist will only ever have a single entry.
        /// </summary>
        [JsonPropertyName("destinationHash")]
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; init; } =
            DefinitionHashPointer<DestinyDestinationDefinition>.Empty;

        public bool DeepEquals(DestinyVendorLocationDefinition other)
        {
            return other != null &&
                   BackgroundImagePath == other.BackgroundImagePath &&
                   Destination.DeepEquals(other.Destination);
        }
    }
}