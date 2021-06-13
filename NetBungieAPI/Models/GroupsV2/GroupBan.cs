using NetBungieAPI.Models.User;
using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.GroupsV2
{
    public sealed record GroupBan
    {
        [JsonPropertyName("groupId")]
        public long GroupId { get; init; }

        [JsonPropertyName("lastModifiedBy")]
        public UserInfoCard LastModifiedBy { get; init; }

        [JsonPropertyName("createdBy")]
        public UserInfoCard CreatedBy { get; init; }

        [JsonPropertyName("dateBanned")]
        public DateTime DateBanned { get; init; }

        [JsonPropertyName("dateExpires")]
        public DateTime DateExpires { get; init; }

        [JsonPropertyName("comment")]
        public string Comment { get; init; }

        [JsonPropertyName("bungieNetUserInfo")]
        public UserInfoCard BungieNetUserInfo { get; init; }

        [JsonPropertyName("destinyUserInfo")]
        public GroupUserInfoCard DestinyUserInfo { get; init; }
    }
}
