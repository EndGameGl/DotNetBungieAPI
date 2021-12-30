using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public sealed class DestinyRecordIntervalRewards
{

    [JsonPropertyName("intervalRewardItems")]
    public List<Destiny.DestinyItemQuantity> IntervalRewardItems { get; init; }
}
