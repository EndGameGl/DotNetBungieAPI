namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

/// <summary>
///     Sometimes, we know the specific activity that the Milestone wants you to play. This entity provides additional information about that Activity and all of its variants. (sometimes there's only one variant, but I think you get the point)
/// </summary>
public class DestinyMilestoneActivity
{
    /// <summary>
    ///     The hash of an arbitrarily chosen variant of this activity. We'll go ahead and call that the "canonical" activity, because if you're using this value you should only use it for properties that are common across the variants: things like the name of the activity, it's location, etc... Use this hash to look up the DestinyActivityDefinition of this activity for rendering data.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyActivityDefinition>("Destiny.Definitions.DestinyActivityDefinition")]
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    /// <summary>
    ///     The hash identifier of the most specific Activity Mode under which this activity is played. This is useful for situations where the activity in question is - for instance - a PVP map, but it's not clear what mode the PVP map is being played under. If it's a playlist, this will be less specific: but hopefully useful in some way.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyActivityModeDefinition>("Destiny.Definitions.DestinyActivityModeDefinition")]
    [JsonPropertyName("activityModeHash")]
    public uint? ActivityModeHash { get; set; }

    /// <summary>
    ///     The enumeration equivalent of the most specific Activity Mode under which this activity is played.
    /// </summary>
    [JsonPropertyName("activityModeType")]
    public Destiny.HistoricalStats.Definitions.DestinyActivityModeType? ActivityModeType { get; set; }

    /// <summary>
    ///     If the activity has modifiers, this will be the list of modifiers that all variants have in common. Perform lookups against DestinyActivityModifierDefinition which defines the modifier being applied to get at the modifier data. Note that, in the DestinyActivityDefinition, you will see many more modifiers than this being referred to: those are all *possible* modifiers for the activity, not the active ones. Use only the active ones to match what's really live.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.ActivityModifiers.DestinyActivityModifierDefinition>("Destiny.Definitions.ActivityModifiers.DestinyActivityModifierDefinition")]
    [JsonPropertyName("modifierHashes")]
    public uint[]? ModifierHashes { get; set; }

    /// <summary>
    ///     If you want more than just name/location/etc... you're going to have to dig into and show the variants of the conceptual activity. These will differ in seemingly arbitrary ways, like difficulty level and modifiers applied. Show it in whatever way tickles your fancy.
    /// </summary>
    [JsonPropertyName("variants")]
    public Destiny.Milestones.DestinyMilestoneActivityVariant[]? Variants { get; set; }
}
