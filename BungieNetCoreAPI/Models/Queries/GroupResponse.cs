using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.GroupsV2
{
    public sealed record GroupResponse
    {
        [JsonPropertyName("detail")]
        public GroupV2 Detail { get; init; }

        [JsonPropertyName("founder")]
        public GroupMember Founder { get; init; }

        [JsonPropertyName("alliedIds")]
        public ReadOnlyCollection<long> AlliedIds { get; init; } = Defaults.EmptyReadOnlyCollection<long>();

        [JsonPropertyName("parentGroup")]
        public GroupV2 ParentGroup { get; init; }

        [JsonPropertyName("allianceStatus")]
        public GroupAllianceStatus AllianceStatus { get; init; }

        [JsonPropertyName("groupJoinInviteCount")]
        public int GroupJoinInviteCount { get; init; }

        [JsonPropertyName("currentUserMembershipsInactiveForDestiny")]
        public bool CurrentUserMembershipsInactiveForDestiny { get; init; }

        [JsonPropertyName("currentUserMemberMap")]
        public ReadOnlyDictionary<int, GroupMember> CurrentUserMemberMap { get; init; } = Defaults.EmptyReadOnlyDictionary<int, GroupMember>();

        [JsonPropertyName("currentUserPotentialMemberMap")]
        public ReadOnlyDictionary<int, GroupPotentialMember> CurrentUserPotentialMemberMap { get; init; } = Defaults.EmptyReadOnlyDictionary<int, GroupPotentialMember>();
    }
}
