namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

/// <summary>
///     A response containing all of the components for all requested vendors.
/// </summary>
public class InventoryChangedResponse : IDeepEquatable<InventoryChangedResponse>
{
    /// <summary>
    ///     Items that appeared in the inventory possibly as a result of an action.
    /// </summary>
    [JsonPropertyName("addedInventoryItems")]
    public List<Destiny.Entities.Items.DestinyItemComponent> AddedInventoryItems { get; set; }

    /// <summary>
    ///     Items that disappeared from the inventory possibly as a result of an action.
    /// </summary>
    [JsonPropertyName("removedInventoryItems")]
    public List<Destiny.Entities.Items.DestinyItemComponent> RemovedInventoryItems { get; set; }

    public bool DeepEquals(InventoryChangedResponse? other)
    {
        return other is not null &&
               AddedInventoryItems.DeepEqualsList(other.AddedInventoryItems) &&
               RemovedInventoryItems.DeepEqualsList(other.RemovedInventoryItems);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(InventoryChangedResponse? other)
    {
        if (other is null) return;
        if (!AddedInventoryItems.DeepEqualsList(other.AddedInventoryItems))
        {
            AddedInventoryItems = other.AddedInventoryItems;
            OnPropertyChanged(nameof(AddedInventoryItems));
        }
        if (!RemovedInventoryItems.DeepEqualsList(other.RemovedInventoryItems))
        {
            RemovedInventoryItems = other.RemovedInventoryItems;
            OnPropertyChanged(nameof(RemovedInventoryItems));
        }
    }
}