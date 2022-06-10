namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupResponse
{
    [JsonPropertyName("detail")]
    public GroupsV2.GroupV2? Detail { get; set; }

    [JsonPropertyName("founder")]
    public GroupsV2.GroupMember? Founder { get; set; }

    [JsonPropertyName("alliedIds")]
    public List<long> AlliedIds { get; set; }

    [JsonPropertyName("parentGroup")]
    public GroupsV2.GroupV2? ParentGroup { get; set; }

    [JsonPropertyName("allianceStatus")]
    public GroupsV2.GroupAllianceStatus? AllianceStatus { get; set; }

    [JsonPropertyName("groupJoinInviteCount")]
    public int? GroupJoinInviteCount { get; set; }

    /// <summary>
    ///     A convenience property that indicates if every membership you (the current user) have that is a part of this group are part of an account that is considered inactive - for example, overridden accounts in Cross Save.
    /// </summary>
    [JsonPropertyName("currentUserMembershipsInactiveForDestiny")]
    public bool? CurrentUserMembershipsInactiveForDestiny { get; set; }

    /// <summary>
    ///     This property will be populated if the authenticated user is a member of the group. Note that because of account linking, a user can sometimes be part of a clan more than once. As such, this returns the highest member type available.
    /// </summary>
    [JsonPropertyName("currentUserMemberMap")]
    public Dictionary<BungieMembershipType, GroupsV2.GroupMember> CurrentUserMemberMap { get; set; }

    /// <summary>
    ///     This property will be populated if the authenticated user is an applicant or has an outstanding invitation to join. Note that because of account linking, a user can sometimes be part of a clan more than once.
    /// </summary>
    [JsonPropertyName("currentUserPotentialMemberMap")]
    public Dictionary<BungieMembershipType, GroupsV2.GroupPotentialMember> CurrentUserPotentialMemberMap { get; set; }
}
