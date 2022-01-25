namespace DotNetBungieAPI.Generated.Models.Fireteam;

public class FireteamMember
{
    [JsonPropertyName("destinyUserInfo")]
    public Fireteam.FireteamUserInfoCard DestinyUserInfo { get; set; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard BungieNetUserInfo { get; set; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("dateJoined")]
    public DateTime DateJoined { get; set; }

    [JsonPropertyName("hasMicrophone")]
    public bool HasMicrophone { get; set; }

    [JsonPropertyName("lastPlatformInviteAttemptDate")]
    public DateTime LastPlatformInviteAttemptDate { get; set; }

    [JsonPropertyName("lastPlatformInviteAttemptResult")]
    public Fireteam.FireteamPlatformInviteResult LastPlatformInviteAttemptResult { get; set; }
}
