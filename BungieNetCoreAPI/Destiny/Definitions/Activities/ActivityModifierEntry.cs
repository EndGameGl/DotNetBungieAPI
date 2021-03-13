using NetBungieApi.Destiny.Definitions.ActivityModifiers;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Activities
{
    /// <summary>
    /// A reference to an Activity Modifier from another entity, such as an Activity (for now, just Activities)
    /// </summary>
    public class ActivityModifierEntry : IDeepEquatable<ActivityModifierEntry>
    {
        public DefinitionHashPointer<DestinyActivityModifierDefinition> ActivityModifier { get; }

        [JsonConstructor]
        internal ActivityModifierEntry(uint activityModifierHash)
        {
            ActivityModifier = new DefinitionHashPointer<DestinyActivityModifierDefinition>(activityModifierHash, DefinitionsEnum.DestinyActivityModifierDefinition);
        }

        public bool DeepEquals(ActivityModifierEntry other)
        {
            return other != null && ActivityModifier.DeepEquals(other.ActivityModifier);
        }
    }
}
