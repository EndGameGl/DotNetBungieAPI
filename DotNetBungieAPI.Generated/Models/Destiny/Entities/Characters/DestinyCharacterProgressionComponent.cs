using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Characters;

public sealed class DestinyCharacterProgressionComponent
{

    [JsonPropertyName("progressions")]
    public Dictionary<uint, Destiny.DestinyProgression> Progressions { get; init; }

    [JsonPropertyName("factions")]
    public Dictionary<uint, Destiny.Progression.DestinyFactionProgression> Factions { get; init; }

    [JsonPropertyName("milestones")]
    public Dictionary<uint, Destiny.Milestones.DestinyMilestone> Milestones { get; init; }

    [JsonPropertyName("quests")]
    public List<Destiny.Quests.DestinyQuestStatus> Quests { get; init; }

    [JsonPropertyName("uninstancedItemObjectives")]
    public Dictionary<uint, List<Destiny.Quests.DestinyObjectiveProgress>> UninstancedItemObjectives { get; init; }

    [JsonPropertyName("uninstancedItemPerks")]
    public Dictionary<uint, Destiny.Entities.Items.DestinyItemPerksComponent> UninstancedItemPerks { get; init; }

    [JsonPropertyName("checklists")]
    public Dictionary<uint, Dictionary<uint, bool>> Checklists { get; init; }

    [JsonPropertyName("seasonalArtifact")]
    public Destiny.Artifacts.DestinyArtifactCharacterScoped SeasonalArtifact { get; init; }
}
