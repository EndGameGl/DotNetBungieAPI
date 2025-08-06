namespace DotNetBungieAPI.Models.GroupsV2;

public sealed class GroupBan
{
    [JsonPropertyName("groupId")]
    public long GroupId { get; init; }

    [JsonPropertyName("lastModifiedBy")]
    public User.UserInfoCard? LastModifiedBy { get; init; }

    [JsonPropertyName("createdBy")]
    public User.UserInfoCard? CreatedBy { get; init; }

    [JsonPropertyName("dateBanned")]
    public DateTime DateBanned { get; init; }

    [JsonPropertyName("dateExpires")]
    public DateTime DateExpires { get; init; }

    [JsonPropertyName("comment")]
    public string Comment { get; init; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard? BungieNetUserInfo { get; init; }

    [JsonPropertyName("destinyUserInfo")]
    public GroupsV2.GroupUserInfoCard? DestinyUserInfo { get; init; }
}
