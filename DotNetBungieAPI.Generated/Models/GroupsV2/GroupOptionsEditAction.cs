using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupOptionsEditAction
{

    [JsonPropertyName("InvitePermissionOverride")]
    public bool? InvitePermissionOverride { get; init; }

    [JsonPropertyName("UpdateCulturePermissionOverride")]
    public bool? UpdateCulturePermissionOverride { get; init; }

    [JsonPropertyName("HostGuidedGamePermissionOverride")]
    public int? HostGuidedGamePermissionOverride { get; init; }

    [JsonPropertyName("UpdateBannerPermissionOverride")]
    public bool? UpdateBannerPermissionOverride { get; init; }

    [JsonPropertyName("JoinLevel")]
    public int? JoinLevel { get; init; }
}
