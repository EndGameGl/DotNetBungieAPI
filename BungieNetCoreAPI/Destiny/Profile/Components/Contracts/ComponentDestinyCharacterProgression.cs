using BungieNetCoreAPI.Destiny.Definitions.Checklists;
using BungieNetCoreAPI.Destiny.Definitions.Factions;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.Milestones;
using BungieNetCoreAPI.Destiny.Definitions.Progressions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class ComponentDestinyCharacterProgression
    {
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyProgressionDefinition>, DestinyProgression> Progressions { get; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyFactionDefinition>, DestinyFactionProgression> Factions { get; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyMilestoneDefinition>, DestinyMilestone> Milestones { get; }
        public ReadOnlyCollection<DestinyQuestStatus> Quests { get; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, ReadOnlyCollection<UninstancedItemObjective>> UninstancedItemObjectives { get; }
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyChecklistDefinition>, ReadOnlyDictionary<uint, bool>> Checklists { get; }
        public DestinyArtifactCharacterScoped SeasonalArtifact { get; }

        [JsonConstructor]
        internal ComponentDestinyCharacterProgression(Dictionary<uint, DestinyProgression> progressions, Dictionary<uint, DestinyFactionProgression> factions,
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
