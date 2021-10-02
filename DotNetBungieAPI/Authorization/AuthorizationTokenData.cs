using System;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Authorization
{
    /// <summary>
    ///     Data contract to OAuth2 flow token.
    /// </summary>
    public sealed record AuthorizationTokenData
    {
        /// <summary>
        ///     User access token
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        ///     Token type: always Bearer in this case
        /// </summary>
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        ///     Seconds until token expiration
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        ///     Refresh token
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        ///     Seconds until refresh token expires
        /// </summary>
        [JsonPropertyName("refresh_expires_in")]
        public int RefreshExpiresIn { get; set; }

        /// <summary>
        ///     Bungie.net membership id
        /// </summary>
        [JsonPropertyName("membership_id")]
        public long MembershipId { get; set; }

        /// <summary>
        ///     When this token was last received
        /// </summary>
        public DateTime LastReceived { get; set; } = DateTime.UtcNow;

        /// <summary>
        ///     When this token was first received
        /// </summary>
        public DateTime FirstReceived { get; } = DateTime.UtcNow;

        /// <summary>
        ///     Whether token did expire
        /// </summary>
        public bool DidExpire => LastReceived.AddSeconds(ExpiresIn) < DateTime.UtcNow;

        /// <summary>
        ///     Whether refresh token did expire
        /// </summary>
        public bool DidRefreshExpired => FirstReceived.AddSeconds(RefreshExpiresIn) < DateTime.UtcNow;

        /// <summary>
        ///     Updates same token instance with new data
        /// </summary>
        /// <param name="newTokenData"></param>
        internal void Update(AuthorizationTokenData newTokenData)
        {
            AccessToken = newTokenData.AccessToken;
            ExpiresIn = newTokenData.ExpiresIn;
            MembershipId = newTokenData.MembershipId;
            LastReceived = newTokenData.LastReceived;
            RefreshToken = newTokenData.RefreshToken;
            TokenType = newTokenData.TokenType;
            RefreshExpiresIn = newTokenData.RefreshExpiresIn;
        }
    }
}