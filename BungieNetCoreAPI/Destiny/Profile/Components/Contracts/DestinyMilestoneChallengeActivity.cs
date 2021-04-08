using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Definitions.ActivityModifiers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestoneChallengeActivity
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; }
        public ReadOnlyCollection<DestinyChallengeStatus> Challenges { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; init; }
        public ReadOnlyDictionary<uint, bool> BooleanActivityOptions { get; init; }
        public int? LoadoutRequirementIndex { get; init; }
        public ReadOnlyCollection<DestinyMilestoneActivityPhase> Phases { get; init; }

        [JsonConstructor]
        internal DestinyMilestoneChallengeActivity(uint activityHash, DestinyChallengeStatus[] challenges, uint[] modifierHashes, 
            Dictionary<uint, bool> booleanActivityOptions, int? loadoutRequirementIndex, DestinyMilestoneActivityPhase[] phases)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            Challenges = challenges.AsReadOnlyOrEmpty();
            Modifiers = modifierHashes.DefinitionsAsReadOnlyOrEmpty<DestinyActivityModifierDefinition>(DefinitionsEnum.DestinyActivityModifierDefinition);
            BooleanActivityOptions = booleanActivityOptions.AsReadOnlyDictionaryOrEmpty();
            LoadoutRequirementIndex = loadoutRequirementIndex;
            Phases = phases.AsReadOnlyOrEmpty();
        }
    }
}
