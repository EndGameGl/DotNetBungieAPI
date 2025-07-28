namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

/// <summary>
///     The base item component, filled with properties that are generally useful to know in any item request or that don't feel worthwhile to put in their own component.
/// </summary>
public class DestinyItemComponent
{
    /// <summary>
    ///     The identifier for the item's definition, which is where most of the useful static information for the item can be found.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
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
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryBucketDefinition>("Destiny.Definitions.DestinyInventoryBucketDefinition")]
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
    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
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
    public int[]? TooltipNotificationIndexes { get; set; }

    /// <summary>
    ///     The identifier for the currently-selected metric definition, to be displayed on the emblem nameplate.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Metrics.DestinyMetricDefinition>("Destiny.Definitions.Metrics.DestinyMetricDefinition")]
    [JsonPropertyName("metricHash")]
    public uint? MetricHash { get; set; }

    /// <summary>
    ///     The objective progress for the currently-selected metric definition, to be displayed on the emblem nameplate.
    /// </summary>
    [JsonPropertyName("metricObjective")]
    public Destiny.Quests.DestinyObjectiveProgress? MetricObjective { get; set; }

    /// <summary>
    ///     The version of this item, used to index into the versions list in the item definition quality block.
    /// </summary>
    [JsonPropertyName("versionNumber")]
    public int? VersionNumber { get; set; }

    /// <summary>
    ///     If available, a list that describes which item values (rewards) should be shown (true) or hidden (false).
    /// </summary>
    [JsonPropertyName("itemValueVisibility")]
    public bool[]? ItemValueVisibility { get; set; }
}
