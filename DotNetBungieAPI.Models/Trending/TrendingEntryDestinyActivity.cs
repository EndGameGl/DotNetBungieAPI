using DotNetBungieAPI.Models.Destiny.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.Activities;

namespace DotNetBungieAPI.Models.Trending;

public sealed record TrendingEntryDestinyActivity
{
    [JsonPropertyName("activityHash")]
    public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; }

    [JsonPropertyName("status")]
    public DestinyPublicActivityStatus Status { get; init; }
}
