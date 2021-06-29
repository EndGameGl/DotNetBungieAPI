using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Authorization
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
        ///     When this token was received
        /// </summary>
        public DateTime ReceiveTime { get; set; } = DateTime.Now;

        /// <summary>
        ///     Updates same token instance with new data
        /// </summary>
        /// <param name="newTokenData"></param>
        internal void Update(AuthorizationTokenData newTokenData)
        {
            AccessToken = newTokenData.AccessToken;
            ExpiresIn = newTokenData.ExpiresIn;
            MembershipId = newTokenData.MembershipId;
            ReceiveTime = newTokenData.ReceiveTime;
            RefreshToken = newTokenData.RefreshToken;
            TokenType = newTokenData.TokenType;
            RefreshExpiresIn = newTokenData.RefreshExpiresIn;
        }
    }
}