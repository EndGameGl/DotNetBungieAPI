using System;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.User;

namespace NetBungieAPI.Models.GroupsV2
{
    public record GroupUserBase
    {
        [JsonPropertyName("groupId")] public long GroupId { get; init; }

        [JsonPropertyName("destinyUserInfo")] public GroupUserInfoCard DestinyUserInfo { get; init; }

        [JsonPropertyName("bungieNetUserInfo")]
        public UserInfoCard BungieNetUserInfo { get; init; }

        [JsonPropertyName("joinDate")] public DateTime JoinDate { get; init; }
    }
}