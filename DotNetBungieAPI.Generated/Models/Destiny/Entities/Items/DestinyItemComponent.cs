namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

/// <summary>
///     The base item component, filled with properties that are generally useful to know in any item request or that don't feel worthwhile to put in their own component.
/// </summary>
public class DestinyItemComponent : IDeepEquatable<DestinyItemComponent>
{
    /// <summary>
    ///     The identifier for the item's definition, which is where most of the useful static information for the item can be found.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    /// <summary>
    ///     If the item is instanced, it will have an instance ID. Lack of an instance ID implies that the item has no distinct local qualities aside from stack size.
    /// </summary>
    [JsonPropertyName("itemInstanceId")]
    public long? ItemInstanceId { get; set; }

    /// <summary>
    ///     The quantity of the item in this stack. Note that Instanced items cannot stack. If an instanced item, this value will always be 1 (as the stack has exactly one item in it)
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>
    ///     If the item is bound to a location, it will be specified in this enum.
    /// </summary>
    [JsonPropertyName("bindStatus")]
    public Destiny.ItemBindStatus BindStatus { get; set; }

    /// <summary>
    ///     An easy reference for where the item is located. Redundant if you got the item from an Inventory, but useful when making detail calls on specific items.
    /// </summary>
    [JsonPropertyName("location")]
    public Destiny.ItemLocation Location { get; set; }

    /// <summary>
    ///     The hash identifier for the specific inventory bucket in which the item is located.
    /// </summary>
    [JsonPropertyName("bucketHash")]
    public uint BucketHash { get; set; }

    /// <summary>
    ///     If there is a known error state that would cause this item to not be transferable, this Flags enum will indicate all of those error states. Otherwise, it will be 0 (CanTransfer).
    /// </summary>
    [JsonPropertyName("transferStatus")]
    public Destiny.TransferStatuses TransferStatus { get; set; }

    /// <summary>
    ///     If the item can be locked, this will indicate that state.
    /// </summary>
    [JsonPropertyName("lockable")]
    public bool Lockable { get; set; }

    /// <summary>
    ///     A flags enumeration indicating the transient/custom states of the item that affect how it is rendered: whether it's tracked or locked for example, or whether it has a masterwork plug inserted.
    /// </summary>
    [JsonPropertyName("state")]
    public Destiny.ItemState State { get; set; }

    /// <summary>
    ///     If populated, this is the hash of the item whose icon (and other secondary styles, but *not* the human readable strings) should override whatever icons/styles are on the item being sold.
    /// <para />
    ///     If you don't do this, certain items whose styles are being overridden by socketed items - such as the "Recycle Shader" item - would show whatever their default icon/style is, and it wouldn't be pretty or look accurate.
    /// </summary>
    [JsonPropertyName("overrideStyleItemHash")]
    public uint? OverrideStyleItemHash { get; set; }

    /// <summary>
    ///     If the item can expire, this is the date at which it will/did expire.
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public DateTime? ExpirationDate { get; set; }

    /// <summary>
    ///     If this is true, the object is actually a "wrapper" of the object it's representing. This means that it's not the actual item itself, but rather an item that must be "opened" in game before you have and can use the item.
    /// <para />
    ///      Wrappers are an evolution of "bundles", which give an easy way to let you preview the contents of what you purchased while still letting you get a refund before you "open" it.
    /// </summary>
    [JsonPropertyName("isWrapper")]
    public bool IsWrapper { get; set; }

    /// <summary>
    ///     If this is populated, it is a list of indexes into DestinyInventoryItemDefinition.tooltipNotifications for any special tooltip messages that need to be shown for this item.
    /// </summary>
    [JsonPropertyName("tooltipNotificationIndexes")]
    public List<int> TooltipNotificationIndexes { get; set; }

    /// <summary>
    ///     The identifier for the currently-selected metric definition, to be displayed on the emblem nameplate.
    /// </summary>
    [JsonPropertyName("metricHash")]
    public uint? MetricHash { get; set; }

    /// <summary>
    ///     The objective progress for the currently-selected metric definition, to be displayed on the emblem nameplate.
    /// </summary>
    [JsonPropertyName("metricObjective")]
    public Destiny.Quests.DestinyObjectiveProgress MetricObjective { get; set; }

    /// <summary>
    ///     The version of this item, used to index into the versions list in the item definition quality block.
    /// </summary>
    [JsonPropertyName("versionNumber")]
    public int? VersionNumber { get; set; }

    /// <summary>
    ///     If available, a list that describes which item values (rewards) should be shown (true) or hidden (false).
    /// </summary>
    [JsonPropertyName("itemValueVisibility")]
    public List<bool> ItemValueVisibility { get; set; }

    public bool DeepEquals(DestinyItemComponent? other)
    {
        return other is not null &&
               ItemHash == other.ItemHash &&
               ItemInstanceId == other.ItemInstanceId &&
               Quantity == other.Quantity &&
               BindStatus == other.BindStatus &&
               Location == other.Location &&
               BucketHash == other.BucketHash &&
               TransferStatus == other.TransferStatus &&
               Lockable == other.Lockable &&
               State == other.State &&
               OverrideStyleItemHash == other.OverrideStyleItemHash &&
               ExpirationDate == other.ExpirationDate &&
               IsWrapper == other.IsWrapper &&
               TooltipNotificationIndexes.DeepEqualsListNaive(other.TooltipNotificationIndexes) &&
               MetricHash == other.MetricHash &&
               (MetricObjective is not null ? MetricObjective.DeepEquals(other.MetricObjective) : other.MetricObjective is null) &&
               VersionNumber == other.VersionNumber &&
               ItemValueVisibility.DeepEqualsListNaive(other.ItemValueVisibility);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemComponent? other)
    {
        if (other is null) return;
        if (ItemHash != other.ItemHash)
        {
            ItemHash = other.ItemHash;
            OnPropertyChanged(nameof(ItemHash));
        }
        if (ItemInstanceId != other.ItemInstanceId)
        {
            ItemInstanceId = other.ItemInstanceId;
            OnPropertyChanged(nameof(ItemInstanceId));
        }
        if (Quantity != other.Quantity)
        {
            Quantity = other.Quantity;
            OnPropertyChanged(nameof(Quantity));
        }
        if (BindStatus != other.BindStatus)
        {
            BindStatus = other.BindStatus;
            OnPropertyChanged(nameof(BindStatus));
        }
        if (Location != other.Location)
        {
            Location = other.Location;
            OnPropertyChanged(nameof(Location));
        }
        if (BucketHash != other.BucketHash)
        {
            BucketHash = other.BucketHash;
            OnPropertyChanged(nameof(BucketHash));
        }
        if (TransferStatus != other.TransferStatus)
        {
            TransferStatus = other.TransferStatus;
            OnPropertyChanged(nameof(TransferStatus));
        }
        if (Lockable != other.Lockable)
        {
            Lockable = other.Lockable;
            OnPropertyChanged(nameof(Lockable));
        }
        if (State != other.State)
        {
            State = other.State;
            OnPropertyChanged(nameof(State));
        }
        if (OverrideStyleItemHash != other.OverrideStyleItemHash)
        {
            OverrideStyleItemHash = other.OverrideStyleItemHash;
            OnPropertyChanged(nameof(OverrideStyleItemHash));
        }
        if (ExpirationDate != other.ExpirationDate)
        {
            ExpirationDate = other.ExpirationDate;
            OnPropertyChanged(nameof(ExpirationDate));
        }
        if (IsWrapper != other.IsWrapper)
        {
            IsWrapper = other.IsWrapper;
            OnPropertyChanged(nameof(IsWrapper));
        }
        if (!TooltipNotificationIndexes.DeepEqualsListNaive(other.TooltipNotificationIndexes))
        {
            TooltipNotificationIndexes = other.TooltipNotificationIndexes;
            OnPropertyChanged(nameof(TooltipNotificationIndexes));
        }
        if (MetricHash != other.MetricHash)
        {
            MetricHash = other.MetricHash;
            OnPropertyChanged(nameof(MetricHash));
        }
        if (!MetricObjective.DeepEquals(other.MetricObjective))
        {
            MetricObjective.Update(other.MetricObjective);
            OnPropertyChanged(nameof(MetricObjective));
        }
        if (VersionNumber != other.VersionNumber)
        {
            VersionNumber = other.VersionNumber;
            OnPropertyChanged(nameof(VersionNumber));
        }
        if (!ItemValueVisibility.DeepEqualsListNaive(other.ItemValueVisibility))
        {
            ItemValueVisibility = other.ItemValueVisibility;
            OnPropertyChanged(nameof(ItemValueVisibility));
        }
    }
}