using NetBungieAPI.Models.Ignores;
using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public sealed record UserToUserContext
    {
        [JsonPropertyName("isFollowing")]
        public bool IsFollowing { get; }

        [JsonPropertyName("ignoreStatus")]
        public IgnoreResponse IgnoreStatus { get; }

        [JsonPropertyName("globalIgnoreEndDate")]
        public DateTime? GlobalIgnoreEndDate { get; }
    }
}
