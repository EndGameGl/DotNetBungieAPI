using BungieNetCoreAPI.Destiny.Definitions.Activities;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityInteractables
{
    public class ActivityInteractableEntry : IDeepEquatable<ActivityInteractableEntry>
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }

        [JsonConstructor]
        internal ActivityInteractableEntry(uint activityHash)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
        }

        public bool DeepEquals(ActivityInteractableEntry other)
        {
            return other != null && Activity.DeepEquals(other.Activity);
        }
    }
}
