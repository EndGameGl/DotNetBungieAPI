using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Authrorization
{
    public sealed record AuthorizationTokenData
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; init; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; init; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; init; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; init; }

        [JsonPropertyName("refresh_expires_in")]
        public int RefreshExpiresIn { get; init; }

        [JsonPropertyName("membership_id")]
        public long MembershipId { get; init; }

        public DateTime ReceiveTime { get; init; } = DateTime.Now;
    }
}
