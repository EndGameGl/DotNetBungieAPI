using BungieNetCoreAPI.Destiny.Definitions.Milestones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Responses
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
            Milestone = new DefinitionHashPointer<DestinyMilestoneDefinition>(milestoneHash, "DestinyMilestoneDefinition");
            AvailableQuests = availableQuests;
            Order = order;
            StartDate = startDate;
            EndDate = endDate;
            Activities = activities;
        }
    }
}
