using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Vendors;

public sealed class DestinyVendorComponent
{

    [JsonPropertyName("canPurchase")]
    public bool CanPurchase { get; init; }

    [JsonPropertyName("progression")]
    public Destiny.DestinyProgression Progression { get; init; }

    [JsonPropertyName("vendorLocationIndex")]
    public int VendorLocationIndex { get; init; }

    [JsonPropertyName("seasonalRank")]
    public int? SeasonalRank { get; init; }

    [JsonPropertyName("vendorHash")]
    public uint VendorHash { get; init; }

    [JsonPropertyName("nextRefreshDate")]
    public DateTime NextRefreshDate { get; init; }

    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; }
}
