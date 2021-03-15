using NetBungieAPI.Destiny.Definitions.Milestones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NetBungieAPI.Destiny.Responses
{
    public class GetPublicMilestonesResponse
    {
        public DefinitionHashPointer<DestinyMilestoneDefinition> Milestone { get; }
        public List<PublicMilestoneAvailableQuest> AvailableQuests { get; }
        public List<PublicMilestoneActivity> Activities { get; }
        public int Order { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }

        [JsonConstructor]
        private GetPublicMilestonesResponse(uint milestoneHash, List<PublicMilestoneAvailableQuest> availableQuests, int order, DateTime? startDate, DateTime? endDate,
            List<PublicMilestoneActivity> activities)
        {
            Milestone = new DefinitionHashPointer<DestinyMilestoneDefinition>(milestoneHash, DefinitionsEnum.DestinyMilestoneDefinition);
            AvailableQuests = availableQuests;
            Order = order;
            StartDate = startDate;
            EndDate = endDate;
            Activities = activities;
        }
    }
}
