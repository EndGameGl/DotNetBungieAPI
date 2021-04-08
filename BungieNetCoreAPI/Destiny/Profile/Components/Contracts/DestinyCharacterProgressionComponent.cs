using NetBungieAPI.Models.Destiny.Definitions.Checklists;
using NetBungieAPI.Models.Destiny.Definitions.Factions;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Definitions.Milestones;
using NetBungieAPI.Models.Destiny.Definitions.Progressions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCharacterProgressionComponent
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyProgressionDefinition>, DestinyProgression> Progressions { get; init; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyFactionDefinition>, DestinyFactionProgression> Factions { get; init; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyMilestoneDefinition>, DestinyMilestone> Milestones { get; init; }
        public ReadOnlyCollection<DestinyQuestStatus> Quests { get; init; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, ReadOnlyCollection<UninstancedItemObjective>> UninstancedItemObjectives { get; init; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyChecklistDefinition>, ReadOnlyDictionary<uint, bool>> Checklists { get; init; }
        public DestinyArtifactCharacterScoped SeasonalArtifact { get; init; }

        [JsonConstructor]
        internal DestinyCharacterProgressionComponent(Dictionary<uint, DestinyProgression> progressions, Dictionary<uint, DestinyFactionProgression> factions,
            Dictionary<uint, DestinyMilestone> milestones, DestinyQuestStatus[] quests, Dictionary<uint, UninstancedItemObjective[]> uninstancedItemObjectives, Dictionary<uint, Dictionary<uint, bool>> checklists,
            DestinyArtifactCharacterScoped seasonalArtifact)
        {
            Progressions = progressions.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyProgressionDefinition, DestinyProgression>(DefinitionsEnum.DestinyProgressionDefinition);
            Factions = factions.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyFactionDefinition, DestinyFactionProgression>(DefinitionsEnum.DestinyFactionDefinition);
            Milestones = milestones.AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyMilestoneDefinition, DestinyMilestone>(DefinitionsEnum.DestinyMilestoneDefinition);
            Quests = quests.AsReadOnlyOrEmpty();
            UninstancedItemObjectives = uninstancedItemObjectives.ToDictionary(x => x.Key, x => x.Value.AsReadOnlyOrEmpty()).AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyInventoryItemDefinition, ReadOnlyCollection<UninstancedItemObjective>>(DefinitionsEnum.DestinyInventoryItemDefinition);
            Checklists = checklists.ToDictionary(x => x.Key, x=> x.Value.AsReadOnlyDictionaryOrEmpty()).AsReadOnlyDictionaryWithDefinitionKeyOrEmpty<DestinyChecklistDefinition, ReadOnlyDictionary<uint, bool>>(DefinitionsEnum.DestinyChecklistDefinition);
            SeasonalArtifact = seasonalArtifact;
        }
    }
}
