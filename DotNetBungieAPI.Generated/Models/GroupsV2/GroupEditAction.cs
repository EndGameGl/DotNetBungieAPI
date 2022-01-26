namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupEditAction : IDeepEquatable<GroupEditAction>
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("about")]
    public string About { get; set; }

    [JsonPropertyName("motto")]
    public string Motto { get; set; }

    [JsonPropertyName("theme")]
    public string Theme { get; set; }

    [JsonPropertyName("avatarImageIndex")]
    public int? AvatarImageIndex { get; set; }

    [JsonPropertyName("tags")]
    public string Tags { get; set; }

    [JsonPropertyName("isPublic")]
    public bool? IsPublic { get; set; }

    [JsonPropertyName("membershipOption")]
    public int? MembershipOption { get; set; }

    [JsonPropertyName("isPublicTopicAdminOnly")]
    public bool? IsPublicTopicAdminOnly { get; set; }

    [JsonPropertyName("allowChat")]
    public bool? AllowChat { get; set; }

    [JsonPropertyName("chatSecurity")]
    public int? ChatSecurity { get; set; }

    [JsonPropertyName("callsign")]
    public string Callsign { get; set; }

    [JsonPropertyName("locale")]
    public string Locale { get; set; }

    [JsonPropertyName("homepage")]
    public int? Homepage { get; set; }

    [JsonPropertyName("enableInvitationMessagingForAdmins")]
    public bool? EnableInvitationMessagingForAdmins { get; set; }

    [JsonPropertyName("defaultPublicity")]
    public int? DefaultPublicity { get; set; }

    public bool DeepEquals(GroupEditAction? other)
    {
        return other is not null &&
               Name == other.Name &&
               About == other.About &&
               Motto == other.Motto &&
               Theme == other.Theme &&
               AvatarImageIndex == other.AvatarImageIndex &&
               Tags == other.Tags &&
               IsPublic == other.IsPublic &&
               MembershipOption == other.MembershipOption &&
               IsPublicTopicAdminOnly == other.IsPublicTopicAdminOnly &&
               AllowChat == other.AllowChat &&
               ChatSecurity == other.ChatSecurity &&
               Callsign == other.Callsign &&
               Locale == other.Locale &&
               Homepage == other.Homepage &&
               EnableInvitationMessagingForAdmins == other.EnableInvitationMessagingForAdmins &&
               DefaultPublicity == other.DefaultPublicity;
    }
}