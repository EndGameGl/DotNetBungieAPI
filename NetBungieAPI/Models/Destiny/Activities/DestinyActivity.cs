using NetBungieAPI.Models.Destiny.Challenges;
using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModifiers;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Activities
{
    /// <summary>
    /// Represents the "Live" data that we can obtain about a Character's status with a specific Activity. This will tell you whether the character can participate in the activity, as well as some other basic mutable information.
    /// <para/>
    /// Meant to be combined with static DestinyActivityDefinition data for a full picture of the Activity.
    /// </summary>
    public sealed record DestinyActivity
    {
        /// <summary>
        /// The hash identifier of the Activity. Use this to look up the DestinyActivityDefinition of the activity.
        /// </summary>
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } =
            DefinitionHashPointer<DestinyActivityDefinition>.Empty;

        /// <summary>
        /// If true, then the activity should have a "new" indicator in the Director UI.
        /// </summary>
        [JsonPropertyName("isNew")]
        public bool IsNew { get; init; }

        /// <summary>
        /// If true, the user is allowed to lead a Fireteam into this activity.
        /// </summary>
        [JsonPropertyName("canLead")]
        public bool CanLead { get; init; }

        /// <summary>
        /// If true, the user is allowed to join with another Fireteam in this activity.
        /// </summary>
        [JsonPropertyName("canJoin")]
        public bool CanJoin { get; init; }

        /// <summary>
        /// If true, we both have the ability to know that the user has completed this activity and they have completed it. Unfortunately, we can't necessarily know this for all activities. As such, this should probably only be used if you already know in advance which specific activities you wish to check.
        /// </summary>
        [JsonPropertyName("isCompleted")]
        public bool IsCompleted { get; init; }

        /// <summary>
        /// If true, the user should be able to see this activity.
        /// </summary>
        [JsonPropertyName("isVisible")]
        public bool IsVisible { get; init; }

        /// <summary>
        /// The difficulty level of the activity, if applicable.
        /// </summary>
        [JsonPropertyName("displayLevel")]
        public int? DisplayLevel { get; init; }

        /// <summary>
        /// The recommended light level for the activity, if applicable.
        /// </summary>
        [JsonPropertyName("recommendedLight")]
        public int? RecommendedLight { get; init; }

        /// <summary>
        /// A DestinyActivityDifficultyTier enum value indicating the difficulty of the activity.
        /// </summary>
        [JsonPropertyName("difficultyTier")]
        public DestinyActivityDifficultyTier DifficultyTier { get; init; }

        [JsonPropertyName("challenges")]
        public ReadOnlyCollection<DestinyChallengeStatus> Challenges { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyChallengeStatus>();

        /// <summary>
        /// If the activity has modifiers, this will be the list of modifiers that all variants have in common. Perform lookups against DestinyActivityModifierDefinition which defines the modifier being applied to get at the modifier data.
        /// <para/>
        /// Note that, in the DestiyActivityDefinition, you will see many more modifiers than this being referred to: those are all *possible* modifiers for the activity, not the active ones. Use only the active ones to match what's really live.
        /// </summary>
        [JsonPropertyName("modifierHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>>();

        /// <summary>
        /// The set of activity options for this activity, keyed by an identifier that's unique for this activity (not guaranteed to be unique between or across all activities, though should be unique for every *variant* of a given *conceptual* activity: for instance, the original D2 Raid has many variant DestinyActivityDefinitions. While other activities could potentially have the same option hashes, for any given D2 base Raid variant the hash will be unique).
        /// <para/>
        /// As a concrete example of this data, the hashes you get for Raids will correspond to the currently active "Challenge Mode".
        /// <para/>
        /// We don't have any human readable information for these, but saavy 3rd party app users could manually associate the key (a hash identifier for the "option" that is enabled/disabled) and the value (whether it's enabled or disabled presently)
        /// <para/>
        /// On our side, we don't necessarily even know what these are used for (the game designers know, but we don't), and we have no human readable data for them. In order to use them, you will have to do some experimentation.
        /// </summary>
        [JsonPropertyName("booleanActivityOptions")]
        public ReadOnlyDictionary<uint, bool> BooleanActivityOptions { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, bool>();

        /// <summary>
        /// If returned, this is the index into the DestinyActivityDefinition's "loadouts" property, indicating the currently active loadout requirements.
        /// </summary>
        [JsonPropertyName("loadoutRequirementIndex")]
        public int? LoadoutRequirementIndex { get; init; }
    }
}