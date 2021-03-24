using Newtonsoft.Json;
using System;

namespace NetBungieAPI.GroupsV2
{
    public class GroupV2Card
    {
        public long GroupId { get; }
        public string Name { get; }
        public GroupType GroupType { get; }
        public DateTime CreationDate { get; }
        public string About { get; }
        public string Motto { get; }
        public int MemberCount { get; }
        public string Locale { get; }
        public MembershipOption MembershipOption { get; }
        public Capabilities Capabilities { get; }
        public GroupV2ClanInfo ClanInfo { get; }
        public string AvatarPath { get; }
        public string Theme { get; }

        [JsonConstructor]
        internal GroupV2Card(long groupId, string name, GroupType groupType, DateTime creationDate,  string about, int memberCount, string motto, 
            string locale, MembershipOption membershipOption, string theme, string avatarPath, GroupV2ClanInfo clanInfo, Capabilities capabilities)
        {
            GroupId = groupId;
            Name = name;
            GroupType = groupType;
            CreationDate = creationDate;
            About = about;
            MemberCount = memberCount;
            Motto = motto;
            Locale = locale;
            MembershipOption = membershipOption;
            Theme = theme;
            AvatarPath = avatarPath;
            ClanInfo = clanInfo;
            Capabilities = capabilities;
        }
    }
}
