using Newtonsoft.Json;

namespace NetBungieAPI.Authrorization
{
    public class AuthorizationTokenData
    {
        public string AccessToken { get; }
        public string TokenType { get; }
        public int ExpiresIn { get; }
        public string RefreshToken { get; }
        public int RefreshExpiresIn { get; }
        public int MembershipId { get; }

        [JsonConstructor]
        internal AuthorizationTokenData(string access_token, string token_type, int expires_in, string refresh_token, int refresh_expires_in, int membership_id)
        {
            AccessToken = access_token;
            TokenType = token_type;
            ExpiresIn = expires_in;
            RefreshToken = refresh_token;
            RefreshExpiresIn = refresh_expires_in;
            MembershipId = membership_id;
        }
    }
}
