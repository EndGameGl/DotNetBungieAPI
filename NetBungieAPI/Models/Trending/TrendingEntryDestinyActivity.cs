﻿using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Activities;
using NetBungieAPI.Models.Destiny.Definitions.Activities;

namespace NetBungieAPI.Models.Trending
{
    public sealed record TrendingEntryDestinyActivity
    {
        [JsonPropertyName("activityHash")]
        public DefinitionHashPointer<DestinyActivityDefinition> Activity { get; init; }

        [JsonPropertyName("status")] public DestinyPublicActivityStatus Status { get; init; }
    }
}