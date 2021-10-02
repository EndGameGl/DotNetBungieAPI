using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Definitions.Activities;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Milestones
{
    /// <summary>
    ///     Represents a variant on an activity for a Milestone: a specific difficulty tier, or a specific activity variant for
    ///     example.
    ///     <para />
    ///     These will often have more specific details, such as an associated Guided Game, progression steps, tier-specific
    ///     rewards, and custom values.
    /// </summary>
    public sealed record
        DestinyMilestoneActivityVariantDefinition : IDeepEquatable<DestinyMilestoneActivityVariantDefinition>
    {
        /// <summary>
        ///     The hash to use for looking up the variant Activity's definition (DestinyActivityDefinition), where you can find
        ///     its distinguishing characteristics such as difficulty level and recommended light level.
        /// </summary>
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } =
            DefinitionHashPointer<DestinyActivityDefinition>.Empty;

        /// <summary>
        ///     If you care to do so, render the variants in the order prescribed by this value.
        ///     <para />
        ///     When you combine live Milestone data with the definition, the order becomes more useful because you'll be
        ///     cross-referencing between the definition and live data.
        /// </summary>
        [JsonPropertyName("order")]
        public int Order { get; init; }

        public bool DeepEquals(DestinyMilestoneActivityVariantDefinition other)
        {
            return other != null &&
                   Activity.DeepEquals(other.Activity) &&
                   Order == other.Order;
        }
    }
}