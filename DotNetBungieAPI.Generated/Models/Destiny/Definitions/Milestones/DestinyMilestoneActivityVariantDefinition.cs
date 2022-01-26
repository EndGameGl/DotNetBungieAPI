namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

/// <summary>
///     Represents a variant on an activity for a Milestone: a specific difficulty tier, or a specific activity variant for example.
/// <para />
///     These will often have more specific details, such as an associated Guided Game, progression steps, tier-specific rewards, and custom values.
/// </summary>
public class DestinyMilestoneActivityVariantDefinition : IDeepEquatable<DestinyMilestoneActivityVariantDefinition>
{
    /// <summary>
    ///     The hash to use for looking up the variant Activity's definition (DestinyActivityDefinition), where you can find its distinguishing characteristics such as difficulty level and recommended light level. 
    /// <para />
    ///     Frequently, that will be the only distinguishing characteristics in practice, which is somewhat of a bummer.
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    /// <summary>
    ///     If you care to do so, render the variants in the order prescribed by this value.
    /// <para />
    ///     When you combine live Milestone data with the definition, the order becomes more useful because you'll be cross-referencing between the definition and live data.
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; set; }

    public bool DeepEquals(DestinyMilestoneActivityVariantDefinition? other)
    {
        return other is not null &&
               ActivityHash == other.ActivityHash &&
               Order == other.Order;
    }
}