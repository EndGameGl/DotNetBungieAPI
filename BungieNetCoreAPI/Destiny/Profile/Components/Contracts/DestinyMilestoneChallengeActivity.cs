using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.ActivityModifiers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyMilestoneChallengeActivity
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public ReadOnlyCollection<DestinyChallengeStatus> Challenges { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; }
        public ReadOnlyDictionary<uint, bool> BooleanActivityOptions { get; }
        public int? LoadoutRequirementIndex { get; }
        public ReadOnlyCollection<DestinyMilestoneActivityPhase> Phases { get; }

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
