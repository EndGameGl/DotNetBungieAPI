using NetBungieAPI.Models.Destiny.Definitions.Activities;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Milestones
{
    /// <summary>
    /// Milestones can have associated activities which provide additional information about the context, challenges, modifiers, state etc... related to this Milestone.
    /// <para/>
    /// Information we need to be able to return that data is defined here, along with Tier data to establish a relationship between a conceptual Activity and its difficulty levels and variants.
    /// </summary>
    public sealed record DestinyMilestoneActivityDefinition : IDeepEquatable<DestinyMilestoneActivityDefinition>
    {
        [JsonPropertyName("conceptualActivityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> ConceptualActivity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;

        [JsonPropertyName("variants")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyActivityDefinition>, DestinyMilestoneActivityVariantDefinition> Variants { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyActivityDefinition>, DestinyMilestoneActivityVariantDefinition>();

        public bool DeepEquals(DestinyMilestoneActivityDefinition other)
        {
            return other != null &&
                   ConceptualActivity.DeepEquals(other.ConceptualActivity) &&
                   Variants.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(other.Variants);
        }
    }
}
