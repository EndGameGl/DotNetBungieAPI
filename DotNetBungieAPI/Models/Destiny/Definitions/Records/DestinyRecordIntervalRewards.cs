namespace DotNetBungieAPI.Models.Destiny.Definitions.Records
{
    public sealed record DestinyRecordIntervalRewards : IDeepEquatable<DestinyRecordIntervalRewards>
    {
        [JsonPropertyName("intervalRewardItems")]
        public ReadOnlyCollection<DestinyItemQuantity> IntervalRewardItems { get; init; } =
            ReadOnlyCollections<DestinyItemQuantity>.Empty;

        public bool DeepEquals(DestinyRecordIntervalRewards other)
        {
            return other != null &&
                   IntervalRewardItems.DeepEqualsReadOnlyCollections(other.IntervalRewardItems);
        }
    }
}