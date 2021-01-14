using BungieNetCoreAPI.Destiny.Definitions.Activities;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityInteractables
{
    public class ActivityInteractableEntry
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }

        [JsonConstructor]
        private ActivityInteractableEntry(uint activityHash)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, "DestinyActivityDefinition");
        }
    }
}
