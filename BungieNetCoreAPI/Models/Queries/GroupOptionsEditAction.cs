using NetBungieAPI.Models.GroupsV2;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public class GroupOptionsEditAction
    {
        [JsonPropertyName("InvitePermissionOverride")]
        public bool? InvitePermissionOverride { get; init; } = null;

        [JsonPropertyName("UpdateCulturePermissionOverride")]
        public bool? UpdateCulturePermissionOverride { get; init; } = null;

        [JsonPropertyName("HostGuidedGamePermissionOverride")]
        public HostGuidedGamesPermissionLevel? HostGuidedGamePermissionOverride { get; init; } = null;

        [JsonPropertyName("UpdateBannerPermissionOverride")]
        public bool? UpdateBannerPermissionOverride { get; init; } = null;

        [JsonPropertyName("JoinLevel")]
        public RuntimeGroupMemberType? JoinLevel { get; init; } = null;
    }
}
