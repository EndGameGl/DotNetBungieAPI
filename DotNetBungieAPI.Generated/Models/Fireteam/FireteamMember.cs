namespace DotNetBungieAPI.Generated.Models.Fireteam;

public sealed class FireteamMember
{

    [JsonPropertyName("destinyUserInfo")]
    public Fireteam.FireteamUserInfoCard DestinyUserInfo { get; init; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard BungieNetUserInfo { get; init; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; init; }

    [JsonPropertyName("dateJoined")]
    public DateTime DateJoined { get; init; }

    [JsonPropertyName("hasMicrophone")]
    public bool HasMicrophone { get; init; }

    [JsonPropertyName("lastPlatformInviteAttemptDate")]
    public DateTime LastPlatformInviteAttemptDate { get; init; }

    [JsonPropertyName("lastPlatformInviteAttemptResult")]
    public Fireteam.FireteamPlatformInviteResult LastPlatformInviteAttemptResult { get; init; }
}
