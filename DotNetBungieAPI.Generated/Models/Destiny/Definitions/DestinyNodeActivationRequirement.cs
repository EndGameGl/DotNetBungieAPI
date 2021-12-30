using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyNodeActivationRequirement
{

    [JsonPropertyName("gridLevel")]
    public int GridLevel { get; init; }

    [JsonPropertyName("materialRequirementHashes")]
    public List<uint> MaterialRequirementHashes { get; init; }
}
