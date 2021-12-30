using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyTalentNodeExclusiveSetDefinition
{

    [JsonPropertyName("nodeIndexes")]
    public List<int> NodeIndexes { get; init; }
}
