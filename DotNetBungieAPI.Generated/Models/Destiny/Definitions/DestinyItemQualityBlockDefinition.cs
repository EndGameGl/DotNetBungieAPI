using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemQualityBlockDefinition
{

    [JsonPropertyName("itemLevels")]
    public List<int> ItemLevels { get; init; }

    [JsonPropertyName("qualityLevel")]
    public int QualityLevel { get; init; }

    [JsonPropertyName("infusionCategoryName")]
    public string InfusionCategoryName { get; init; }

    [JsonPropertyName("infusionCategoryHash")]
    public uint InfusionCategoryHash { get; init; }

    [JsonPropertyName("infusionCategoryHashes")]
    public List<uint> InfusionCategoryHashes { get; init; }

    [JsonPropertyName("progressionLevelRequirementHash")]
    public uint ProgressionLevelRequirementHash { get; init; }

    [JsonPropertyName("currentVersion")]
    public uint CurrentVersion { get; init; }

    [JsonPropertyName("versions")]
    public List<Destiny.Definitions.DestinyItemVersionDefinition> Versions { get; init; }

    [JsonPropertyName("displayVersionWatermarkIcons")]
    public List<string> DisplayVersionWatermarkIcons { get; init; }
}
