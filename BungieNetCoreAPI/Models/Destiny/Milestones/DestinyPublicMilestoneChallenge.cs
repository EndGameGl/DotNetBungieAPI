using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.Objectives;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyPublicMilestoneChallenge
    {
        [JsonPropertyName("objectiveHash")]
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; init; } = DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
    }
}
