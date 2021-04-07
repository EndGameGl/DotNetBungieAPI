using NetBungieAPI.Models.User;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.GroupsV2
{
    public sealed record GroupUserInfoCard : UserInfoCard
    {
        [JsonPropertyName("LastSeenDisplayName")]
        public string LastSeenDisplayName { get; init; }

        [JsonPropertyName("LastSeenDisplayNameType")]
        public int LastSeenDisplayNameType { get; init; }
    }
}
