namespace DotNetBungieAPI.Models.Destiny.Definitions.Records;

public sealed class DestinyRecordIntervalRewards
{
    [JsonPropertyName("intervalRewardItems")]
    public Destiny.DestinyItemQuantity[]? IntervalRewardItems { get; init; }
}
