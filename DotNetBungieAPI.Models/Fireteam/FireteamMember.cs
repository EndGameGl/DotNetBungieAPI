using DotNetBungieAPI.Models.User;

namespace DotNetBungieAPI.Models.Fireteam;

public sealed record FireteamMember
{
    [JsonPropertyName("destinyUserInfo")]
    public FireteamUserInfoCard DestinyUserInfo { get; init; }

    [JsonPropertyName("bungieNetUserInfo")]
    public UserInfoCard BungieNetUserInfo { get; init; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("dateJoined")]
    public DateTime DateJoined { get; init; }

    [JsonPropertyName("hasMicrophone")]
    public bool HasMicrophone { get; init; }

    [JsonPropertyName("lastPlatformInviteAttemptDate")]
    public DateTime LastPlatformInviteAttemptDate { get; init; }

    [JsonPropertyName("lastPlatformInviteAttemptResult")]
    public FireteamPlatformInviteResult LastPlatformInviteAttemptResult { get; init; }
}
