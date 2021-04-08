using NetBungieAPI.Destiny.Definitions.Milestones;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPublicMilestoneQuest
    {
        public DefinitionHashPointer<DestinyMilestoneDefinition> QuestItem { get; init; }
        public DestinyPublicMilestoneActivity Activity { get; init; }
        public ReadOnlyCollection<DestinyPublicMilestoneChallenge> Challenges { get; init; }

        [JsonConstructor]
        internal DestinyPublicMilestoneQuest(uint questItemHash, DestinyPublicMilestoneActivity activity, DestinyPublicMilestoneChallenge[] challenges)
        {
            QuestItem = new DefinitionHashPointer<DestinyMilestoneDefinition>(questItemHash, DefinitionsEnum.DestinyMilestoneDefinition);
            Activity = activity;
            Challenges = challenges.AsReadOnlyOrEmpty();
        }
    }
}
