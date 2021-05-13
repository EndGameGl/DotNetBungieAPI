using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModifiers;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    /// <summary>
    /// A milestone may have one or more conceptual Activities associated with it, and each of those conceptual activities could have a variety of variants, modes, tiers, what-have-you. Our attempts to determine what qualifies as a conceptual activity are, unfortunately, janky. So if you see missing modes or modes that don't seem appropriate to you, let us know and I'll buy you a beer if we ever meet up in person.
    /// </summary>
    public sealed record DestinyPublicMilestoneActivity
    {
        /// <summary>
        /// The hash identifier of the activity that's been chosen to be considered the canonical "conceptual" activity definition. This may have many variants, defined herein.
        /// </summary>
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } =
            DefinitionHashPointer<DestinyActivityDefinition>.Empty;

        /// <summary>
        /// The activity may have 0-to-many modifiers: if it does, this will contain the hashes to the DestinyActivityModifierDefinition that defines the modifier being applied.
        /// </summary>
        [JsonPropertyName("modifierHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>>();

        /// <summary>
        /// Every relevant variation of this conceptual activity, including the conceptual activity itself, have variants defined here.
        /// </summary>
        [JsonPropertyName("variants")]
        public ReadOnlyCollection<DestinyPublicMilestoneActivityVariant> Variants { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyPublicMilestoneActivityVariant>();

        /// <summary>
        /// The hash identifier of the most specific Activity Mode under which this activity is played. This is useful for situations where the activity in question is - for instance - a PVP map, but it's not clear what mode the PVP map is being played under. If it's a playlist, this will be less specific: but hopefully useful in some way.
        /// </summary>
        [JsonPropertyName("activityModeHash")]
        public DefinitionHashPointer<DestinyActivityModeDefinition> ActivityMode { get; init; } =
            DefinitionHashPointer<DestinyActivityModeDefinition>.Empty;

        /// <summary>
        /// The enumeration equivalent of the most specific Activity Mode under which this activity is played.
        /// </summary>
        [JsonPropertyName("activityModeType")]
        public DestinyActivityModeType? ActivityModeType { get; init; }
    }
}