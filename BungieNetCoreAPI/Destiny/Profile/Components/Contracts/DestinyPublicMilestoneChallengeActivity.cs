using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Definitions.ActivityModifiers;
using NetBungieAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPublicMilestoneChallengeActivity
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>> ChallengeObjectives { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; }
        public int? LoadoutRequirementIndex { get; }
        public ReadOnlyCollection<uint> PhaseHashes { get; }
        public ReadOnlyDictionary<uint, bool> BooleanActivityOptions { get; }

        [JsonConstructor]
        internal DestinyPublicMilestoneChallengeActivity(uint activityHash, uint[] challengeObjectiveHashes, uint[] modifierHashes, int? loadoutRequirementIndex,
            uint[] phaseHashes, Dictionary<uint, bool> booleanActivityOptions)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, DefinitionsEnum.DestinyActivityDefinition);
            ChallengeObjectives = challengeObjectiveHashes.DefinitionsAsReadOnlyOrEmpty<DestinyObjectiveDefinition>(DefinitionsEnum.DestinyObjectiveDefinition);
            Modifiers = modifierHashes.DefinitionsAsReadOnlyOrEmpty<DestinyActivityModifierDefinition>(DefinitionsEnum.DestinyActivityModifierDefinition);
            LoadoutRequirementIndex = loadoutRequirementIndex;
            PhaseHashes = phaseHashes.AsReadOnlyOrEmpty();
            BooleanActivityOptions = booleanActivityOptions.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
