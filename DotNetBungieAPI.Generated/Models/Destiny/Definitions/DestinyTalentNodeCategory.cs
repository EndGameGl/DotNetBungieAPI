using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyTalentNodeCategory
{

    [JsonPropertyName("identifier")]
    public string Identifier { get; init; }

    [JsonPropertyName("isLoreDriven")]
    public bool IsLoreDriven { get; init; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("nodeHashes")]
    public List<uint> NodeHashes { get; init; }
}
