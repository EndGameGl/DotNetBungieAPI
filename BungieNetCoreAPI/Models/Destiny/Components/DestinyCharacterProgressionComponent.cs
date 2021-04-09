using NetBungieAPI.Models.Destiny.Definitions.Checklists;
using NetBungieAPI.Models.Destiny.Definitions.Factions;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.Milestones;
using NetBungieAPI.Models.Destiny.Definitions.ProgressionMappings;
using NetBungieAPI.Models.Destiny.Milestones;
using NetBungieAPI.Models.Destiny.Progressions;
using NetBungieAPI.Models.Destiny.Quests;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyCharacterProgressionComponent
    {
        [JsonPropertyName("progressions")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyProgressionMappingDefinition>, DestinyProgression> Progressions { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyProgressionMappingDefinition>, DestinyProgression>();
        [JsonPropertyName("factions")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyFactionDefinition>, DestinyFactionProgression> Factions { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyFactionDefinition>, DestinyFactionProgression>();
        [JsonPropertyName("milestones")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyMilestoneDefinition>, DestinyMilestone> Milestones { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyMilestoneDefinition>, DestinyMilestone>();
        [JsonPropertyName("quests")]
        public ReadOnlyCollection<DestinyQuestStatus> Quests { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyQuestStatus>();
        [JsonPropertyName("uninstancedItemObjectives")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, ReadOnlyCollection<UninstancedItemObjective>> UninstancedItemObjectives { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, ReadOnlyCollection<UninstancedItemObjective>>();
        [JsonPropertyName("checklists")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyChecklistDefinition>, ReadOnlyDictionary<uint, bool>> Checklists { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyChecklistDefinition>, ReadOnlyDictionary<uint, bool>>();
        [JsonPropertyName("seasonalArtifact")]
        public DestinyArtifactCharacterScoped SeasonalArtifact { get; init; }
    }
}
