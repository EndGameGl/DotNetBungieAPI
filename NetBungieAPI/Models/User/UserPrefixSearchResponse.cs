﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public sealed record UserPrefixSearchResponse
    {
        [JsonPropertyName("searchResults")]
        public ReadOnlyCollection<UserPrefixSearchResultEntry> SearchResults { get; init; } =
            Defaults.EmptyReadOnlyCollection<UserPrefixSearchResultEntry>();

        [JsonPropertyName("page")] public int Page { get; init; }

        [JsonPropertyName("hasMore")] public bool HasMore { get; init; }
    }
}