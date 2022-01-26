namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Kiosks;

public class DestinyKioskItem : IDeepEquatable<DestinyKioskItem>
{
    /// <summary>
    ///     The index of the item in the related DestinyVendorDefintion's itemList property, representing the sale.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If true, the user can not only see the item, but they can acquire it. It is possible that a user can see a kiosk item and not be able to acquire it.
    /// </summary>
    [JsonPropertyName("canAcquire")]
    public bool CanAcquire { get; set; }

    /// <summary>
    ///     Indexes into failureStrings for the Vendor, indicating the reasons why it failed if any.
    /// </summary>
    [JsonPropertyName("failureIndexes")]
    public List<int> FailureIndexes { get; set; }

    /// <summary>
    ///     I may regret naming it this way - but this represents when an item has an objective that doesn't serve a beneficial purpose, but rather is used for "flavor" or additional information. For instance, when Emblems track specific stats, those stats are represented as Objectives on the item.
    /// </summary>
    [JsonPropertyName("flavorObjective")]
    public Destiny.Quests.DestinyObjectiveProgress FlavorObjective { get; set; }

    public bool DeepEquals(DestinyKioskItem? other)
    {
        return other is not null &&
               Index == other.Index &&
               CanAcquire == other.CanAcquire &&
               FailureIndexes.DeepEqualsListNaive(other.FailureIndexes) &&
               (FlavorObjective is not null ? FlavorObjective.DeepEquals(other.FlavorObjective) : other.FlavorObjective is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyKioskItem? other)
    {
        if (other is null) return;
        if (Index != other.Index)
        {
            Index = other.Index;
            OnPropertyChanged(nameof(Index));
        }
        if (CanAcquire != other.CanAcquire)
        {
            CanAcquire = other.CanAcquire;
            OnPropertyChanged(nameof(CanAcquire));
        }
        if (!FailureIndexes.DeepEqualsListNaive(other.FailureIndexes))
        {
            FailureIndexes = other.FailureIndexes;
            OnPropertyChanged(nameof(FailureIndexes));
        }
        if (!FlavorObjective.DeepEquals(other.FlavorObjective))
        {
            FlavorObjective.Update(other.FlavorObjective);
            OnPropertyChanged(nameof(FlavorObjective));
        }
    }
}