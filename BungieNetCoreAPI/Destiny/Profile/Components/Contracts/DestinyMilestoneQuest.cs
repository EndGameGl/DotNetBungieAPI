using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    /// <summary>
    /// If a Milestone has one or more Quests, this will contain the live information for the character's status with one of those quests.
    /// </summary>
    public class DestinyMilestoneQuest
    {
        public DefinitionHashPointer<DestinyInventoryItemDefinition> QuestItem { get; init; }
        public DestinyQuestStatus Status { get; init; }
        public DestinyMilestoneActivity Activity { get; init; }
        public ReadOnlyCollection<DestinyChallengeStatus> Challenges { get; init; }

        [JsonConstructor]
        internal DestinyMilestoneQuest(uint questItemHash, DestinyQuestStatus status, DestinyMilestoneActivity activity, 
            DestinyChallengeStatus[] challenges)
        {
            QuestItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(questItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
            Status = status;
            Activity = activity;
            Challenges = challenges.AsReadOnlyOrEmpty();
        }
    }
}
