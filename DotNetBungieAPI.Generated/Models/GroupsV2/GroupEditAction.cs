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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupEditAction? other)
    {
        if (other is null) return;
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (About != other.About)
        {
            About = other.About;
            OnPropertyChanged(nameof(About));
        }
        if (Motto != other.Motto)
        {
            Motto = other.Motto;
            OnPropertyChanged(nameof(Motto));
        }
        if (Theme != other.Theme)
        {
            Theme = other.Theme;
            OnPropertyChanged(nameof(Theme));
        }
        if (AvatarImageIndex != other.AvatarImageIndex)
        {
            AvatarImageIndex = other.AvatarImageIndex;
            OnPropertyChanged(nameof(AvatarImageIndex));
        }
        if (Tags != other.Tags)
        {
            Tags = other.Tags;
            OnPropertyChanged(nameof(Tags));
        }
        if (IsPublic != other.IsPublic)
        {
            IsPublic = other.IsPublic;
            OnPropertyChanged(nameof(IsPublic));
        }
        if (MembershipOption != other.MembershipOption)
        {
            MembershipOption = other.MembershipOption;
            OnPropertyChanged(nameof(MembershipOption));
        }
        if (IsPublicTopicAdminOnly != other.IsPublicTopicAdminOnly)
        {
            IsPublicTopicAdminOnly = other.IsPublicTopicAdminOnly;
            OnPropertyChanged(nameof(IsPublicTopicAdminOnly));
        }
        if (AllowChat != other.AllowChat)
        {
            AllowChat = other.AllowChat;
            OnPropertyChanged(nameof(AllowChat));
        }
        if (ChatSecurity != other.ChatSecurity)
        {
            ChatSecurity = other.ChatSecurity;
            OnPropertyChanged(nameof(ChatSecurity));
        }
        if (Callsign != other.Callsign)
        {
            Callsign = other.Callsign;
            OnPropertyChanged(nameof(Callsign));
        }
        if (Locale != other.Locale)
        {
            Locale = other.Locale;
            OnPropertyChanged(nameof(Locale));
        }
        if (Homepage != other.Homepage)
        {
            Homepage = other.Homepage;
            OnPropertyChanged(nameof(Homepage));
        }
        if (EnableInvitationMessagingForAdmins != other.EnableInvitationMessagingForAdmins)
        {
            EnableInvitationMessagingForAdmins = other.EnableInvitationMessagingForAdmins;
            OnPropertyChanged(nameof(EnableInvitationMessagingForAdmins));
        }
        if (DefaultPublicity != other.DefaultPublicity)
        {
            DefaultPublicity = other.DefaultPublicity;
            OnPropertyChanged(nameof(DefaultPublicity));
        }
    }
}