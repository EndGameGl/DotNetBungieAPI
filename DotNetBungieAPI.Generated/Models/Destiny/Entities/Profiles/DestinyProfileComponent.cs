namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Profiles;

/// <summary>
///     The most essential summary information about a Profile (in Destiny 1, we called these "Accounts").
/// </summary>
public class DestinyProfileComponent : IDeepEquatable<DestinyProfileComponent>
{
    /// <summary>
    ///     If you need to render the Profile (their platform name, icon, etc...) somewhere, this property contains that information.
    /// </summary>
    [JsonPropertyName("userInfo")]
    public User.UserInfoCard UserInfo { get; set; }

    /// <summary>
    ///     The last time the user played with any character on this Profile.
    /// </summary>
    [JsonPropertyName("dateLastPlayed")]
    public DateTime DateLastPlayed { get; set; }

    /// <summary>
    ///     If you want to know what expansions they own, this will contain that data.
    /// <para />
    ///      IMPORTANT: This field may not return the data you're interested in for Cross-Saved users. It returns the last ownership data we saw for this account - which is to say, what they've purchased on the platform on which they last played, which now could be a different platform.
    /// <para />
    ///      If you don't care about per-platform ownership and only care about whatever platform it seems they are playing on most recently, then this should be "good enough." Otherwise, this should be considered deprecated. We do not have a good alternative to provide at this time with platform specific ownership data for DLC.
    /// </summary>
    [JsonPropertyName("versionsOwned")]
    public Destiny.DestinyGameVersions VersionsOwned { get; set; }

    /// <summary>
    ///     A list of the character IDs, for further querying on your part.
    /// </summary>
    [JsonPropertyName("characterIds")]
    public List<long> CharacterIds { get; set; }

    /// <summary>
    ///     A list of seasons that this profile owns. Unlike versionsOwned, these stay with the profile across Platforms, and thus will be valid.
    /// <para />
    ///      It turns out that Stadia Pro subscriptions will give access to seasons but only while playing on Stadia and with an active subscription. So some users (users who have Stadia Pro but choose to play on some other platform) won't see these as available: it will be whatever seasons are available for the platform on which they last played.
    /// </summary>
    [JsonPropertyName("seasonHashes")]
    public List<uint> SeasonHashes { get; set; }

    /// <summary>
    ///     If populated, this is a reference to the season that is currently active.
    /// </summary>
    [JsonPropertyName("currentSeasonHash")]
    public uint? CurrentSeasonHash { get; set; }

    /// <summary>
    ///     If populated, this is the reward power cap for the current season.
    /// </summary>
    [JsonPropertyName("currentSeasonRewardPowerCap")]
    public int? CurrentSeasonRewardPowerCap { get; set; }

    public bool DeepEquals(DestinyProfileComponent? other)
    {
        return other is not null &&
               (UserInfo is not null ? UserInfo.DeepEquals(other.UserInfo) : other.UserInfo is null) &&
               DateLastPlayed == other.DateLastPlayed &&
               VersionsOwned == other.VersionsOwned &&
               CharacterIds.DeepEqualsListNaive(other.CharacterIds) &&
               SeasonHashes.DeepEqualsListNaive(other.SeasonHashes) &&
               CurrentSeasonHash == other.CurrentSeasonHash &&
               CurrentSeasonRewardPowerCap == other.CurrentSeasonRewardPowerCap;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyProfileComponent? other)
    {
        if (other is null) return;
        if (!UserInfo.DeepEquals(other.UserInfo))
        {
            UserInfo.Update(other.UserInfo);
            OnPropertyChanged(nameof(UserInfo));
        }
        if (DateLastPlayed != other.DateLastPlayed)
        {
            DateLastPlayed = other.DateLastPlayed;
            OnPropertyChanged(nameof(DateLastPlayed));
        }
        if (VersionsOwned != other.VersionsOwned)
        {
            VersionsOwned = other.VersionsOwned;
            OnPropertyChanged(nameof(VersionsOwned));
        }
        if (!CharacterIds.DeepEqualsListNaive(other.CharacterIds))
        {
            CharacterIds = other.CharacterIds;
            OnPropertyChanged(nameof(CharacterIds));
        }
        if (!SeasonHashes.DeepEqualsListNaive(other.SeasonHashes))
        {
            SeasonHashes = other.SeasonHashes;
            OnPropertyChanged(nameof(SeasonHashes));
        }
        if (CurrentSeasonHash != other.CurrentSeasonHash)
        {
            CurrentSeasonHash = other.CurrentSeasonHash;
            OnPropertyChanged(nameof(CurrentSeasonHash));
        }
        if (CurrentSeasonRewardPowerCap != other.CurrentSeasonRewardPowerCap)
        {
            CurrentSeasonRewardPowerCap = other.CurrentSeasonRewardPowerCap;
            OnPropertyChanged(nameof(CurrentSeasonRewardPowerCap));
        }
    }
}