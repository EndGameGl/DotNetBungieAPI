using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyMilestoneActivityVariant
    {
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        [JsonPropertyName("completionStatus")]
        public DestinyMilestoneActivityCompletionStatus CompletionStatus { get; init; }
        [JsonPropertyName("activityModeHash")]
        public DefinitionHashPointer<DestinyActivityModeDefinition> ActivityMode { get; init; } = DefinitionHashPointer<DestinyActivityModeDefinition>.Empty;
        [JsonPropertyName("activityModeType")]
        public DestinyActivityModeType? ActivityModeType { get; init; }
    }
}
