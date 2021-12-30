using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupV2
{

    [JsonPropertyName("groupId")]
    public long GroupId { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("groupType")]
    public GroupsV2.GroupType GroupType { get; init; }

    [JsonPropertyName("membershipIdCreated")]
    public long MembershipIdCreated { get; init; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; init; }

    [JsonPropertyName("modificationDate")]
    public DateTime ModificationDate { get; init; }

    [JsonPropertyName("about")]
    public string About { get; init; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; init; }

    [JsonPropertyName("memberCount")]
    public int MemberCount { get; init; }

    [JsonPropertyName("isPublic")]
    public bool IsPublic { get; init; }

    [JsonPropertyName("isPublicTopicAdminOnly")]
    public bool IsPublicTopicAdminOnly { get; init; }

    [JsonPropertyName("motto")]
    public string Motto { get; init; }

    [JsonPropertyName("allowChat")]
    public bool AllowChat { get; init; }

    [JsonPropertyName("isDefaultPostPublic")]
    public bool IsDefaultPostPublic { get; init; }

    [JsonPropertyName("chatSecurity")]
    public GroupsV2.ChatSecuritySetting ChatSecurity { get; init; }

    [JsonPropertyName("locale")]
    public string Locale { get; init; }

    [JsonPropertyName("avatarImageIndex")]
    public int AvatarImageIndex { get; init; }

    [JsonPropertyName("homepage")]
    public GroupsV2.GroupHomepage Homepage { get; init; }

    [JsonPropertyName("membershipOption")]
    public GroupsV2.MembershipOption MembershipOption { get; init; }

    [JsonPropertyName("defaultPublicity")]
    public GroupsV2.GroupPostPublicity DefaultPublicity { get; init; }

    [JsonPropertyName("theme")]
    public string Theme { get; init; }

    [JsonPropertyName("bannerPath")]
    public string BannerPath { get; init; }

    [JsonPropertyName("avatarPath")]
    public string AvatarPath { get; init; }

    [JsonPropertyName("conversationId")]
    public long ConversationId { get; init; }

    [JsonPropertyName("enableInvitationMessagingForAdmins")]
    public bool EnableInvitationMessagingForAdmins { get; init; }

    [JsonPropertyName("banExpireDate")]
    public DateTime? BanExpireDate { get; init; }

    [JsonPropertyName("features")]
    public GroupsV2.GroupFeatures Features { get; init; }

    [JsonPropertyName("clanInfo")]
    public GroupsV2.GroupV2ClanInfoAndInvestment ClanInfo { get; init; }
}
