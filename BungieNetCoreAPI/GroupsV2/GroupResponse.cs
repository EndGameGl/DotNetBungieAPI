using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.GroupsV2
{
    public class GroupResponse
    {
        public GroupV2 Detail { get; }
        public GroupMember Founder { get; }
        public ReadOnlyCollection<long> AlliedIds { get; }
        public GroupV2 ParentGroup { get; }
        public GroupAllianceStatus AllianceStatus { get; }
        public int GroupJoinInviteCount { get; }
        public bool CurrentUserMembershipsInactiveForDestiny { get; }
        public ReadOnlyDictionary<int, GroupMember> CurrentUserMemberMap { get; }
        public ReadOnlyDictionary<int, GroupPotentialMember> CurrentUserPotentialMemberMap { get; }

        [JsonConstructor]
        internal GroupResponse(GroupV2 detail, GroupMember founder, long[] alliedIds, GroupV2 parentGroup, GroupAllianceStatus allianceStatus,
            int groupJoinInviteCount, bool currentUserMembershipsInactiveForDestiny, Dictionary<int, GroupMember> currentUserMemberMap,
            Dictionary<int, GroupPotentialMember> currentUserPotentialMemberMap)
        {
            Detail = detail;
            Founder = founder;
            AlliedIds = alliedIds.AsReadOnlyOrEmpty();
            ParentGroup = parentGroup;
            AllianceStatus = allianceStatus;
            GroupJoinInviteCount = groupJoinInviteCount;
            CurrentUserMembershipsInactiveForDestiny = currentUserMembershipsInactiveForDestiny;
            CurrentUserMemberMap = currentUserMemberMap.AsReadOnlyDictionaryOrEmpty();
            CurrentUserPotentialMemberMap = currentUserPotentialMemberMap.AsReadOnlyDictionaryOrEmpty();
        }
    }
}
