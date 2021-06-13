using NetBungieAPI.Models.Destiny.Definitions.ActivityModifiers;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Activities
{
    /// <summary>
    /// A reference to an Activity Modifier from another entity, such as an Activity (for now, just Activities)
    /// </summary>
    public class DestinyActivityModifierReferenceDefinition : IDeepEquatable<DestinyActivityModifierReferenceDefinition>
    {
        /// <summary>
        /// DestinyActivityModifierDefinition referenced by this activity.
        /// </summary>
        [JsonPropertyName("activityModifierHash")]
        public DefinitionHashPointer<DestinyActivityModifierDefinition> ActivityModifier { get; init; } =
            DefinitionHashPointer<DestinyActivityModifierDefinition>.Empty;

        public bool DeepEquals(DestinyActivityModifierReferenceDefinition other)
        {
            return other != null && ActivityModifier.DeepEquals(other.ActivityModifier);
        }
    }
}