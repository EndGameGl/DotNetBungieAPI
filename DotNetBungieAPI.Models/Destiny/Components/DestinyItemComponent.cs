using DotNetBungieAPI.Models.Destiny.Definitions.InventoryBuckets;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Definitions.Metrics;
using DotNetBungieAPI.Models.Destiny.Quests;

namespace DotNetBungieAPI.Models.Destiny.Components;

/// <summary>
///     The base item component, filled with properties that are generally useful to know in any item request or that don't
///     feel worthwhile to put in their own component.
/// </summary>
public sealed record DestinyItemComponent : DestinyItemQuantity
{
    /// <summary>
    ///     If the item is bound to a location, it will be specified in this enum.
    /// </summary>
    [JsonPropertyName("bindStatus")]
    public ItemBindStatus BindStatus { get; init; }

    /// <summary>
    ///     An easy reference for where the item is located. Redundant if you got the item from an Inventory, but useful when
    ///     making detail calls on specific items.
    /// </summary>
    [JsonPropertyName("location")]
    public ItemLocation Location { get; init; }

    /// <summary>
    ///     The hash identifier for the specific inventory bucket in which the item is located.
    /// </summary>
    [JsonPropertyName("bucketHash")]
    public DefinitionHashPointer<DestinyInventoryBucketDefinition> Bucket { get; init; } =
        DefinitionHashPointer<DestinyInventoryBucketDefinition>.Empty;

    /// <summary>
    ///     If there is a known error state that would cause this item to not be transferable, this Flags enum will indicate
    ///     all of those error states. Otherwise, it will be 0 (CanTransfer).
    /// </summary>
    [JsonPropertyName("transferStatus")]
    public TransferStatuses TransferStatus { get; init; }

    /// <summary>
    ///     If the item can be locked, this will indicate that state.
    /// </summary>
    [JsonPropertyName("lockable")]
    public bool IsLockable { get; init; }

    /// <summary>
    ///     A flags enumeration indicating the transient/custom states of the item that affect how it is rendered: whether it's
    ///     tracked or locked for example, or whether it has a masterwork plug inserted.
    /// </summary>
    [JsonPropertyName("state")]
    public ItemState State { get; init; }

    /// <summary>
    ///     If populated, this is the hash of the item whose icon (and other secondary styles, but *not* the human readable
    ///     strings) should override whatever icons/styles are on the item being sold.
    ///     <para />
    ///     If you don't do this, certain items whose styles are being overridden by socketed items - such as the "Recycle
    ///     Shader" item - would show whatever their default icon/style is, and it wouldn't be pretty or look accurate.
    /// </summary>
    [JsonPropertyName("overrideStyleItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> OverrideStyleItem { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    /// <summary>
    ///     If the item can expire, this is the date at which it will/did expire.
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public DateTime? ExpirationDate { get; init; }

    /// <summary>
    ///     If this is true, the object is actually a "wrapper" of the object it's representing. This means that it's not the
    ///     actual item itself, but rather an item that must be "opened" in game before you have and can use the item.
    ///     <para />
    ///     Wrappers are an evolution of "bundles", which give an easy way to let you preview the contents of what you
    ///     purchased while still letting you get a refund before you "open" it.
    /// </summary>
    [JsonPropertyName("isWrapper")]
    public bool IsWrapper { get; init; }

    /// <summary>
    ///     If this is populated, it is a list of indexes into DestinyInventoryItemDefinition.tooltipNotifications for any
    ///     special tooltip messages that need to be shown for this item.
    /// </summary>
    [JsonPropertyName("tooltipNotificationIndexes")]
    public ReadOnlyCollection<int> TooltipNotificationIndexes { get; init; } =
        ReadOnlyCollections<int>.Empty;

    /// <summary>
    ///     The identifier for the currently-selected metric definition, to be displayed on the emblem nameplate.
    /// </summary>
    [JsonPropertyName("metricHash")]
    public DefinitionHashPointer<DestinyMetricDefinition> Metric { get; init; } =
        DefinitionHashPointer<DestinyMetricDefinition>.Empty;

    /// <summary>
    ///     The objective progress for the currently-selected metric definition, to be displayed on the emblem nameplate.
    /// </summary>
    [JsonPropertyName("metricObjective")]
    public DestinyObjectiveProgress MetricObjective { get; init; }

    /// <summary>
    ///     The version of this item, used to index into the versions list in the item definition quality block.
    /// </summary>
    [JsonPropertyName("versionNumber")]
    public int? VersionNumber { get; init; }

    /// <summary>
    ///     If available, a list that describes which item values (rewards) should be shown (true) or hidden (false).
    /// </summary>
    [JsonPropertyName("itemValueVisibility")]
    public ReadOnlyCollection<bool> ItemValueVisibility { get; init; } =
        ReadOnlyCollections<bool>.Empty;
}
