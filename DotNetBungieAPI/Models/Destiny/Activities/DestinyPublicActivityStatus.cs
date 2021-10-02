using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Definitions.ActivityModifiers;
using DotNetBungieAPI.Models.Destiny.Definitions.Objectives;

namespace DotNetBungieAPI.Models.Destiny.Activities
{
    /// <summary>
    ///     Represents the public-facing status of an activity: any data about what is currently active in the Activity,
    ///     regardless of an individual character's progress in it.
    /// </summary>
    public sealed record DestinyPublicActivityStatus
    {
        /// <summary>
        ///     Active Challenges for the activity, if any - represented as hashes for DestinyObjectiveDefinitions.
        /// </summary>
        [JsonPropertyName("challengeObjectiveHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>>
            ChallengeObjectives { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>>();

        /// <summary>
        ///     The active modifiers on this activity, if any - represented as hashes for DestinyActivityModifierDefinitions.
        /// </summary>
        [JsonPropertyName("modifierHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>> Modifiers { get; init; } =
            Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyActivityModifierDefinition>>();

        /// <summary>
        ///     If the activity itself provides any specific "mock" rewards, this will be the items and their quantity.
        ///     <para />
        ///     Why "mock", you ask? Because these are the rewards as they are represented in the tooltip of the Activity.
        ///     <para />
        ///     These are often pointers to fake items that look good in a tooltip, but represent an abstract concept of what you
        ///     will get for a reward rather than the specific items you may obtain.
        /// </summary>
        [JsonPropertyName("rewardTooltipItems")]
        public ReadOnlyCollection<DestinyItemQuantity> RewardTooltipItems { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyItemQuantity>();
    }
}