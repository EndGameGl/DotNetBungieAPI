using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupFeatures
{

    [JsonPropertyName("maximumMembers")]
    public int MaximumMembers { get; init; }

    [JsonPropertyName("maximumMembershipsOfGroupType")]
    public int MaximumMembershipsOfGroupType { get; init; }

    [JsonPropertyName("capabilities")]
    public GroupsV2.Capabilities Capabilities { get; init; }

    [JsonPropertyName("membershipTypes")]
    public List<BungieMembershipType> MembershipTypes { get; init; }

    [JsonPropertyName("invitePermissionOverride")]
    public bool InvitePermissionOverride { get; init; }

    [JsonPropertyName("updateCulturePermissionOverride")]
    public bool UpdateCulturePermissionOverride { get; init; }

    [JsonPropertyName("hostGuidedGamePermissionOverride")]
    public GroupsV2.HostGuidedGamesPermissionLevel HostGuidedGamePermissionOverride { get; init; }

    [JsonPropertyName("updateBannerPermissionOverride")]
    public bool UpdateBannerPermissionOverride { get; init; }

    [JsonPropertyName("joinLevel")]
    public GroupsV2.RuntimeGroupMemberType JoinLevel { get; init; }
}
