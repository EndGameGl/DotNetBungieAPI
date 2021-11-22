using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries
{
    public class GroupEditAction
    {
        [JsonPropertyName("name")] public string Name { get; init; } = null;

        [JsonPropertyName("about")] public string About { get; init; } = null;

        [JsonPropertyName("motto")] public string Motto { get; init; } = null;

        [JsonPropertyName("theme")] public string Theme { get; init; } = null;

        [JsonPropertyName("avatarImageIndex")] public int? AvatarImageIndex { get; init; } = null;

        [JsonPropertyName("tags")] public string Tags { get; init; } = null;

        [JsonPropertyName("membershipOption")] public MembershipOption? MembershipOption { get; init; } = null;

        [JsonPropertyName("isPublicTopicAdminOnly")]
        public bool? IsPublicTopicAdminOnly { get; init; } = null;

        [JsonPropertyName("allowChat")] public bool? AllowChat { get; init; } = null;

        [JsonPropertyName("chatSecurity")] public ChatSecuritySetting? ChatSecurity { get; init; } = null;

        [JsonPropertyName("callsign")] public string Callsign { get; init; } = null;

        [JsonPropertyName("locale")] public string Locale { get; init; } = null;

        [JsonPropertyName("homepage")] public GroupHomepage? Homepage { get; init; } = null;

        [JsonPropertyName("enableInvitationMessagingForAdmins")]
        public bool? EnableInvitationMessagingForAdmins { get; init; } = null;

        [JsonPropertyName("defaultPublicity")] public GroupPostPublicity? DefaultPublicity { get; init; } = null;
    }
}