using NetBungieAPI.Models.Destiny.Challenges;
using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModifiers;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyMilestoneChallengeActivity
    {
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        [JsonPropertyName("challenges")]
        public ReadOnlyCollection<DestinyChallengeStatus> Challenges { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyChallengeStatus>();
        [JsonPropertyName("modifierHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>>();
        [JsonPropertyName("booleanActivityOptions")]
        public ReadOnlyDictionary<uint, bool> BooleanActivityOptions { get; init; } = Defaults.EmptyReadOnlyDictionary<uint, bool>();
        [JsonPropertyName("loadoutRequirementIndex")]
        public int? LoadoutRequirementIndex { get; init; }
        [JsonPropertyName("phases")]
        public ReadOnlyCollection<DestinyMilestoneActivityPhase> Phases { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyMilestoneActivityPhase>();
    }
}
