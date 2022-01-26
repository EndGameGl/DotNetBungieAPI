namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupResponse : IDeepEquatable<GroupResponse>
{
    [JsonPropertyName("detail")]
    public GroupsV2.GroupV2 Detail { get; set; }

    [JsonPropertyName("founder")]
    public GroupsV2.GroupMember Founder { get; set; }

    [JsonPropertyName("alliedIds")]
    public List<long> AlliedIds { get; set; }

    [JsonPropertyName("parentGroup")]
    public GroupsV2.GroupV2 ParentGroup { get; set; }

    [JsonPropertyName("allianceStatus")]
    public GroupsV2.GroupAllianceStatus AllianceStatus { get; set; }

    [JsonPropertyName("groupJoinInviteCount")]
    public int GroupJoinInviteCount { get; set; }

    /// <summary>
    ///     A convenience property that indicates if every membership you (the current user) have that is a part of this group are part of an account that is considered inactive - for example, overridden accounts in Cross Save.
    /// </summary>
    [JsonPropertyName("currentUserMembershipsInactiveForDestiny")]
    public bool CurrentUserMembershipsInactiveForDestiny { get; set; }

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

    public bool DeepEquals(GroupResponse? other)
    {
        return other is not null &&
               (Detail is not null ? Detail.DeepEquals(other.Detail) : other.Detail is null) &&
               (Founder is not null ? Founder.DeepEquals(other.Founder) : other.Founder is null) &&
               AlliedIds.DeepEqualsListNaive(other.AlliedIds) &&
               (ParentGroup is not null ? ParentGroup.DeepEquals(other.ParentGroup) : other.ParentGroup is null) &&
               AllianceStatus == other.AllianceStatus &&
               GroupJoinInviteCount == other.GroupJoinInviteCount &&
               CurrentUserMembershipsInactiveForDestiny == other.CurrentUserMembershipsInactiveForDestiny &&
               CurrentUserMemberMap.DeepEqualsDictionary(other.CurrentUserMemberMap) &&
               CurrentUserPotentialMemberMap.DeepEqualsDictionary(other.CurrentUserPotentialMemberMap);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupResponse? other)
    {
        if (other is null) return;
        if (!Detail.DeepEquals(other.Detail))
        {
            Detail.Update(other.Detail);
            OnPropertyChanged(nameof(Detail));
        }
        if (!Founder.DeepEquals(other.Founder))
        {
            Founder.Update(other.Founder);
            OnPropertyChanged(nameof(Founder));
        }
        if (!AlliedIds.DeepEqualsListNaive(other.AlliedIds))
        {
            AlliedIds = other.AlliedIds;
            OnPropertyChanged(nameof(AlliedIds));
        }
        if (!ParentGroup.DeepEquals(other.ParentGroup))
        {
            ParentGroup.Update(other.ParentGroup);
            OnPropertyChanged(nameof(ParentGroup));
        }
        if (AllianceStatus != other.AllianceStatus)
        {
            AllianceStatus = other.AllianceStatus;
            OnPropertyChanged(nameof(AllianceStatus));
        }
        if (GroupJoinInviteCount != other.GroupJoinInviteCount)
        {
            GroupJoinInviteCount = other.GroupJoinInviteCount;
            OnPropertyChanged(nameof(GroupJoinInviteCount));
        }
        if (CurrentUserMembershipsInactiveForDestiny != other.CurrentUserMembershipsInactiveForDestiny)
        {
            CurrentUserMembershipsInactiveForDestiny = other.CurrentUserMembershipsInactiveForDestiny;
            OnPropertyChanged(nameof(CurrentUserMembershipsInactiveForDestiny));
        }
        if (!CurrentUserMemberMap.DeepEqualsDictionary(other.CurrentUserMemberMap))
        {
            CurrentUserMemberMap = other.CurrentUserMemberMap;
            OnPropertyChanged(nameof(CurrentUserMemberMap));
        }
        if (!CurrentUserPotentialMemberMap.DeepEqualsDictionary(other.CurrentUserPotentialMemberMap))
        {
            CurrentUserPotentialMemberMap = other.CurrentUserPotentialMemberMap;
            OnPropertyChanged(nameof(CurrentUserPotentialMemberMap));
        }
    }
}