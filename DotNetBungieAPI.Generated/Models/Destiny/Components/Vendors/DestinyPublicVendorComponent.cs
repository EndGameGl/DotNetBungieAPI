using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Vendors;

/// <summary>
///     This component contains essential/summary information about the vendor from the perspective of a character-agnostic view.
/// </summary>
public sealed class DestinyPublicVendorComponent
{

    /// <summary>
    ///     The unique identifier for the vendor. Use it to look up their DestinyVendorDefinition.
    /// </summary>
    [JsonPropertyName("vendorHash")]
    public uint VendorHash { get; init; } // DestinyVendorDefinition

    /// <summary>
    ///     The date when this vendor's inventory will next rotate/refresh.
    /// <para />
    ///     Note that this is distinct from the date ranges that the vendor is visible/available in-game: this field indicates the specific time when the vendor's available items refresh and rotate, regardless of whether the vendor is actually available at that time. Unfortunately, these two values may be (and are, for the case of important vendors like Xur) different.
    /// <para />
    ///     Issue https://github.com/Bungie-net/api/issues/353 is tracking a fix to start providing visibility date ranges where possible in addition to this refresh date, so that all important dates for vendors are available for use.
    /// </summary>
    [JsonPropertyName("nextRefreshDate")]
    public DateTime NextRefreshDate { get; init; }

    /// <summary>
    ///     If True, the Vendor is currently accessible. 
    /// <para />
    ///     If False, they may not actually be visible in the world at the moment.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; }
}
