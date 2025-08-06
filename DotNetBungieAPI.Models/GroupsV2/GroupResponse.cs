namespace DotNetBungieAPI.Models.GroupsV2;

public sealed class GroupResponse
{
    [JsonPropertyName("detail")]
    public GroupsV2.GroupV2? Detail { get; init; }

    [JsonPropertyName("founder")]
    public GroupsV2.GroupMember? Founder { get; init; }

    [JsonPropertyName("alliedIds")]
    public long[]? AlliedIds { get; init; }

    [JsonPropertyName("parentGroup")]
    public GroupsV2.GroupV2? ParentGroup { get; init; }

    [JsonPropertyName("allianceStatus")]
    public GroupsV2.GroupAllianceStatus AllianceStatus { get; init; }

    [JsonPropertyName("groupJoinInviteCount")]
    public int GroupJoinInviteCount { get; init; }

    /// <summary>
    ///     A convenience property that indicates if every membership you (the current user) have that is a part of this group are part of an account that is considered inactive - for example, overridden accounts in Cross Save.
    /// </summary>
    [JsonPropertyName("currentUserMembershipsInactiveForDestiny")]
    public bool CurrentUserMembershipsInactiveForDestiny { get; init; }

    /// <summary>
    ///     This property will be populated if the authenticated user is a member of the group. Note that because of account linking, a user can sometimes be part of a clan more than once. As such, this returns the highest member type available.
    /// </summary>
    [JsonPropertyName("currentUserMemberMap")]
    public Dictionary<BungieMembershipType, GroupsV2.GroupMember>? CurrentUserMemberMap { get; init; }

    /// <summary>
    ///     This property will be populated if the authenticated user is an applicant or has an outstanding invitation to join. Note that because of account linking, a user can sometimes be part of a clan more than once.
    /// </summary>
    [JsonPropertyName("currentUserPotentialMemberMap")]
    public Dictionary<BungieMembershipType, GroupsV2.GroupPotentialMember>? CurrentUserPotentialMemberMap { get; init; }
}
