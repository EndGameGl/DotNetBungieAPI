using NetBungieAPI.Destiny.Responses;
using NetBungieAPI.Models.Destiny.Definitions.Activities;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Trending
{
    public sealed record TrendingEntryDestinyActivity
    {
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; }

        [JsonPropertyName("status")]
        public DestinyPublicActivityStatus Status { get; init; }
    }
}
