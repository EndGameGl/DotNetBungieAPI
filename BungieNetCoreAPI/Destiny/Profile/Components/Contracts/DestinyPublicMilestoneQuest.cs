using NetBungieAPI.Destiny.Definitions.Milestones;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPublicMilestoneQuest
    {
        public DefinitionHashPointer<DestinyMilestoneDefinition> QuestItem { get; }
        public DestinyPublicMilestoneActivity Activity { get; }
        public ReadOnlyCollection<DestinyPublicMilestoneChallenge> Challenges { get; }

        [JsonConstructor]
        internal DestinyPublicMilestoneQuest(uint questItemHash, DestinyPublicMilestoneActivity activity, DestinyPublicMilestoneChallenge[] challenges)
        {
            QuestItem = new DefinitionHashPointer<DestinyMilestoneDefinition>(questItemHash, DefinitionsEnum.DestinyMilestoneDefinition);
            Activity = activity;
            Challenges = challenges.AsReadOnlyOrEmpty();
        }
    }
}
