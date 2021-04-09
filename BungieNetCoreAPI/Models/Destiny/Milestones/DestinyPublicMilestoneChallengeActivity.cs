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
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        [JsonPropertyName("challengeObjectiveHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>> ChallengeObjectives { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>>();
        [JsonPropertyName("modifierHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>>();
        [JsonPropertyName("loadoutRequirementIndex")]
        public int? LoadoutRequirementIndex { get; init; }
        [JsonPropertyName("phaseHashes")]
        public ReadOnlyCollection<uint> PhaseHashes { get; init; } = Defaults.EmptyReadOnlyCollection<uint>();
        [JsonPropertyName("booleanActivityOptions")]
        public ReadOnlyDictionary<uint, bool> BooleanActivityOptions { get; init; } = Defaults.EmptyReadOnlyDictionary<uint, bool>();
    }
}
