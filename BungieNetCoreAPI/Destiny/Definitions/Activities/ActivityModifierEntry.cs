using BungieNetCoreAPI.Destiny.Definitions.ActivityModifiers;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    public class ActivityModifierEntry
    {
        public DefinitionHashPointer<DestinyActivityModifierDefinition> ActivityModifier { get; }

        [JsonConstructor]
        private ActivityModifierEntry(uint activityModifierHash)
        {
            ActivityModifier = new DefinitionHashPointer<DestinyActivityModifierDefinition>(activityModifierHash, DefinitionsEnum.DestinyActivityModifierDefinition);
        }
    }
}
