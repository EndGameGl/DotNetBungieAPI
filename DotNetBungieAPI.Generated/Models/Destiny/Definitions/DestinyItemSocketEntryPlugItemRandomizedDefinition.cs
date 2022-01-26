namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyItemSocketEntryPlugItemRandomizedDefinition : IDeepEquatable<DestinyItemSocketEntryPlugItemRandomizedDefinition>
{
    /// <summary>
    ///     Indicates if the plug can be rolled on the current version of the item. For example, older versions of weapons may have plug rolls that are no longer possible on the current versions.
    /// </summary>
    [JsonPropertyName("currentlyCanRoll")]
    public bool CurrentlyCanRoll { get; set; }

    /// <summary>
    ///     The hash identifier of a DestinyInventoryItemDefinition representing the plug that can be inserted.
    /// </summary>
    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; set; }

    public bool DeepEquals(DestinyItemSocketEntryPlugItemRandomizedDefinition? other)
    {
        return other is not null &&
               CurrentlyCanRoll == other.CurrentlyCanRoll &&
               PlugItemHash == other.PlugItemHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemSocketEntryPlugItemRandomizedDefinition? other)
    {
        if (other is null) return;
        if (CurrentlyCanRoll != other.CurrentlyCanRoll)
        {
            CurrentlyCanRoll = other.CurrentlyCanRoll;
            OnPropertyChanged(nameof(CurrentlyCanRoll));
        }
        if (PlugItemHash != other.PlugItemHash)
        {
            PlugItemHash = other.PlugItemHash;
            OnPropertyChanged(nameof(PlugItemHash));
        }
    }
}