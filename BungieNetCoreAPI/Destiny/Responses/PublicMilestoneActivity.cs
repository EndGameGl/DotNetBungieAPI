using BungieNetCoreAPI.Destiny.Definitions.Activities;
using BungieNetCoreAPI.Destiny.Definitions.ActivityModifiers;
using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Responses
{
    public class PublicMilestoneActivity
    {
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; }
        public List<DefinitionHashPointer<DestinyObjectiveDefinition>> ChallengeObjectives { get; }
        public List<uint> PhaseHashes { get; }
        public Dictionary<uint, bool> BooleanActivityOptions { get; }
        public List<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; } 

        [JsonConstructor]
        private PublicMilestoneActivity(uint activityHash, List<uint> challengeObjectiveHashes, List<uint> phaseHashes, Dictionary<uint, bool> booleanActivityOptions,
            List<uint> modifierHashes)
        {
            Activity = new DefinitionHashPointer<DestinyActivityDefinition>(activityHash, "DestinyActivityDefinition");
            ChallengeObjectives = new List<DefinitionHashPointer<DestinyObjectiveDefinition>>();
            if (challengeObjectiveHashes != null)
            {
                foreach (var challengeObjectiveHash in challengeObjectiveHashes)
                {
                    ChallengeObjectives.Add(new DefinitionHashPointer<DestinyObjectiveDefinition>(challengeObjectiveHash, "DestinyObjectiveDefinition"));
                }
            }
            PhaseHashes = phaseHashes;
            BooleanActivityOptions = booleanActivityOptions;

            //BooleanActivityOptions = new Dictionary<DefinitionHashPointer<DestinyObjectiveDefinition>, bool>();
            //if (booleanActivityOptions != null)
            //{
            //    foreach (var booleanActivityOption in booleanActivityOptions)
            //    {
            //        BooleanActivityOptions.Add(new DefinitionHashPointer<DestinyObjectiveDefinition>(booleanActivityOption.Key, "DestinyObjectiveDefinition", "en"), booleanActivityOption.Value);
            //    }
            //}

            Modifiers = new List<DefinitionHashPointer<DestinyActivityModifierDefinition>>();
            if (modifierHashes != null)
            {
                foreach (var modifierHash in modifierHashes)
                {
                    Modifiers.Add(new DefinitionHashPointer<DestinyActivityModifierDefinition>(modifierHash, "DestinyActivityModifierDefinition"));
                }
            }
        }
    }
}
