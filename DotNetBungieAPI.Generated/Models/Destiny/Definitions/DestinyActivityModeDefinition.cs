using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyActivityModeDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("pgcrImage")]
    public string PgcrImage { get; init; }

    [JsonPropertyName("modeType")]
    public Destiny.HistoricalStats.Definitions.DestinyActivityModeType ModeType { get; init; }

    [JsonPropertyName("activityModeCategory")]
    public Destiny.DestinyActivityModeCategory ActivityModeCategory { get; init; }

    [JsonPropertyName("isTeamBased")]
    public bool IsTeamBased { get; init; }

    [JsonPropertyName("isAggregateMode")]
    public bool IsAggregateMode { get; init; }

    [JsonPropertyName("parentHashes")]
    public List<uint> ParentHashes { get; init; }

    [JsonPropertyName("friendlyName")]
    public string FriendlyName { get; init; }

    [JsonPropertyName("activityModeMappings")]
    public Dictionary<uint, Destiny.HistoricalStats.Definitions.DestinyActivityModeType> ActivityModeMappings { get; init; }

    [JsonPropertyName("display")]
    public bool Display { get; init; }

    [JsonPropertyName("order")]
    public int Order { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
