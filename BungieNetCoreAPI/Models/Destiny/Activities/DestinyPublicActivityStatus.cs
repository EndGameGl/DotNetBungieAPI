using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModifiers;
using NetBungieAPI.Models.Destiny.Definitions.Objectives;

namespace NetBungieAPI.Models.Destiny.Activities
{
    public sealed record DestinyPublicActivityStatus
    {
        [JsonPropertyName("challengeObjectiveHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>>
            ChallengeObjectives { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>>();
        [JsonPropertyName("modifierHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>>();

        [JsonPropertyName("rewardTooltipItems")]
        public ReadOnlyCollection<DestinyItemQuantity> RewardTooltipItems { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyItemQuantity>();
    }
}
