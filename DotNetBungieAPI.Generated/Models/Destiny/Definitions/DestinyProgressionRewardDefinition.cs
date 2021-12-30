using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyProgressionRewardDefinition
{

    [JsonPropertyName("progressionMappingHash")]
    public uint ProgressionMappingHash { get; init; }

    [JsonPropertyName("amount")]
    public int Amount { get; init; }

    [JsonPropertyName("applyThrottles")]
    public bool ApplyThrottles { get; init; }
}
