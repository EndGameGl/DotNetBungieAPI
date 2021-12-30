using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Fireteam;

public sealed class FireteamUserInfoCard
{

    [JsonPropertyName("FireteamDisplayName")]
    public string FireteamDisplayName { get; init; }

    [JsonPropertyName("FireteamMembershipType")]
    public BungieMembershipType FireteamMembershipType { get; init; }

    [JsonPropertyName("supplementalDisplayName")]
    public string SupplementalDisplayName { get; init; }

    [JsonPropertyName("iconPath")]
    public string IconPath { get; init; }

    [JsonPropertyName("crossSaveOverride")]
    public BungieMembershipType CrossSaveOverride { get; init; }

    [JsonPropertyName("applicableMembershipTypes")]
    public List<BungieMembershipType> ApplicableMembershipTypes { get; init; }

    [JsonPropertyName("isPublic")]
    public bool IsPublic { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }

    [JsonPropertyName("membershipId")]
    public long MembershipId { get; init; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; init; }

    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; init; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; init; }
}
