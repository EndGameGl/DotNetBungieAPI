namespace DotNetBungieAPI.Models.Destiny.Definitions.ItemTierTypes;

public sealed record DestinyItemTierTypeInfusionBlock
    : IDeepEquatable<DestinyItemTierTypeInfusionBlock>
{
    /// <summary>
    ///     The default portion of quality that will transfer from the infuser to the infusee item. (InfuserQuality -
    ///     InfuseeQuality) * baseQualityTransferRatio = base quality transferred.
    /// </summary>
    [JsonPropertyName("baseQualityTransferRatio")]
    public double BaseQualityTransferRatio { get; init; }

    /// <summary>
    ///     As long as InfuserQuality > InfuseeQuality, the amount of quality bestowed is guaranteed to be at least this value,
    ///     even if the transferRatio would dictate that it should be less. The total amount of quality that ends up in the
    ///     Infusee cannot exceed the Infuser's quality however (for instance, if you infuse a 300 item with a 301 item and the
    ///     minimum quality increment is 10, the infused item will not end up with 310 quality)
    /// </summary>
    [JsonPropertyName("minimumQualityIncrement")]
    public int MinimumQualityIncrement { get; init; }

    public bool DeepEquals(DestinyItemTierTypeInfusionBlock other)
    {
        return other != null
            && BaseQualityTransferRatio == other.BaseQualityTransferRatio
            && MinimumQualityIncrement == other.MinimumQualityIncrement;
    }
}
