using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModifiers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyActivity
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; }
        public bool IsNew { get; init; }
        public bool CanLead { get; init; }
        public bool CanJoin { get; init; }
        public bool IsCompleted { get; init; }
        public bool IsVisible { get; init; }
        public int? DisplayLevel { get; init; }
        public int? RecommendedLight { get; init; }
        public int DifficultyTier { get; init; }
        public ReadOnlyCollection<DestinyChallengeStatus> Challenges { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; init; }
        public ReadOnlyDictionary<uint, bool> BooleanActivityOptions { get; init; }
        public int? LoadoutRequirementIndex { get; init; }

        [JsonConstructor]
        internal DestinyActivity(uint activityHash, bool isNew, bool canLead, bool canJoin, bool isCompleted, bool isVisible, int? displayLevel,
            int? recommendedLight, int difficultyTier, DestinyChallengeStatus[] challenges, uint[] modifierHashes,
            Dictionary<uint, bool> booleanActivityOptions, int? loadoutRequirementIndex)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            IsNew = isNew;
            CanLead = canLead;
            CanJoin = canJoin;
            IsCompleted = isCompleted;
            IsVisible = IsVisible;
            DisplayLevel = displayLevel;
            RecommendedLight = recommendedLight;
            DifficultyTier = difficultyTier;
            Challenges = challenges.AsReadOnlyOrEmpty();
            Modifiers = modifierHashes.DefinitionsAsReadOnlyOrEmpty<DestinyActivityModifierDefinition>(DefinitionsEnum.DestinyActivityModifierDefinition);
            BooleanActivityOptions = booleanActivityOptions.AsReadOnlyDictionaryOrEmpty();
            LoadoutRequirementIndex = loadoutRequirementIndex;
        }
    }
}
