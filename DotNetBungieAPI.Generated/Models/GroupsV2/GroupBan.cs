namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupBan : IDeepEquatable<GroupBan>
{
    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public User.UserInfoCard LastModifiedBy { get; set; }

    [JsonPropertyName("createdBy")]
    public User.UserInfoCard CreatedBy { get; set; }

    [JsonPropertyName("dateBanned")]
    public DateTime DateBanned { get; set; }

    [JsonPropertyName("dateExpires")]
    public DateTime DateExpires { get; set; }

    [JsonPropertyName("comment")]
    public string Comment { get; set; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard BungieNetUserInfo { get; set; }

    [JsonPropertyName("destinyUserInfo")]
    public GroupsV2.GroupUserInfoCard DestinyUserInfo { get; set; }

    public bool DeepEquals(GroupBan? other)
    {
        return other is not null &&
               GroupId == other.GroupId &&
               (LastModifiedBy is not null ? LastModifiedBy.DeepEquals(other.LastModifiedBy) : other.LastModifiedBy is null) &&
               (CreatedBy is not null ? CreatedBy.DeepEquals(other.CreatedBy) : other.CreatedBy is null) &&
               DateBanned == other.DateBanned &&
               DateExpires == other.DateExpires &&
               Comment == other.Comment &&
               (BungieNetUserInfo is not null ? BungieNetUserInfo.DeepEquals(other.BungieNetUserInfo) : other.BungieNetUserInfo is null) &&
               (DestinyUserInfo is not null ? DestinyUserInfo.DeepEquals(other.DestinyUserInfo) : other.DestinyUserInfo is null);
    }
}