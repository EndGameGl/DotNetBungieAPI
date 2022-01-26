namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Represents a reference to a Challenge, which for now is just an Objective.
/// </summary>
public class DestinyActivityChallengeDefinition : IDeepEquatable<DestinyActivityChallengeDefinition>
{
    /// <summary>
    ///     The hash for the Objective that matches this challenge. Use it to look up the DestinyObjectiveDefinition.
    /// </summary>
    [JsonPropertyName("objectiveHash")]
    public uint ObjectiveHash { get; set; }

    /// <summary>
    ///     The rewards as they're represented in the UI. Note that they generally link to "dummy" items that give a summary of rewards rather than direct, real items themselves.
    /// <para />
    ///     If the quantity is 0, don't show the quantity.
    /// </summary>
    [JsonPropertyName("dummyRewards")]
    public List<Destiny.DestinyItemQuantity> DummyRewards { get; set; }

    public bool DeepEquals(DestinyActivityChallengeDefinition? other)
    {
        return other is not null &&
               ObjectiveHash == other.ObjectiveHash &&
               DummyRewards.DeepEqualsList(other.DummyRewards);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityChallengeDefinition? other)
    {
        if (other is null) return;
        if (ObjectiveHash != other.ObjectiveHash)
        {
            ObjectiveHash = other.ObjectiveHash;
            OnPropertyChanged(nameof(ObjectiveHash));
        }
        if (!DummyRewards.DeepEqualsList(other.DummyRewards))
        {
            DummyRewards = other.DummyRewards;
            OnPropertyChanged(nameof(DummyRewards));
        }
    }
}