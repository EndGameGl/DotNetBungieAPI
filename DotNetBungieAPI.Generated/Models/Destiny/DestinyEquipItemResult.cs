namespace DotNetBungieAPI.Generated.Models.Destiny;

/// <summary>
///     The results of an Equipping operation performed through the Destiny API.
/// </summary>
public class DestinyEquipItemResult : IDeepEquatable<DestinyEquipItemResult>
{
    /// <summary>
    ///     The instance ID of the item in question (all items that can be equipped must, but definition, be Instanced and thus have an Instance ID that you can use to refer to them)
    /// </summary>
    [JsonPropertyName("itemInstanceId")]
    public long ItemInstanceId { get; set; }

    /// <summary>
    ///     A PlatformErrorCodes enum indicating whether it succeeded, and if it failed why.
    /// </summary>
    [JsonPropertyName("equipStatus")]
    public Exceptions.PlatformErrorCodes EquipStatus { get; set; }

    public bool DeepEquals(DestinyEquipItemResult? other)
    {
        return other is not null &&
               ItemInstanceId == other.ItemInstanceId &&
               EquipStatus == other.EquipStatus;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyEquipItemResult? other)
    {
        if (other is null) return;
        if (ItemInstanceId != other.ItemInstanceId)
        {
            ItemInstanceId = other.ItemInstanceId;
            OnPropertyChanged(nameof(ItemInstanceId));
        }
        if (EquipStatus != other.EquipStatus)
        {
            EquipStatus = other.EquipStatus;
            OnPropertyChanged(nameof(EquipStatus));
        }
    }
}