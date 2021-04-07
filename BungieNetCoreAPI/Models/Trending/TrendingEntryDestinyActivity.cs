using NetBungieAPI.Destiny.Definitions.Activities;
using NetBungieAPI.Destiny.Responses;
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
