using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Authorization
{
    /// <summary>
    /// Data contract to OAuth2 flow token.
    /// </summary>
    public sealed record AuthorizationTokenData
    {
        /// <summary>
        /// User access token
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; init; }

        /// <summary>
        /// Token type: always Bearer in this case
        /// </summary>
        [JsonPropertyName("token_type")]
        public string TokenType { get; init; }

        /// <summary>
        /// Seconds until token expiration
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; init; }

        /// <summary>
        /// Refresh token
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; init; }

        /// <summary>
        /// Seconds until refresh token expires
        /// </summary>
        [JsonPropertyName("refresh_expires_in")]
        public int RefreshExpiresIn { get; init; }

        /// <summary>
        /// Bungie.net membership id
        /// </summary>
        [JsonPropertyName("membership_id")]
        public long MembershipId { get; init; }

        /// <summary>
        /// When this token was received
        /// </summary>
        public DateTime ReceiveTime { get; init; } = DateTime.Now;
    }
}
