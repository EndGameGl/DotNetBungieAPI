using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Destinations;
using NetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace NetBungieAPI.Models.Destiny.Definitions.Factions
{
    /// <summary>
    ///     These definitions represent faction vendors at different points in the game.
    ///     <para />
    ///     A single faction may contain multiple vendors, or the same vendor available at two different locations.
    /// </summary>
    public sealed record DestinyFactionVendorDefinition : IDeepEquatable<DestinyFactionVendorDefinition>
    {
        /// <summary>
        ///     The relative path to the background image representing this Vendor at this location, for use in a banner.
        /// </summary>
        [JsonPropertyName("backgroundImagePath")]
        public DestinyResource BackgroundImagePath { get; init; }

        /// <summary>
        ///     DestinyDestinationDefinition for a Destination at which this vendor may be located. Each destination where a Vendor
        ///     may exist will only ever have a single entry.
        /// </summary>
        [JsonPropertyName("destinationHash")]
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; init; } =
            DefinitionHashPointer<DestinyDestinationDefinition>.Empty;

        /// <summary>
        ///     The faction vendor.
        /// </summary>
        [JsonPropertyName("vendorHash")]
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } =
            DefinitionHashPointer<DestinyVendorDefinition>.Empty;

        public bool DeepEquals(DestinyFactionVendorDefinition other)
        {
            return other != null &&
                   BackgroundImagePath == other.BackgroundImagePath &&
                   Destination.DeepEquals(other.Destination) &&
                   Vendor.DeepEquals(other.Vendor);
        }
    }
}