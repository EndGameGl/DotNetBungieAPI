namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupBan
{
    [JsonPropertyName("groupId")]
    public long? GroupId { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public User.UserInfoCard? LastModifiedBy { get; set; }

    [JsonPropertyName("createdBy")]
    public User.UserInfoCard? CreatedBy { get; set; }

    [JsonPropertyName("dateBanned")]
    public DateTime? DateBanned { get; set; }

    [JsonPropertyName("dateExpires")]
    public DateTime? DateExpires { get; set; }

    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard? BungieNetUserInfo { get; set; }

    [JsonPropertyName("destinyUserInfo")]
    public GroupsV2.GroupUserInfoCard? DestinyUserInfo { get; set; }
}
