﻿using NetBungieAPI.Models.Ignores;
using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public sealed record UserToUserContext
    {
        [JsonPropertyName("isFollowing")]
        public bool IsFollowing { get; init; }

        [JsonPropertyName("ignoreStatus")]
        public IgnoreResponse IgnoreStatus { get; init; }

        [JsonPropertyName("globalIgnoreEndDate")]
        public DateTime? GlobalIgnoreEndDate { get; init; }
    }
}