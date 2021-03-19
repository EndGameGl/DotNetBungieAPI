using NetBungieAPI.Destiny.Definitions.ActivityModifiers;
using NetBungieAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Responses
{
    public class DestinyPublicActivityStatus
    {
        public ReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>> ChallengeObjectives { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; }
        public ReadOnlyCollection<DestinyItemQuantity> RewardTooltipItems { get; }

        [JsonConstructor]
        internal DestinyPublicActivityStatus(uint[] challengeObjectiveHashes, uint[] modifierHashes, DestinyItemQuantity[] rewardTooltipItems)
        {
            ChallengeObjectives = challengeObjectiveHashes.DefinitionsAsReadOnlyOrEmpty<DestinyObjectiveDefinition>(DefinitionsEnum.DestinyObjectiveDefinition);
            Modifiers = modifierHashes.DefinitionsAsReadOnlyOrEmpty<DestinyActivityModifierDefinition>(DefinitionsEnum.DestinyActivityModifierDefinition);
            RewardTooltipItems = rewardTooltipItems.AsReadOnlyOrEmpty();
        }
    }
}
