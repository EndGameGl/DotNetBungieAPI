using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupResponse
{

    [JsonPropertyName("detail")]
    public GroupsV2.GroupV2 Detail { get; init; }

    [JsonPropertyName("founder")]
    public GroupsV2.GroupMember Founder { get; init; }

    [JsonPropertyName("alliedIds")]
    public List<long> AlliedIds { get; init; }

    [JsonPropertyName("parentGroup")]
    public GroupsV2.GroupV2 ParentGroup { get; init; }

    [JsonPropertyName("allianceStatus")]
    public GroupsV2.GroupAllianceStatus AllianceStatus { get; init; }

    [JsonPropertyName("groupJoinInviteCount")]
    public int GroupJoinInviteCount { get; init; }

    [JsonPropertyName("currentUserMembershipsInactiveForDestiny")]
    public bool CurrentUserMembershipsInactiveForDestiny { get; init; }

    [JsonPropertyName("currentUserMemberMap")]
    public Dictionary<BungieMembershipType, GroupsV2.GroupMember> CurrentUserMemberMap { get; init; }

    [JsonPropertyName("currentUserPotentialMemberMap")]
    public Dictionary<BungieMembershipType, GroupsV2.GroupPotentialMember> CurrentUserPotentialMemberMap { get; init; }
}
