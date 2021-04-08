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
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>> ChallengeObjectives { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; init; }
        public int? LoadoutRequirementIndex { get; init; }
        public ReadOnlyCollection<uint> PhaseHashes { get; init; }
        public ReadOnlyDictionary<uint, bool> BooleanActivityOptions { get; init; }

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
