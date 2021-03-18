using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieAPI.GroupsV2
{
    public class GroupV2
    {
        public long GroupId { get; }
        public string Name { get; }
        public GroupType GroupType { get; }
        public long MembershipIdCreated { get; }
        public DateTime CreationDate { get; }
        public DateTime ModificationDate { get; }
        public string About { get; }
        public ReadOnlyCollection<string> Tags { get; }
        public int MemberCount { get; }
        public bool IsPublic { get; }
        public bool IsPublicTopicAdminOnly { get; }
        public string Motto { get; }
        public bool AllowChat { get; }
        public bool IsDefaultPostPublic { get; }
        public ChatSecuritySetting ChatSecurity { get; }
        public string Locale { get; }
        public int AvatarImageIndex { get; }
        public GroupHomepage Homepage { get; }
        public MembershipOption MembershipOption { get; }
        public GroupPostPublicity DefaultPublicity { get; }
        public string Theme { get; }
        public string BannerPath { get; }
        public string AvatarPath { get; }
        public long ConversationId { get; }
        public bool EnableInvitationMessagingForAdmins { get; }
        public DateTime? BanExpireDate { get; }
        public GroupFeatures Features { get; }
        public GroupV2ClanInfoAndInvestment ClanInfo { get; }

        [JsonConstructor]
        internal GroupV2(long groupId, string name, GroupType groupType, long membershipIdCreated, DateTime creationDate, DateTime modificationDate,
            string about, string[] tags, int memberCount, bool isPublic, bool isPublicTopicAdminOnly, string motto, bool allowChat, bool isDefaultPostPublic,
            ChatSecuritySetting chatSecurity, string locale, int avatarImageIndex, GroupHomepage homepage, MembershipOption membershipOption,
            GroupPostPublicity defaultPublicity, string theme, string bannerPath, string avatarPath, long conversationId, bool enableInvitationMessagingForAdmins,
            DateTime? banExpireDate, GroupFeatures features, GroupV2ClanInfoAndInvestment clanInfo)
        {
            GroupId = groupId;
            Name = name;
            GroupType = groupType;
            MembershipIdCreated = membershipIdCreated;
            CreationDate = creationDate;
            ModificationDate = modificationDate;
            About = about;
            Tags = tags.AsReadOnlyOrEmpty();
            MemberCount = memberCount;
            IsPublic = isPublic;
            IsPublicTopicAdminOnly = isPublicTopicAdminOnly;
            Motto = motto;
            AllowChat = allowChat;
            IsDefaultPostPublic = isDefaultPostPublic;
            ChatSecurity = chatSecurity;
            Locale = locale;
            AvatarImageIndex = avatarImageIndex;
            Homepage = homepage;
            MembershipOption = membershipOption;
            DefaultPublicity = defaultPublicity;
            Theme = theme;
            BannerPath = bannerPath;
            AvatarPath = avatarPath;
            ConversationId = conversationId;
            EnableInvitationMessagingForAdmins = enableInvitationMessagingForAdmins;
            BanExpireDate = banExpireDate;
            Features = features;
            ClanInfo = clanInfo;
        }
    }
}
