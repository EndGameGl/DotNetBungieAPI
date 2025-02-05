namespace DotNetBungieAPI.Models.GroupsV2;

public sealed record GroupV2
{
    [JsonPropertyName("groupId")]
    public long GroupId { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("groupType")]
    public GroupType GroupType { get; init; }

    [JsonPropertyName("membershipIdCreated")]
    public long MembershipIdCreated { get; init; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; init; }

    [JsonPropertyName("modificationDate")]
    public DateTime ModificationDate { get; init; }

    [JsonPropertyName("about")]
    public string About { get; init; }

    [JsonPropertyName("tags")]
    public ReadOnlyCollection<string> Tags { get; init; } = ReadOnlyCollection<string>.Empty;

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
    public ChatSecuritySetting ChatSecurity { get; init; }

    [JsonPropertyName("locale")]
    public string Locale { get; init; }

    [JsonPropertyName("avatarImageIndex")]
    public int AvatarImageIndex { get; init; }

    [JsonPropertyName("homepage")]
    public GroupHomepage Homepage { get; init; }

    [JsonPropertyName("membershipOption")]
    public MembershipOption MembershipOption { get; init; }

    [JsonPropertyName("defaultPublicity")]
    public GroupPostPublicity DefaultPublicity { get; init; }

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
    public GroupFeatures Features { get; init; }

    [JsonPropertyName("remoteGroupId")]
    public long? RemoteGroupId { get; init; }

    [JsonPropertyName("clanInfo")]
    public GroupV2ClanInfoAndInvestment ClanInfo { get; init; }
}
