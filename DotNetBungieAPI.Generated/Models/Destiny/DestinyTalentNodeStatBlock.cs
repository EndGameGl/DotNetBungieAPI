namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     This property has some history. A talent grid can provide stats on both the item it's related to and the character equipping the item. This returns data about those stat bonuses.
/// </summary>
public class DestinyTalentNodeStatBlock : IDeepEquatable<DestinyTalentNodeStatBlock>
{
    /// <summary>
    ///     The stat benefits conferred when this talent node is activated for the current Step that is active on the node.
    /// </summary>
    [JsonPropertyName("currentStepStats")]
    public List<Destiny.DestinyStat> CurrentStepStats { get; set; }

    /// <summary>
    ///     This is a holdover from the old days of Destiny 1, when a node could be activated multiple times, conferring multiple steps worth of benefits: you would use this property to show what activating the "next" step on the node would provide vs. what the current step is providing. While Nodes are currently not being used this way, the underlying system for this functionality still exists. I hesitate to remove this property while the ability for designers to make such a talent grid still exists. Whether you want to show it is up to you.
    /// </summary>
    [JsonPropertyName("nextStepStats")]
    public List<Destiny.DestinyStat> NextStepStats { get; set; }

    public bool DeepEquals(DestinyTalentNodeStatBlock? other)
    {
        return other is not null &&
               CurrentStepStats.DeepEqualsList(other.CurrentStepStats) &&
               NextStepStats.DeepEqualsList(other.NextStepStats);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyTalentNodeStatBlock? other)
    {
        if (other is null) return;
        if (!CurrentStepStats.DeepEqualsList(other.CurrentStepStats))
        {
            CurrentStepStats = other.CurrentStepStats;
            OnPropertyChanged(nameof(CurrentStepStats));
        }
        if (!NextStepStats.DeepEqualsList(other.NextStepStats))
        {
            NextStepStats = other.NextStepStats;
            OnPropertyChanged(nameof(NextStepStats));
        }
    }
}