namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public class DestinyItemChangeResponse : IDeepEquatable<DestinyItemChangeResponse>
{
    [JsonPropertyName("item")]
    public Destiny.Responses.DestinyItemResponse Item { get; set; }

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

    public bool DeepEquals(DestinyItemChangeResponse? other)
    {
        return other is not null &&
               (Item is not null ? Item.DeepEquals(other.Item) : other.Item is null) &&
               AddedInventoryItems.DeepEqualsList(other.AddedInventoryItems) &&
               RemovedInventoryItems.DeepEqualsList(other.RemovedInventoryItems);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemChangeResponse? other)
    {
        if (other is null) return;
        if (!Item.DeepEquals(other.Item))
        {
            Item.Update(other.Item);
            OnPropertyChanged(nameof(Item));
        }
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