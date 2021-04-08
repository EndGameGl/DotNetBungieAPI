using NetBungieAPI.Destiny.Definitions.Milestones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NetBungieAPI.Destiny.Responses
{
    public class GetPublicMilestonesResponse
    {
        public DefinitionHashPointer<DestinyMilestoneDefinition> Milestone { get; init; }
        public List<PublicMilestoneAvailableQuest> AvailableQuests { get; init; }
        public List<PublicMilestoneActivity> Activities { get; init; }
        public int Order { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }

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
