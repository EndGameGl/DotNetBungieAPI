namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public class DestinyMilestoneChallengeDefinition : IDeepEquatable<DestinyMilestoneChallengeDefinition>
{
    /// <summary>
    ///     The challenge related to this milestone.
    /// </summary>
    [JsonPropertyName("challengeObjectiveHash")]
    public uint ChallengeObjectiveHash { get; set; }

    public bool DeepEquals(DestinyMilestoneChallengeDefinition? other)
    {
        return other is not null &&
               ChallengeObjectiveHash == other.ChallengeObjectiveHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMilestoneChallengeDefinition? other)
    {
        if (other is null) return;
        if (ChallengeObjectiveHash != other.ChallengeObjectiveHash)
        {
            ChallengeObjectiveHash = other.ChallengeObjectiveHash;
            OnPropertyChanged(nameof(ChallengeObjectiveHash));
        }
    }
}