namespace DotNetBungieAPI.Models.Destiny.Definitions.Milestones;

/// <summary>
///     A subclass of DestinyItemQuantity, that provides not just the item and its quantity but also information that BNet can - at some point - use internally to provide more robust runtime information about the item's qualities.
/// <para />
///     If you want it, please ask! We're just out of time to wire it up right now. Or a clever person just may do it with our existing endpoints.
/// </summary>
public sealed class DestinyMilestoneQuestRewardItem
{
    /// <summary>
    ///     The quest reward item *may* be associated with a vendor. If so, this is that vendor. Use this hash to look up the DestinyVendorDefinition.
    /// </summary>
    [JsonPropertyName("vendorHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyVendorDefinition> VendorHash { get; init; }

    /// <summary>
    ///     The quest reward item *may* be associated with a vendor. If so, this is the index of the item being sold, which we can use at runtime to find instanced item information for the reward item.
    /// </summary>
    [JsonPropertyName("vendorItemIndex")]
    public int? VendorItemIndex { get; init; }

    /// <summary>
    ///     The hash identifier for the item in question. Use it to look up the item's DestinyInventoryItemDefinition.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition> ItemHash { get; init; }

    /// <summary>
    ///     If this quantity is referring to a specific instance of an item, this will have the item's instance ID. Normally, this will be null.
    /// </summary>
    [JsonPropertyName("itemInstanceId")]
    public long? ItemInstanceId { get; init; }

    /// <summary>
    ///     The amount of the item needed/available depending on the context of where DestinyItemQuantity is being used.
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    /// <summary>
    ///     Indicates that this item quantity may be conditionally shown or hidden, based on various sources of state. For example: server flags, account state, or character progress.
    /// </summary>
    [JsonPropertyName("hasConditionalVisibility")]
    public bool HasConditionalVisibility { get; init; }
}
