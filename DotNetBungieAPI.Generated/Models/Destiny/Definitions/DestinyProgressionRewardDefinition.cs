namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Inventory Items can reward progression when actions are performed on them. A common example of this in Destiny 1 was Bounties, which would reward Experience on your Character and the like when you completed the bounty.
/// <para />
///     Note that this maps to a DestinyProgressionMappingDefinition, and *not* a DestinyProgressionDefinition directly. This is apparently so that multiple progressions can be granted progression points/experience at the same time.
/// </summary>
public class DestinyProgressionRewardDefinition : IDeepEquatable<DestinyProgressionRewardDefinition>
{
    /// <summary>
    ///     The hash identifier of the DestinyProgressionMappingDefinition that contains the progressions for which experience should be applied.
    /// </summary>
    [JsonPropertyName("progressionMappingHash")]
    public uint ProgressionMappingHash { get; set; }

    /// <summary>
    ///     The amount of experience to give to each of the mapped progressions.
    /// </summary>
    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    /// <summary>
    ///     If true, the game's internal mechanisms to throttle progression should be applied.
    /// </summary>
    [JsonPropertyName("applyThrottles")]
    public bool ApplyThrottles { get; set; }

    public bool DeepEquals(DestinyProgressionRewardDefinition? other)
    {
        return other is not null &&
               ProgressionMappingHash == other.ProgressionMappingHash &&
               Amount == other.Amount &&
               ApplyThrottles == other.ApplyThrottles;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyProgressionRewardDefinition? other)
    {
        if (other is null) return;
        if (ProgressionMappingHash != other.ProgressionMappingHash)
        {
            ProgressionMappingHash = other.ProgressionMappingHash;
            OnPropertyChanged(nameof(ProgressionMappingHash));
        }
        if (Amount != other.Amount)
        {
            Amount = other.Amount;
            OnPropertyChanged(nameof(Amount));
        }
        if (ApplyThrottles != other.ApplyThrottles)
        {
            ApplyThrottles = other.ApplyThrottles;
            OnPropertyChanged(nameof(ApplyThrottles));
        }
    }
}