using NetBungieAPI.Models.Destiny.Challenges;
using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModifiers;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Activities
{
    public sealed record DestinyActivity
    {
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        [JsonPropertyName("isNew")]
        public bool IsNew { get; init; }
        [JsonPropertyName("canLead")]
        public bool CanLead { get; init; }
        [JsonPropertyName("canJoin")]
        public bool CanJoin { get; init; }
        [JsonPropertyName("isCompleted")]
        public bool IsCompleted { get; init; }
        [JsonPropertyName("isVisible")]
        public bool IsVisible { get; init; }
        [JsonPropertyName("displayLevel")]
        public int? DisplayLevel { get; init; }
        [JsonPropertyName("recommendedLight")]
        public int? RecommendedLight { get; init; }
        [JsonPropertyName("difficultyTier")]
        public int DifficultyTier { get; init; }
        [JsonPropertyName("challenges")]
        public ReadOnlyCollection<DestinyChallengeStatus> Challenges { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyChallengeStatus>();
        [JsonPropertyName("modifierHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>>();
        [JsonPropertyName("booleanActivityOptions")]
        public ReadOnlyDictionary<uint, bool> BooleanActivityOptions { get; init; } = Defaults.EmptyReadOnlyDictionary<uint, bool>();
        [JsonPropertyName("loadoutRequirementIndex")]
        public int? LoadoutRequirementIndex { get; init; }
    }
}
