using BungieNetCoreAPI.Destiny.Definitions.Locations;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    public class ActivityLocationMappingDefinition
    {
        public string ActivationSource { get; }
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public DefinitionHashPointer<DestinyLocationDefinition> Location { get; }

        [JsonConstructor]
        private ActivityLocationMappingDefinition(string activationSource, uint activityHash, uint locationHash)
        {
            ActivationSource = activationSource;
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, "DestinyActivityDefinition");
            Location = new DefinitionHashPointer<DestinyLocationDefinition>(locationHash, "DestinyLocationDefinition");
        }
    }
}
