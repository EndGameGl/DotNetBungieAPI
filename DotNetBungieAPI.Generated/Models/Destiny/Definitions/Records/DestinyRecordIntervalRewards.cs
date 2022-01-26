namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public class DestinyRecordIntervalRewards : IDeepEquatable<DestinyRecordIntervalRewards>
{
    [JsonPropertyName("intervalRewardItems")]
    public List<Destiny.DestinyItemQuantity> IntervalRewardItems { get; set; }

    public bool DeepEquals(DestinyRecordIntervalRewards? other)
    {
        return other is not null &&
               IntervalRewardItems.DeepEqualsList(other.IntervalRewardItems);
    }
}