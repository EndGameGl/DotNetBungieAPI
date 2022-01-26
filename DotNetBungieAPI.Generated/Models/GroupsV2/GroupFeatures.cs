namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupFeatures : IDeepEquatable<GroupFeatures>
{
    [JsonPropertyName("maximumMembers")]
    public int MaximumMembers { get; set; }

    /// <summary>
    ///     Maximum number of groups of this type a typical membership may join. For example, a user may join about 50 General groups with their Bungie.net account. They may join one clan per Destiny membership.
    /// </summary>
    [JsonPropertyName("maximumMembershipsOfGroupType")]
    public int MaximumMembershipsOfGroupType { get; set; }

    [JsonPropertyName("capabilities")]
    public GroupsV2.Capabilities Capabilities { get; set; }

    [JsonPropertyName("membershipTypes")]
    public List<BungieMembershipType> MembershipTypes { get; set; }

    /// <summary>
    ///     Minimum Member Level allowed to invite new members to group
    /// <para />
    ///     Always Allowed: Founder, Acting Founder
    /// <para />
    ///     True means admins have this power, false means they don't
    /// <para />
    ///     Default is false for clans, true for groups.
    /// </summary>
    [JsonPropertyName("invitePermissionOverride")]
    public bool InvitePermissionOverride { get; set; }

    /// <summary>
    ///     Minimum Member Level allowed to update group culture
    /// <para />
    ///     Always Allowed: Founder, Acting Founder
    /// <para />
    ///     True means admins have this power, false means they don't
    /// <para />
    ///     Default is false for clans, true for groups.
    /// </summary>
    [JsonPropertyName("updateCulturePermissionOverride")]
    public bool UpdateCulturePermissionOverride { get; set; }

    /// <summary>
    ///     Minimum Member Level allowed to host guided games
    /// <para />
    ///     Always Allowed: Founder, Acting Founder, Admin
    /// <para />
    ///     Allowed Overrides: None, Member, Beginner
    /// <para />
    ///     Default is Member for clans, None for groups, although this means nothing for groups.
    /// </summary>
    [JsonPropertyName("hostGuidedGamePermissionOverride")]
    public GroupsV2.HostGuidedGamesPermissionLevel HostGuidedGamePermissionOverride { get; set; }

    /// <summary>
    ///     Minimum Member Level allowed to update banner
    /// <para />
    ///     Always Allowed: Founder, Acting Founder
    /// <para />
    ///     True means admins have this power, false means they don't
    /// <para />
    ///     Default is false for clans, true for groups.
    /// </summary>
    [JsonPropertyName("updateBannerPermissionOverride")]
    public bool UpdateBannerPermissionOverride { get; set; }

    /// <summary>
    ///     Level to join a member at when accepting an invite, application, or joining an open clan
    /// <para />
    ///     Default is Beginner.
    /// </summary>
    [JsonPropertyName("joinLevel")]
    public GroupsV2.RuntimeGroupMemberType JoinLevel { get; set; }

    public bool DeepEquals(GroupFeatures? other)
    {
        return other is not null &&
               MaximumMembers == other.MaximumMembers &&
               MaximumMembershipsOfGroupType == other.MaximumMembershipsOfGroupType &&
               Capabilities == other.Capabilities &&
               MembershipTypes.DeepEqualsListNaive(other.MembershipTypes) &&
               InvitePermissionOverride == other.InvitePermissionOverride &&
               UpdateCulturePermissionOverride == other.UpdateCulturePermissionOverride &&
               HostGuidedGamePermissionOverride == other.HostGuidedGamePermissionOverride &&
               UpdateBannerPermissionOverride == other.UpdateBannerPermissionOverride &&
               JoinLevel == other.JoinLevel;
    }
}