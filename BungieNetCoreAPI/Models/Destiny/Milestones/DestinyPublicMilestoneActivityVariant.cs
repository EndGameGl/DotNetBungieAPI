using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.ActivityModes;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyPublicMilestoneActivityVariant
    {
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        [JsonPropertyName("activityModeHash")]
        public DefinitionHashPointer<DestinyActivityModeDefinition> ActivityMode { get; init; } = DefinitionHashPointer<DestinyActivityModeDefinition>.Empty;
        [JsonPropertyName("activityModeType")]
        public DestinyActivityModeType? ActivityModeType { get; init; }
    }
}
