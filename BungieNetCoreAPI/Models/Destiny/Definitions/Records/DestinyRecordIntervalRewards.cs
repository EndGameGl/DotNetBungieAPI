using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Records
{
    public sealed record DestinyRecordIntervalRewards : IDeepEquatable<DestinyRecordIntervalRewards>
    {
        [JsonPropertyName("intervalRewardItems")]
        public ReadOnlyCollection<DestinyItemQuantity> IntervalRewardItems { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyItemQuantity>();

        public bool DeepEquals(DestinyRecordIntervalRewards other)
        {
            return other != null &&
                   IntervalRewardItems.DeepEqualsReadOnlyCollections(other.IntervalRewardItems);
        }
    }
}
