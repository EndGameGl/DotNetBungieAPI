using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Destiny.Definitions.Locations;
using NetBungieAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;
using System;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyProfileTransitoryTrackingEntry
    {
        public DefinitionHashPointer<DestinyLocationDefinition> Location { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; }
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestlineItem { get; }
        public DateTime? TrackedDate { get; }

        [JsonConstructor]
        internal DestinyProfileTransitoryTrackingEntry(uint? locationHash, uint? itemHash, uint? objectiveHash, uint? activityHash, uint? questlineItemHash,
            DateTime? trackedDate)
        {
            Location = new DefinitionHashPointer<DestinyLocationDefinition>(locationHash, DefinitionsEnum.DestinyLocationDefinition);
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Objective = new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            QuestlineItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(questlineItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            TrackedDate = trackedDate;
        }
    }
}
