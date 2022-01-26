namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Some items are "sacks" - they can be "opened" to produce other items. This is information related to its sack status, mostly UI strings. Engrams are an example of items that are considered to be "Sacks".
/// </summary>
public class DestinyItemSackBlockDefinition : IDeepEquatable<DestinyItemSackBlockDefinition>
{
    /// <summary>
    ///     A description of what will happen when you open the sack. As far as I can tell, this is blank currently. Unknown whether it will eventually be populated with useful info.
    /// </summary>
    [JsonPropertyName("detailAction")]
    public string DetailAction { get; set; }

    /// <summary>
    ///     The localized name of the action being performed when you open the sack.
    /// </summary>
    [JsonPropertyName("openAction")]
    public string OpenAction { get; set; }

    [JsonPropertyName("selectItemCount")]
    public int SelectItemCount { get; set; }

    [JsonPropertyName("vendorSackType")]
    public string VendorSackType { get; set; }

    [JsonPropertyName("openOnAcquire")]
    public bool OpenOnAcquire { get; set; }

    public bool DeepEquals(DestinyItemSackBlockDefinition? other)
    {
        return other is not null &&
               DetailAction == other.DetailAction &&
               OpenAction == other.OpenAction &&
               SelectItemCount == other.SelectItemCount &&
               VendorSackType == other.VendorSackType &&
               OpenOnAcquire == other.OpenOnAcquire;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemSackBlockDefinition? other)
    {
        if (other is null) return;
        if (DetailAction != other.DetailAction)
        {
            DetailAction = other.DetailAction;
            OnPropertyChanged(nameof(DetailAction));
        }
        if (OpenAction != other.OpenAction)
        {
            OpenAction = other.OpenAction;
            OnPropertyChanged(nameof(OpenAction));
        }
        if (SelectItemCount != other.SelectItemCount)
        {
            SelectItemCount = other.SelectItemCount;
            OnPropertyChanged(nameof(SelectItemCount));
        }
        if (VendorSackType != other.VendorSackType)
        {
            VendorSackType = other.VendorSackType;
            OnPropertyChanged(nameof(VendorSackType));
        }
        if (OpenOnAcquire != other.OpenOnAcquire)
        {
            OpenOnAcquire = other.OpenOnAcquire;
            OnPropertyChanged(nameof(OpenOnAcquire));
        }
    }
}