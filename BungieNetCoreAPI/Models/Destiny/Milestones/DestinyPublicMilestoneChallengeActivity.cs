using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModifiers;
using NetBungieAPI.Models.Destiny.Definitions.Objectives;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyPublicMilestoneChallengeActivity
    {
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } =
            DefinitionHashPointer<DestinyActivityDefinition>.Empty;

        [JsonPropertyName("challengeObjectiveHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>>
            ChallengeObjectives { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>>();

        /// <summary>
        /// If the activity has modifiers, this will be the list of modifiers that all variants have in common. Perform lookups against DestinyActivityModifierDefinition which defines the modifier being applied to get at the modifier data.
        /// <para/>
        /// Note that, in the DestiyActivityDefinition, you will see many more modifiers than this being referred to: those are all *possible* modifiers for the activity, not the active ones. Use only the active ones to match what's really live.
        /// </summary>
        [JsonPropertyName("modifierHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>>();

        /// <summary>
        /// If returned, this is the index into the DestinyActivityDefinition's "loadouts" property, indicating the currently active loadout requirements.
        /// </summary>
        [JsonPropertyName("loadoutRequirementIndex")]
        public int? LoadoutRequirementIndex { get; init; }

        /// <summary>
        /// The ordered list of phases for this activity, if any. Note that we have no human readable info for phases, nor any entities to relate them to: relating these hashes to something human readable is up to you unfortunately.
        /// </summary>
        [JsonPropertyName("phaseHashes")]
        public ReadOnlyCollection<uint> PhaseHashes { get; init; } = Defaults.EmptyReadOnlyCollection<uint>();

        /// <summary>
        /// The set of activity options for this activity, keyed by an identifier that's unique for this activity (not guaranteed to be unique between or across all activities, though should be unique for every *variant* of a given *conceptual* activity: for instance, the original D2 Raid has many variant DestinyActivityDefinitions. While other activities could potentially have the same option hashes, for any given D2 base Raid variant the hash will be unique).
        /// <para/>
        /// As a concrete example of this data, the hashes you get for Raids will correspond to the currently active "Challenge Mode".
        /// <para/>
        /// We have no human readable information for this data, so it's up to you if you want to associate it with such info to show it.
        /// </summary>
        [JsonPropertyName("booleanActivityOptions")]
        public ReadOnlyDictionary<uint, bool> BooleanActivityOptions { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, bool>();
    }
}