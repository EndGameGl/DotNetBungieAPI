using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.GroupsV2
{
    public sealed record GroupFeatures
    {
        [JsonPropertyName("maximumMembers")]
        public int MaximumMembers { get; init; }

        [JsonPropertyName("maximumMembershipsOfGroupType")]
        public int MaximumMembershipsOfGroupType { get; init; }

        [JsonPropertyName("capabilities")]
        public Capabilities Capabilities { get; init; }

        [JsonPropertyName("membershipTypes")]
        public ReadOnlyCollection<BungieMembershipType> MembershipTypes { get; init; } = Defaults.EmptyReadOnlyCollection<BungieMembershipType>();

        [JsonPropertyName("invitePermissionOverride")]
        public bool InvitePermissionOverride { get; init; }

        [JsonPropertyName("updateCulturePermissionOverride")]
        public bool UpdateCulturePermissionOverride { get; init; }

        [JsonPropertyName("hostGuidedGamePermissionOverride")]
        public HostGuidedGamesPermissionLevel HostGuidedGamePermissionOverride { get; init; }

        [JsonPropertyName("updateBannerPermissionOverride")]
        public bool UpdateBannerPermissionOverride { get; init; }

        [JsonPropertyName("joinLevel")]
        public int JoinLevel { get; init; }
    }
}
