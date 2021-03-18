using NetBungieAPI.User;
using Newtonsoft.Json;
using System;

namespace NetBungieAPI.GroupsV2
{
    public class GroupMember
    {
        public RuntimeGroupMemberType MemberType { get; }
        public bool IsOnline { get; }
        public long LastOnlineStatusChange { get; }
        public long GroupId { get; }
        public GroupUserInfoCard DestinyUserInfo { get; }
        public UserInfoCard BungieNetUserInfo { get; }
        public DateTime JoinDate { get; }

        [JsonConstructor]
        internal GroupMember(RuntimeGroupMemberType memberType, bool isOnline, long lastOnlineStatusChange, long groupId, GroupUserInfoCard destinyUserInfo,
            UserInfoCard bungieNetUserInfo, DateTime joinDate)
        {
            MemberType = memberType;
            IsOnline = isOnline;
            LastOnlineStatusChange = lastOnlineStatusChange;
            GroupId = groupId;
            DestinyUserInfo = destinyUserInfo;
            BungieNetUserInfo = bungieNetUserInfo;
            JoinDate = joinDate;
        }
    }
}
