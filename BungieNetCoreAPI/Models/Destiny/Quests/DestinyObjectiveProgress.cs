using NetBungieAPI.Models.Destiny.Definitions.Activities;
using NetBungieAPI.Models.Destiny.Definitions.Destinations;
using NetBungieAPI.Models.Destiny.Definitions.Objectives;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Quests
{
    /// <summary>
    /// Returns data about a character's status with a given Objective. Combine with DestinyObjectiveDefinition static data for display purposes.
    /// </summary>
    public sealed record DestinyObjectiveProgress
    {
        [JsonPropertyName("objectiveHash")]
        public DefinitionHashPointer<DestinyObjectiveDefinition> Objective { get; init; } = DefinitionHashPointer<DestinyObjectiveDefinition>.Empty;
        [JsonPropertyName("destinationHash")]
        public DefinitionHashPointer<DestinyDestinationDefinition> Destination { get; init; } = DefinitionHashPointer<DestinyDestinationDefinition>.Empty;
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; } = DefinitionHashPointer<DestinyActivityDefinition>.Empty;
        /// <summary>
        /// If progress has been made, and the progress can be measured numerically, this will be the value of that progress. You can compare it to the DestinyObjectiveDefinition.completionValue property for current vs. upper bounds, and use DestinyObjectiveDefinition.valueStyle to determine how this should be rendered. Note that progress, in Destiny 2, need not be a literal numeric progression. It could be one of a number of possible values, even a Timestamp. Always examine DestinyObjectiveDefinition.valueStyle before rendering progress.
        /// </summary>
        [JsonPropertyName("progress")]
        public int? Progress { get; init; }
        [JsonPropertyName("completionValue")]
        public int CompletionValue { get; init; }
        [JsonPropertyName("complete")]
        public bool IsComplete { get; init; }
        [JsonPropertyName("visible")]
        public bool IsVisible { get; init; }
    }
}
