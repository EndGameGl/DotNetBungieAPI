using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyProgressionDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.DestinyProgressionDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("scope")]
    public Destiny.DestinyProgressionScope Scope { get; init; }

    [JsonPropertyName("repeatLastStep")]
    public bool RepeatLastStep { get; init; }

    [JsonPropertyName("source")]
    public string Source { get; init; }

    [JsonPropertyName("steps")]
    public List<Destiny.Definitions.DestinyProgressionStepDefinition> Steps { get; init; }

    [JsonPropertyName("visible")]
    public bool Visible { get; init; }

    [JsonPropertyName("factionHash")]
    public uint? FactionHash { get; init; }

    [JsonPropertyName("color")]
    public Destiny.Misc.DestinyColor Color { get; init; }

    [JsonPropertyName("rankIcon")]
    public string RankIcon { get; init; }

    [JsonPropertyName("rewardItems")]
    public List<Destiny.Definitions.DestinyProgressionRewardItemQuantity> RewardItems { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
