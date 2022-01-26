namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The definition of an item and quantity required in a character's inventory in order to perform an action.
/// </summary>
public class DestinyItemActionRequiredItemDefinition : IDeepEquatable<DestinyItemActionRequiredItemDefinition>
{
    /// <summary>
    ///     The minimum quantity of the item you have to have.
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }

    /// <summary>
    ///     The hash identifier of the item you need to have. Use it to look up the DestinyInventoryItemDefinition for more info.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    /// <summary>
    ///     If true, the item/quantity will be deleted from your inventory when the action is performed. Otherwise, you'll retain these required items after the action is complete.
    /// </summary>
    [JsonPropertyName("deleteOnAction")]
    public bool DeleteOnAction { get; set; }

    public bool DeepEquals(DestinyItemActionRequiredItemDefinition? other)
    {
        return other is not null &&
               Count == other.Count &&
               ItemHash == other.ItemHash &&
               DeleteOnAction == other.DeleteOnAction;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemActionRequiredItemDefinition? other)
    {
        if (other is null) return;
        if (Count != other.Count)
        {
            Count = other.Count;
            OnPropertyChanged(nameof(Count));
        }
        if (ItemHash != other.ItemHash)
        {
            ItemHash = other.ItemHash;
            OnPropertyChanged(nameof(ItemHash));
        }
        if (DeleteOnAction != other.DeleteOnAction)
        {
            DeleteOnAction = other.DeleteOnAction;
            OnPropertyChanged(nameof(DeleteOnAction));
        }
    }
}