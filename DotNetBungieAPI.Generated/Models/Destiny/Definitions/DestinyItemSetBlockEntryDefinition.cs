namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Defines a particular entry in an ItemSet (AKA a particular Quest Step in a Quest)
/// </summary>
public class DestinyItemSetBlockEntryDefinition : IDeepEquatable<DestinyItemSetBlockEntryDefinition>
{
    /// <summary>
    ///     Used for tracking which step a user reached. These values will be populated in the user's internal state, which we expose externally as a more usable DestinyQuestStatus object. If this item has been obtained, this value will be set in trackingUnlockValueHash.
    /// </summary>
    [JsonPropertyName("trackingValue")]
    public int TrackingValue { get; set; }

    /// <summary>
    ///     This is the hash identifier for a DestinyInventoryItemDefinition representing this quest step.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    public bool DeepEquals(DestinyItemSetBlockEntryDefinition? other)
    {
        return other is not null &&
               TrackingValue == other.TrackingValue &&
               ItemHash == other.ItemHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemSetBlockEntryDefinition? other)
    {
        if (other is null) return;
        if (TrackingValue != other.TrackingValue)
        {
            TrackingValue = other.TrackingValue;
            OnPropertyChanged(nameof(TrackingValue));
        }
        if (ItemHash != other.ItemHash)
        {
            ItemHash = other.ItemHash;
            OnPropertyChanged(nameof(ItemHash));
        }
    }
}