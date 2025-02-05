﻿namespace DotNetBungieAPI.Models.GroupsV2;

public sealed record GroupResponse
{
    [JsonPropertyName("detail")]
    public GroupV2 Detail { get; init; }

    [JsonPropertyName("founder")]
    public GroupMember Founder { get; init; }

    [JsonPropertyName("alliedIds")]
    public ReadOnlyCollection<long> AlliedIds { get; init; } = ReadOnlyCollection<long>.Empty;

    [JsonPropertyName("parentGroup")]
    public GroupV2 ParentGroup { get; init; }

    [JsonPropertyName("allianceStatus")]
    public GroupAllianceStatus AllianceStatus { get; init; }

    [JsonPropertyName("groupJoinInviteCount")]
    public int GroupJoinInviteCount { get; init; }

    /// <summary>
    ///     A convenience property that indicates if every membership you (the current user) have that is a part of this group
    ///     are part of an account that is considered inactive - for example, overridden accounts in Cross Save.
    /// </summary>
    [JsonPropertyName("currentUserMembershipsInactiveForDestiny")]
    public bool CurrentUserMembershipsInactiveForDestiny { get; init; }

    /// <summary>
    ///     This property will be populated if the authenticated user is a member of the group. Note that because of account
    ///     linking, a user can sometimes be part of a clan more than once. As such, this returns the highest member type
    ///     available.
    /// </summary>
    [JsonPropertyName("currentUserMemberMap")]
    public ReadOnlyDictionary<int, GroupMember> CurrentUserMemberMap { get; init; } =
        ReadOnlyDictionary<int, GroupMember>.Empty;

    /// <summary>
    ///     This property will be populated if the authenticated user is an applicant or has an outstanding invitation to join.
    ///     Note that because of account linking, a user can sometimes be part of a clan more than once.
    /// </summary>
    [JsonPropertyName("currentUserPotentialMemberMap")]
    public ReadOnlyDictionary<
        int,
        GroupPotentialMember
    > CurrentUserPotentialMemberMap { get; init; } =
        ReadOnlyDictionary<int, GroupPotentialMember>.Empty;
}
