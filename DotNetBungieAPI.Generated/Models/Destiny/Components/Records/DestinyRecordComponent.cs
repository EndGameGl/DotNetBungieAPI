namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Records;

public class DestinyRecordComponent : IDeepEquatable<DestinyRecordComponent>
{
    [JsonPropertyName("state")]
    public Destiny.DestinyRecordState State { get; set; }

    [JsonPropertyName("objectives")]
    public List<Destiny.Quests.DestinyObjectiveProgress> Objectives { get; set; }

    [JsonPropertyName("intervalObjectives")]
    public List<Destiny.Quests.DestinyObjectiveProgress> IntervalObjectives { get; set; }

    [JsonPropertyName("intervalsRedeemedCount")]
    public int IntervalsRedeemedCount { get; set; }

    /// <summary>
    ///     If available, this is the number of times this record has been completed. For example, the number of times a seal title has been gilded.
    /// </summary>
    [JsonPropertyName("completedCount")]
    public int? CompletedCount { get; set; }

    /// <summary>
    ///     If available, a list that describes which reward rewards should be shown (true) or hidden (false). This property is for regular record rewards, and not for interval objective rewards.
    /// </summary>
    [JsonPropertyName("rewardVisibilty")]
    public List<bool> RewardVisibilty { get; set; }

    public bool DeepEquals(DestinyRecordComponent? other)
    {
        return other is not null &&
               State == other.State &&
               Objectives.DeepEqualsList(other.Objectives) &&
               IntervalObjectives.DeepEqualsList(other.IntervalObjectives) &&
               IntervalsRedeemedCount == other.IntervalsRedeemedCount &&
               CompletedCount == other.CompletedCount &&
               RewardVisibilty.DeepEqualsListNaive(other.RewardVisibilty);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyRecordComponent? other)
    {
        if (other is null) return;
        if (State != other.State)
        {
            State = other.State;
            OnPropertyChanged(nameof(State));
        }
        if (!Objectives.DeepEqualsList(other.Objectives))
        {
            Objectives = other.Objectives;
            OnPropertyChanged(nameof(Objectives));
        }
        if (!IntervalObjectives.DeepEqualsList(other.IntervalObjectives))
        {
            IntervalObjectives = other.IntervalObjectives;
            OnPropertyChanged(nameof(IntervalObjectives));
        }
        if (IntervalsRedeemedCount != other.IntervalsRedeemedCount)
        {
            IntervalsRedeemedCount = other.IntervalsRedeemedCount;
            OnPropertyChanged(nameof(IntervalsRedeemedCount));
        }
        if (CompletedCount != other.CompletedCount)
        {
            CompletedCount = other.CompletedCount;
            OnPropertyChanged(nameof(CompletedCount));
        }
        if (!RewardVisibilty.DeepEqualsListNaive(other.RewardVisibilty))
        {
            RewardVisibilty = other.RewardVisibilty;
            OnPropertyChanged(nameof(RewardVisibilty));
        }
    }
}