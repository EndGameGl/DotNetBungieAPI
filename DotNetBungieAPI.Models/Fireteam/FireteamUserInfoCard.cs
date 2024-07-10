using DotNetBungieAPI.Models.User;

namespace DotNetBungieAPI.Models.Fireteam;

public sealed record FireteamUserInfoCard : UserInfoCard
{
    [JsonPropertyName("FireteamDisplayName")]
    public string FireteamDisplayName { get; init; }

    [JsonPropertyName("FireteamMembershipType")]
    public int FireteamMembershipType { get; init; }

    [JsonPropertyName("FireteamPlatformProfileUrl")]
    public string FireteamPlatformProfileUrl { get; init; }

    [JsonPropertyName("FireteamPlatformUniqueIdentifier")]
    public string FireteamPlatformUniqueIdentifier { get; init; }
}
