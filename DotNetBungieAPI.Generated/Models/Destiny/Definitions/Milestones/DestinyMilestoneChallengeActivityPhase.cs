namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public class DestinyMilestoneChallengeActivityPhase : IDeepEquatable<DestinyMilestoneChallengeActivityPhase>
{
    /// <summary>
    ///     The hash identifier of the activity's phase.
    /// </summary>
    [JsonPropertyName("phaseHash")]
    public uint PhaseHash { get; set; }

    public bool DeepEquals(DestinyMilestoneChallengeActivityPhase? other)
    {
        return other is not null &&
               PhaseHash == other.PhaseHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMilestoneChallengeActivityPhase? other)
    {
        if (other is null) return;
        if (PhaseHash != other.PhaseHash)
        {
            PhaseHash = other.PhaseHash;
            OnPropertyChanged(nameof(PhaseHash));
        }
    }
}