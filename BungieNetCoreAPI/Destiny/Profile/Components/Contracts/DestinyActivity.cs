using NetBungieApi.Destiny.Definitions.Activities;
using NetBungieApi.Destiny.Definitions.ActivityModifiers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyActivity
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public bool IsNew { get; }
        public bool CanLead { get; }
        public bool CanJoin { get; }
        public bool IsCompleted { get; }
        public bool IsVisible { get; }
        public int? DisplayLevel { get; }
        public int? RecommendedLight { get; }
        public int DifficultyTier { get; }
        public ReadOnlyCollection<DestinyChallengeStatus> Challenges { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; }
        public ReadOnlyDictionary<uint, bool> BooleanActivityOptions { get; }
        public int? LoadoutRequirementIndex { get; }

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
