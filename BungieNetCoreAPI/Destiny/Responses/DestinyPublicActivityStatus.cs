using NetBungieAPI.Destiny.Definitions.ActivityModifiers;
using NetBungieAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Responses
{
    public class DestinyPublicActivityStatus
    {
        public ReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>> ChallengeObjectives { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; init; }
        public ReadOnlyCollection<DestinyItemQuantity> RewardTooltipItems { get; init; }

        [JsonConstructor]
        internal DestinyPublicActivityStatus(uint[] challengeObjectiveHashes, uint[] modifierHashes, DestinyItemQuantity[] rewardTooltipItems)
        {
            ChallengeObjectives = challengeObjectiveHashes.DefinitionsAsReadOnlyOrEmpty<DestinyObjectiveDefinition>(DefinitionsEnum.DestinyObjectiveDefinition);
            Modifiers = modifierHashes.DefinitionsAsReadOnlyOrEmpty<DestinyActivityModifierDefinition>(DefinitionsEnum.DestinyActivityModifierDefinition);
            RewardTooltipItems = rewardTooltipItems.AsReadOnlyOrEmpty();
        }
    }
}
