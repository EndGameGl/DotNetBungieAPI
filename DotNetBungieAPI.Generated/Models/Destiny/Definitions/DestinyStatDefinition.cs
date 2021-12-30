using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyStatDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("aggregationType")]
    public Destiny.DestinyStatAggregationType AggregationType { get; init; }

    [JsonPropertyName("hasComputedBlock")]
    public bool HasComputedBlock { get; init; }

    [JsonPropertyName("statCategory")]
    public Destiny.DestinyStatCategory StatCategory { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
