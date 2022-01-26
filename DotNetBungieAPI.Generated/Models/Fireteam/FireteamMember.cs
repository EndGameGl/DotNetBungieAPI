namespace DotNetBungieAPI.Generated.Models.Fireteam;

public class FireteamMember : IDeepEquatable<FireteamMember>
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

    public bool DeepEquals(FireteamMember? other)
    {
        return other is not null &&
               (DestinyUserInfo is not null ? DestinyUserInfo.DeepEquals(other.DestinyUserInfo) : other.DestinyUserInfo is null) &&
               (BungieNetUserInfo is not null ? BungieNetUserInfo.DeepEquals(other.BungieNetUserInfo) : other.BungieNetUserInfo is null) &&
               CharacterId == other.CharacterId &&
               DateJoined == other.DateJoined &&
               HasMicrophone == other.HasMicrophone &&
               LastPlatformInviteAttemptDate == other.LastPlatformInviteAttemptDate &&
               LastPlatformInviteAttemptResult == other.LastPlatformInviteAttemptResult;
    }
}