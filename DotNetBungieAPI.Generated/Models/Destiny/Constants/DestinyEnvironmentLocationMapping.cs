namespace DotNetBungieAPI.Generated.Models.Destiny.Constants;

public class DestinyEnvironmentLocationMapping : IDeepEquatable<DestinyEnvironmentLocationMapping>
{
    /// <summary>
    ///     The location that is revealed on the director by this mapping.
    /// </summary>
    [JsonPropertyName("locationHash")]
    public uint LocationHash { get; set; }

    /// <summary>
    ///     A hint that the UI uses to figure out how this location is activated by the player.
    /// </summary>
    [JsonPropertyName("activationSource")]
    public string ActivationSource { get; set; }

    /// <summary>
    ///     If this is populated, it is the item that you must possess for this location to be active because of this mapping. (theoretically, a location can have multiple mappings, and some might require an item while others don't)
    /// </summary>
    [JsonPropertyName("itemHash")]
    public uint? ItemHash { get; set; }

    /// <summary>
    ///     If this is populated, this is an objective related to the location.
    /// </summary>
    [JsonPropertyName("objectiveHash")]
    public uint? ObjectiveHash { get; set; }

    /// <summary>
    ///     If this is populated, this is the activity you have to be playing in order to see this location appear because of this mapping. (theoretically, a location can have multiple mappings, and some might require you to be in a specific activity when others don't)
    /// </summary>
    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; set; }

    public bool DeepEquals(DestinyEnvironmentLocationMapping? other)
    {
        return other is not null &&
               LocationHash == other.LocationHash &&
               ActivationSource == other.ActivationSource &&
               ItemHash == other.ItemHash &&
               ObjectiveHash == other.ObjectiveHash &&
               ActivityHash == other.ActivityHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyEnvironmentLocationMapping? other)
    {
        if (other is null) return;
        if (LocationHash != other.LocationHash)
        {
            LocationHash = other.LocationHash;
            OnPropertyChanged(nameof(LocationHash));
        }
        if (ActivationSource != other.ActivationSource)
        {
            ActivationSource = other.ActivationSource;
            OnPropertyChanged(nameof(ActivationSource));
        }
        if (ItemHash != other.ItemHash)
        {
            ItemHash = other.ItemHash;
            OnPropertyChanged(nameof(ItemHash));
        }
        if (ObjectiveHash != other.ObjectiveHash)
        {
            ObjectiveHash = other.ObjectiveHash;
            OnPropertyChanged(nameof(ObjectiveHash));
        }
        if (ActivityHash != other.ActivityHash)
        {
            ActivityHash = other.ActivityHash;
            OnPropertyChanged(nameof(ActivityHash));
        }
    }
}