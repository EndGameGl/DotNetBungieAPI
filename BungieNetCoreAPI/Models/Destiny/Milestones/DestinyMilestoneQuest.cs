using NetBungieAPI.Models.Destiny.Challenges;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using NetBungieAPI.Models.Destiny.Quests;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    /// <summary>
    /// If a Milestone has one or more Quests, this will contain the live information for the character's status with one of those quests.
    /// </summary>
    public sealed record DestinyMilestoneQuest
    {
        [JsonPropertyName("questItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("status")]
        public DestinyQuestStatus Status { get; init; }
        [JsonPropertyName("activity")]
        public DestinyMilestoneActivity Activity { get; init; }
        [JsonPropertyName("challenges")]
        public ReadOnlyCollection<DestinyChallengeStatus> Challenges { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyChallengeStatus>();
    }
}
