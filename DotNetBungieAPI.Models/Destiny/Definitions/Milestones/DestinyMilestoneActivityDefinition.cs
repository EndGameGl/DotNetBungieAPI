using DotNetBungieAPI.Models.Destiny.Definitions.Activities;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Milestones;

/// <summary>
///     Milestones can have associated activities which provide additional information about the context, challenges,
///     modifiers, state etc... related to this Milestone.
///     <para />
///     Information we need to be able to return that data is defined here, along with Tier data to establish a
///     relationship between a conceptual Activity and its difficulty levels and variants.
/// </summary>
public sealed record DestinyMilestoneActivityDefinition
    : IDeepEquatable<DestinyMilestoneActivityDefinition>
{
    /// <summary>
    ///     The "Conceptual" activity hash. Basically, we picked the lowest level activity and are treating it as the canonical
    ///     definition of the activity for rendering purposes.
    ///     <para />
    ///     If you care about the specific difficulty modes and variations, use the activities under "Variants".
    /// </summary>
    [JsonPropertyName("conceptualActivityHash")]
    public DefinitionHashPointer<DestinyActivityDefinition> ConceptualActivity { get; init; } =
        DefinitionHashPointer<DestinyActivityDefinition>.Empty;

    /// <summary>
    ///     A milestone-referenced activity can have many variants, such as Tiers or alternative modes of play.
    ///     <para />
    ///     Even if there is only a single variant, the details for these are represented within as a variant definition.
    ///     <para />
    ///     It is assumed that, if this DestinyMilestoneActivityDefinition is active, then all variants should be active.
    ///     <para />
    ///     If a Milestone could ever split the variants' active status conditionally, they should all have their own
    ///     DestinyMilestoneActivityDefinition instead! The potential duplication will be worth it for the obviousness of
    ///     processing and use.
    /// </summary>
    [JsonPropertyName("variants")]
    public ReadOnlyDictionary<
        DefinitionHashPointer<DestinyActivityDefinition>,
        DestinyMilestoneActivityVariantDefinition
    > Variants { get; init; } =
        ReadOnlyDictionaries<
            DefinitionHashPointer<DestinyActivityDefinition>,
            DestinyMilestoneActivityVariantDefinition
        >.Empty;

    public bool DeepEquals(DestinyMilestoneActivityDefinition other)
    {
        return other != null
            && ConceptualActivity.DeepEquals(other.ConceptualActivity)
            && Variants.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(other.Variants);
    }
}
