using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

public sealed class DestinyItemTierTypeInfusionBlock
{

    [JsonPropertyName("baseQualityTransferRatio")]
    public float BaseQualityTransferRatio { get; init; }

    [JsonPropertyName("minimumQualityIncrement")]
    public int MinimumQualityIncrement { get; init; }
}
