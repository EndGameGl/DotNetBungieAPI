using System;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace NetBungieAPI.Models.Destiny.Components
{
    /// <summary>
    /// This component contains essential/summary information about the vendor from the perspective of a character-agnostic view.
    /// </summary>
    public sealed record DestinyPublicVendorComponent
    {
        /// <summary>
        /// The unique identifier for the vendor. Use it to look up their DestinyVendorDefinition.
        /// </summary>
        [JsonPropertyName("vendorHash")]
        public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } =
            DefinitionHashPointer<DestinyVendorDefinition>.Empty;

        /// <summary>
        /// The date when this vendor's inventory will next rotate/refresh.
        /// <para/>
        /// Note that this is distinct from the date ranges that the vendor is visible/available in-game: this field indicates the specific time when the vendor's available items refresh and rotate, regardless of whether the vendor is actually available at that time. Unfortunately, these two values may be (and are, for the case of important vendors like Xur) different.
        /// </summary>
        [JsonPropertyName("nextRefreshDate")]
        public DateTime NextRefreshDate { get; init; }

        /// <summary>
        /// If True, the Vendor is currently accessible.
        /// <para/>
        /// If False, they may not actually be visible in the world at the moment.
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool IsEnabled { get; init; }
    }
}