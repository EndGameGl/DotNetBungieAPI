using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemInvestmentStatDefinition
{

    [JsonPropertyName("statTypeHash")]
    public uint StatTypeHash { get; init; }

    [JsonPropertyName("value")]
    public int Value { get; init; }

    [JsonPropertyName("isConditionallyActive")]
    public bool IsConditionallyActive { get; init; }
}
