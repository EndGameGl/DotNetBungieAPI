using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemMetricBlockDefinition
{

    [JsonPropertyName("availableMetricCategoryNodeHashes")]
    public List<uint> AvailableMetricCategoryNodeHashes { get; init; }
}
