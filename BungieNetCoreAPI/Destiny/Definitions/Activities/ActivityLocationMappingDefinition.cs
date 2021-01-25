using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using BungieNetCoreAPI.Destiny.Definitions.Locations;
using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    public class ActivityLocationMappingDefinition
    {
        public string ActivationSource { get; }
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public DefinitionHashPointer<DestinyLocationDefinition> Location { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; }

        [JsonConstructor]
        private ActivityLocationMappingDefinition(string activationSource, uint? activityHash, uint? locationHash, uint? itemHash, uint? objectiveHash)
        {
            ActivationSource = activationSource;
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            Location = new DefinitionHashPointer<DestinyLocationDefinition>(locationHash, DefinitionsEnum.DestinyLocationDefinition);
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Objective = new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, DefinitionsEnum.DestinyObjectiveDefinition);
        }
    }
}
