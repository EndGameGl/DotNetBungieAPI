namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupV2 : IDeepEquatable<GroupV2>
{
    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("groupType")]
    public GroupsV2.GroupType GroupType { get; set; }

    [JsonPropertyName("membershipIdCreated")]
    public long MembershipIdCreated { get; set; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; set; }

    [JsonPropertyName("modificationDate")]
    public DateTime ModificationDate { get; set; }

    [JsonPropertyName("about")]
    public string About { get; set; }

    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    [JsonPropertyName("memberCount")]
    public int MemberCount { get; set; }

    [JsonPropertyName("isPublic")]
    public bool IsPublic { get; set; }

    [JsonPropertyName("isPublicTopicAdminOnly")]
    public bool IsPublicTopicAdminOnly { get; set; }

    [JsonPropertyName("motto")]
    public string Motto { get; set; }

    [JsonPropertyName("allowChat")]
    public bool AllowChat { get; set; }

    [JsonPropertyName("isDefaultPostPublic")]
    public bool IsDefaultPostPublic { get; set; }

    [JsonPropertyName("chatSecurity")]
    public GroupsV2.ChatSecuritySetting ChatSecurity { get; set; }

    [JsonPropertyName("locale")]
    public string Locale { get; set; }

    [JsonPropertyName("avatarImageIndex")]
    public int AvatarImageIndex { get; set; }

    [JsonPropertyName("homepage")]
    public GroupsV2.GroupHomepage Homepage { get; set; }

    [JsonPropertyName("membershipOption")]
    public GroupsV2.MembershipOption MembershipOption { get; set; }

    [JsonPropertyName("defaultPublicity")]
    public GroupsV2.GroupPostPublicity DefaultPublicity { get; set; }

    [JsonPropertyName("theme")]
    public string Theme { get; set; }

    [JsonPropertyName("bannerPath")]
    public string BannerPath { get; set; }

    [JsonPropertyName("avatarPath")]
    public string AvatarPath { get; set; }

    [JsonPropertyName("conversationId")]
    public long ConversationId { get; set; }

    [JsonPropertyName("enableInvitationMessagingForAdmins")]
    public bool EnableInvitationMessagingForAdmins { get; set; }

    [JsonPropertyName("banExpireDate")]
    public DateTime? BanExpireDate { get; set; }

    [JsonPropertyName("features")]
    public GroupsV2.GroupFeatures Features { get; set; }

    [JsonPropertyName("clanInfo")]
    public GroupsV2.GroupV2ClanInfoAndInvestment ClanInfo { get; set; }

    public bool DeepEquals(GroupV2? other)
    {
        return other is not null &&
               GroupId == other.GroupId &&
               Name == other.Name &&
               GroupType == other.GroupType &&
               MembershipIdCreated == other.MembershipIdCreated &&
               CreationDate == other.CreationDate &&
               ModificationDate == other.ModificationDate &&
               About == other.About &&
               Tags.DeepEqualsListNaive(other.Tags) &&
               MemberCount == other.MemberCount &&
               IsPublic == other.IsPublic &&
               IsPublicTopicAdminOnly == other.IsPublicTopicAdminOnly &&
               Motto == other.Motto &&
               AllowChat == other.AllowChat &&
               IsDefaultPostPublic == other.IsDefaultPostPublic &&
               ChatSecurity == other.ChatSecurity &&
               Locale == other.Locale &&
               AvatarImageIndex == other.AvatarImageIndex &&
               Homepage == other.Homepage &&
               MembershipOption == other.MembershipOption &&
               DefaultPublicity == other.DefaultPublicity &&
               Theme == other.Theme &&
               BannerPath == other.BannerPath &&
               AvatarPath == other.AvatarPath &&
               ConversationId == other.ConversationId &&
               EnableInvitationMessagingForAdmins == other.EnableInvitationMessagingForAdmins &&
               BanExpireDate == other.BanExpireDate &&
               (Features is not null ? Features.DeepEquals(other.Features) : other.Features is null) &&
               (ClanInfo is not null ? ClanInfo.DeepEquals(other.ClanInfo) : other.ClanInfo is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupV2? other)
    {
        if (other is null) return;
        if (GroupId != other.GroupId)
        {
            GroupId = other.GroupId;
            OnPropertyChanged(nameof(GroupId));
        }
        if (Name != other.Name)
        {
            Name = other.Name;
            OnPropertyChanged(nameof(Name));
        }
        if (GroupType != other.GroupType)
        {
            GroupType = other.GroupType;
            OnPropertyChanged(nameof(GroupType));
        }
        if (MembershipIdCreated != other.MembershipIdCreated)
        {
            MembershipIdCreated = other.MembershipIdCreated;
            OnPropertyChanged(nameof(MembershipIdCreated));
        }
        if (CreationDate != other.CreationDate)
        {
            CreationDate = other.CreationDate;
            OnPropertyChanged(nameof(CreationDate));
        }
        if (ModificationDate != other.ModificationDate)
        {
            ModificationDate = other.ModificationDate;
            OnPropertyChanged(nameof(ModificationDate));
        }
        if (About != other.About)
        {
            About = other.About;
            OnPropertyChanged(nameof(About));
        }
        if (!Tags.DeepEqualsListNaive(other.Tags))
        {
            Tags = other.Tags;
            OnPropertyChanged(nameof(Tags));
        }
        if (MemberCount != other.MemberCount)
        {
            MemberCount = other.MemberCount;
            OnPropertyChanged(nameof(MemberCount));
        }
        if (IsPublic != other.IsPublic)
        {
            IsPublic = other.IsPublic;
            OnPropertyChanged(nameof(IsPublic));
        }
        if (IsPublicTopicAdminOnly != other.IsPublicTopicAdminOnly)
        {
            IsPublicTopicAdminOnly = other.IsPublicTopicAdminOnly;
            OnPropertyChanged(nameof(IsPublicTopicAdminOnly));
        }
        if (Motto != other.Motto)
        {
            Motto = other.Motto;
            OnPropertyChanged(nameof(Motto));
        }
        if (AllowChat != other.AllowChat)
        {
            AllowChat = other.AllowChat;
            OnPropertyChanged(nameof(AllowChat));
        }
        if (IsDefaultPostPublic != other.IsDefaultPostPublic)
        {
            IsDefaultPostPublic = other.IsDefaultPostPublic;
            OnPropertyChanged(nameof(IsDefaultPostPublic));
        }
        if (ChatSecurity != other.ChatSecurity)
        {
            ChatSecurity = other.ChatSecurity;
            OnPropertyChanged(nameof(ChatSecurity));
        }
        if (Locale != other.Locale)
        {
            Locale = other.Locale;
            OnPropertyChanged(nameof(Locale));
        }
        if (AvatarImageIndex != other.AvatarImageIndex)
        {
            AvatarImageIndex = other.AvatarImageIndex;
            OnPropertyChanged(nameof(AvatarImageIndex));
        }
        if (Homepage != other.Homepage)
        {
            Homepage = other.Homepage;
            OnPropertyChanged(nameof(Homepage));
        }
        if (MembershipOption != other.MembershipOption)
        {
            MembershipOption = other.MembershipOption;
            OnPropertyChanged(nameof(MembershipOption));
        }
        if (DefaultPublicity != other.DefaultPublicity)
        {
            DefaultPublicity = other.DefaultPublicity;
            OnPropertyChanged(nameof(DefaultPublicity));
        }
        if (Theme != other.Theme)
        {
            Theme = other.Theme;
            OnPropertyChanged(nameof(Theme));
        }
        if (BannerPath != other.BannerPath)
        {
            BannerPath = other.BannerPath;
            OnPropertyChanged(nameof(BannerPath));
        }
        if (AvatarPath != other.AvatarPath)
        {
            AvatarPath = other.AvatarPath;
            OnPropertyChanged(nameof(AvatarPath));
        }
        if (ConversationId != other.ConversationId)
        {
            ConversationId = other.ConversationId;
            OnPropertyChanged(nameof(ConversationId));
        }
        if (EnableInvitationMessagingForAdmins != other.EnableInvitationMessagingForAdmins)
        {
            EnableInvitationMessagingForAdmins = other.EnableInvitationMessagingForAdmins;
            OnPropertyChanged(nameof(EnableInvitationMessagingForAdmins));
        }
        if (BanExpireDate != other.BanExpireDate)
        {
            BanExpireDate = other.BanExpireDate;
            OnPropertyChanged(nameof(BanExpireDate));
        }
        if (!Features.DeepEquals(other.Features))
        {
            Features.Update(other.Features);
            OnPropertyChanged(nameof(Features));
        }
        if (!ClanInfo.DeepEquals(other.ClanInfo))
        {
            ClanInfo.Update(other.ClanInfo);
            OnPropertyChanged(nameof(ClanInfo));
        }
    }
}