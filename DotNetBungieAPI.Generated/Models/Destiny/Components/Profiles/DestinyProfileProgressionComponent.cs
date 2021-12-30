using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Profiles;

public sealed class DestinyProfileProgressionComponent
{

    [JsonPropertyName("checklists")]
    public Dictionary<uint, Dictionary<uint, bool>> Checklists { get; init; }

    [JsonPropertyName("seasonalArtifact")]
    public Destiny.Artifacts.DestinyArtifactProfileScoped SeasonalArtifact { get; init; }
}
