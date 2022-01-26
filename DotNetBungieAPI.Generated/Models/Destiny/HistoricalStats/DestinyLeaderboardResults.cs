namespace DotNetBungieAPI.Generated.Models.Destiny.HistoricalStats;

public class DestinyLeaderboardResults : IDeepEquatable<DestinyLeaderboardResults>
{
    /// <summary>
    ///     Indicate the membership ID of the account that is the focal point of the provided leaderboards.
    /// </summary>
    [JsonPropertyName("focusMembershipId")]
    public long? FocusMembershipId { get; set; }

    /// <summary>
    ///     Indicate the character ID of the character that is the focal point of the provided leaderboards. May be null, in which case any character from the focus membership can appear in the provided leaderboards.
    /// </summary>
    [JsonPropertyName("focusCharacterId")]
    public long? FocusCharacterId { get; set; }

    public bool DeepEquals(DestinyLeaderboardResults? other)
    {
        return other is not null &&
               FocusMembershipId == other.FocusMembershipId &&
               FocusCharacterId == other.FocusCharacterId;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyLeaderboardResults? other)
    {
        if (other is null) return;
        if (FocusMembershipId != other.FocusMembershipId)
        {
            FocusMembershipId = other.FocusMembershipId;
            OnPropertyChanged(nameof(FocusMembershipId));
        }
        if (FocusCharacterId != other.FocusCharacterId)
        {
            FocusCharacterId = other.FocusCharacterId;
            OnPropertyChanged(nameof(FocusCharacterId));
        }
    }
}