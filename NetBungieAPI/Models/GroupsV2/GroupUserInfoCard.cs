using NetBungieAPI.Models.User;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.GroupsV2
{
    public sealed record GroupUserInfoCard : UserInfoCard
    {
        /// <summary>
        /// This will be the display name the clan server last saw the user as. If the account is an active cross save override, this will be the display name to use. Otherwise, this will match the displayName property.
        /// </summary>
        [JsonPropertyName("LastSeenDisplayName")]
        public string LastSeenDisplayName { get; init; }

        /// <summary>
        /// The platform of the LastSeenDisplayName
        /// </summary>
        [JsonPropertyName("LastSeenDisplayNameType")]
        public BungieMembershipType LastSeenDisplayNameType { get; init; }
    }
}
