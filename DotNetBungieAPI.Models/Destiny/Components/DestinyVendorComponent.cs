using DotNetBungieAPI.Models.Destiny.Definitions.Vendors;
using DotNetBungieAPI.Models.Destiny.Progressions;

namespace DotNetBungieAPI.Models.Destiny.Components;

/// <summary>
///     This component contains essential/summary information about the vendor.
/// </summary>
public sealed record DestinyVendorComponent
{
    /// <summary>
    ///     If True, you can purchase from the Vendor.
    /// </summary>
    [JsonPropertyName("canPurchase")]
    public bool CanPurchase { get; init; }

    /// <summary>
    ///     If the Vendor has a related Reputation, this is the Progression data that represents the character's Reputation
    ///     level with this Vendor.
    /// </summary>
    [JsonPropertyName("progression")]
    public DestinyProgression Progression { get; init; }

    /// <summary>
    ///     An index into the vendor definition's "locations" property array, indicating which location they are at currently.
    ///     If -1, then the vendor has no known location (and you may choose not to show them in your UI as a result. I mean,
    ///     it's your bag honey)
    /// </summary>
    [JsonPropertyName("vendorLocationIndex")]
    public int VendorLocationIndex { get; init; }

    /// <summary>
    ///     If this vendor has a seasonal rank, this will be the calculated value of that rank. How nice is that? I mean,
    ///     that's pretty sweeet. It's a whole 32 bit integer.
    /// </summary>
    [JsonPropertyName("seasonalRank")]
    public int? SeasonalRank { get; init; }

    /// <summary>
    ///     The unique identifier for the vendor. Use it to look up their DestinyVendorDefinition.
    /// </summary>
    [JsonPropertyName("vendorHash")]
    public DefinitionHashPointer<DestinyVendorDefinition> Vendor { get; init; } =
        DefinitionHashPointer<DestinyVendorDefinition>.Empty;

    /// <summary>
    ///     The date when this vendor's inventory will next rotate/refresh.
    ///     <para />
    ///     Note that this is distinct from the date ranges that the vendor is visible/available in-game: this field indicates
    ///     the specific time when the vendor's available items refresh and rotate, regardless of whether the vendor is
    ///     actually available at that time. Unfortunately, these two values may be (and are, for the case of important vendors
    ///     like Xur) different.
    /// </summary>
    [JsonPropertyName("nextRefreshDate")]
    public DateTime NextRefreshDate { get; init; }

    /// <summary>
    ///     If True, the Vendor is currently accessible.
    ///     <para />
    ///     If False, they may not actually be visible in the world at the moment.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool IsEnabled { get; init; }
}
