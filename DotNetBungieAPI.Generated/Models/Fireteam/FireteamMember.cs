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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(FireteamMember? other)
    {
        if (other is null) return;
        if (!DestinyUserInfo.DeepEquals(other.DestinyUserInfo))
        {
            DestinyUserInfo.Update(other.DestinyUserInfo);
            OnPropertyChanged(nameof(DestinyUserInfo));
        }
        if (!BungieNetUserInfo.DeepEquals(other.BungieNetUserInfo))
        {
            BungieNetUserInfo.Update(other.BungieNetUserInfo);
            OnPropertyChanged(nameof(BungieNetUserInfo));
        }
        if (CharacterId != other.CharacterId)
        {
            CharacterId = other.CharacterId;
            OnPropertyChanged(nameof(CharacterId));
        }
        if (DateJoined != other.DateJoined)
        {
            DateJoined = other.DateJoined;
            OnPropertyChanged(nameof(DateJoined));
        }
        if (HasMicrophone != other.HasMicrophone)
        {
            HasMicrophone = other.HasMicrophone;
            OnPropertyChanged(nameof(HasMicrophone));
        }
        if (LastPlatformInviteAttemptDate != other.LastPlatformInviteAttemptDate)
        {
            LastPlatformInviteAttemptDate = other.LastPlatformInviteAttemptDate;
            OnPropertyChanged(nameof(LastPlatformInviteAttemptDate));
        }
        if (LastPlatformInviteAttemptResult != other.LastPlatformInviteAttemptResult)
        {
            LastPlatformInviteAttemptResult = other.LastPlatformInviteAttemptResult;
            OnPropertyChanged(nameof(LastPlatformInviteAttemptResult));
        }
    }
}