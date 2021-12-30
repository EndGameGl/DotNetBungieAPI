using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Sources;

public sealed class DestinyItemSourceDefinition
{

    [JsonPropertyName("level")]
    public int Level { get; init; }

    [JsonPropertyName("minQuality")]
    public int MinQuality { get; init; }

    [JsonPropertyName("maxQuality")]
    public int MaxQuality { get; init; }

    [JsonPropertyName("minLevelRequired")]
    public int MinLevelRequired { get; init; }

    [JsonPropertyName("maxLevelRequired")]
    public int MaxLevelRequired { get; init; }

    [JsonPropertyName("computedStats")]
    public Dictionary<uint, Destiny.Definitions.DestinyInventoryItemStatDefinition> ComputedStats { get; init; }

    [JsonPropertyName("sourceHashes")]
    public List<uint> SourceHashes { get; init; }
}
