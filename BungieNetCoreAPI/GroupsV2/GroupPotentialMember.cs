using NetBungieAPI.User;
using Newtonsoft.Json;
using System;

namespace NetBungieAPI.GroupsV2
{
    public class GroupPotentialMember
    {
        public GroupPotentialMemberStatus PotentialStatus { get; }
        public long GroupId { get; }
        public GroupUserInfoCard DestinyUserInfo { get; }
        public UserInfoCard BungieNetUserInfo { get; }
        public DateTime JoinDate { get; }

        [JsonConstructor]
        internal GroupPotentialMember(GroupPotentialMemberStatus potentialStatus, long groupId, GroupUserInfoCard destinyUserInfo,
            UserInfoCard bungieNetUserInfo, DateTime joinDate)
        {
            PotentialStatus = potentialStatus;
            GroupId = groupId;
            DestinyUserInfo = destinyUserInfo;
            BungieNetUserInfo = bungieNetUserInfo;
            JoinDate = joinDate;
        }
    }
}
