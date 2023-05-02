namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupV2
{
    [JsonPropertyName("groupId")]
    public long? GroupId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("groupType")]
    public GroupsV2.GroupType? GroupType { get; set; }

    [JsonPropertyName("membershipIdCreated")]
    public long? MembershipIdCreated { get; set; }

    [JsonPropertyName("creationDate")]
    public DateTime? CreationDate { get; set; }

    [JsonPropertyName("modificationDate")]
    public DateTime? ModificationDate { get; set; }

    [JsonPropertyName("about")]
    public string? About { get; set; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    [JsonPropertyName("memberCount")]
    public int? MemberCount { get; set; }

    [JsonPropertyName("isPublic")]
    public bool? IsPublic { get; set; }

    [JsonPropertyName("isPublicTopicAdminOnly")]
    public bool? IsPublicTopicAdminOnly { get; set; }

    [JsonPropertyName("motto")]
    public string? Motto { get; set; }

    [JsonPropertyName("allowChat")]
    public bool? AllowChat { get; set; }

    [JsonPropertyName("isDefaultPostPublic")]
    public bool? IsDefaultPostPublic { get; set; }

    [JsonPropertyName("chatSecurity")]
    public GroupsV2.ChatSecuritySetting? ChatSecurity { get; set; }

    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    [JsonPropertyName("avatarImageIndex")]
    public int? AvatarImageIndex { get; set; }

    [JsonPropertyName("homepage")]
    public GroupsV2.GroupHomepage? Homepage { get; set; }

    [JsonPropertyName("membershipOption")]
    public GroupsV2.MembershipOption? MembershipOption { get; set; }

    [JsonPropertyName("defaultPublicity")]
    public GroupsV2.GroupPostPublicity? DefaultPublicity { get; set; }

    [JsonPropertyName("theme")]
    public string? Theme { get; set; }

    [JsonPropertyName("bannerPath")]
    public string? BannerPath { get; set; }

    [JsonPropertyName("avatarPath")]
    public string? AvatarPath { get; set; }

    [JsonPropertyName("conversationId")]
    public long? ConversationId { get; set; }

    [JsonPropertyName("enableInvitationMessagingForAdmins")]
    public bool? EnableInvitationMessagingForAdmins { get; set; }

    [JsonPropertyName("banExpireDate")]
    public DateTime? BanExpireDate { get; set; }

    [JsonPropertyName("features")]
    public GroupsV2.GroupFeatures? Features { get; set; }

    [JsonPropertyName("remoteGroupId")]
    public long? RemoteGroupId { get; set; }

    [JsonPropertyName("clanInfo")]
    public GroupsV2.GroupV2ClanInfoAndInvestment? ClanInfo { get; set; }
}
