﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record GroupSearchResponse : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<GroupV2Card> Results { get; init; } = Defaults.EmptyReadOnlyCollection<GroupV2Card>();
    }
}