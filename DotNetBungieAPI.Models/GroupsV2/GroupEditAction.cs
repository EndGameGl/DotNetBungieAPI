namespace DotNetBungieAPI.Models.GroupsV2;

public sealed class GroupEditAction
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("about")]
    public string About { get; init; }

    [JsonPropertyName("motto")]
    public string Motto { get; init; }

    [JsonPropertyName("theme")]
    public string Theme { get; init; }

    [JsonPropertyName("avatarImageIndex")]
    public int? AvatarImageIndex { get; init; }

    [JsonPropertyName("tags")]
    public string Tags { get; init; }

    [JsonPropertyName("isPublic")]
    public bool? IsPublic { get; init; }

    [JsonPropertyName("membershipOption")]
    public GroupsV2.MembershipOption? MembershipOption { get; init; }

    [JsonPropertyName("isPublicTopicAdminOnly")]
    public bool? IsPublicTopicAdminOnly { get; init; }

    [JsonPropertyName("allowChat")]
    public bool? AllowChat { get; init; }

    [JsonPropertyName("chatSecurity")]
    public GroupsV2.ChatSecuritySetting? ChatSecurity { get; init; }

    [JsonPropertyName("callsign")]
    public string Callsign { get; init; }

    [JsonPropertyName("locale")]
    public string Locale { get; init; }

    [JsonPropertyName("homepage")]
    public GroupsV2.GroupHomepage? Homepage { get; init; }

    [JsonPropertyName("enableInvitationMessagingForAdmins")]
    public bool? EnableInvitationMessagingForAdmins { get; init; }

    [JsonPropertyName("defaultPublicity")]
    public GroupsV2.GroupPostPublicity? DefaultPublicity { get; init; }
}
