using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     Used in a number of Destiny contracts to return data about an item stack and its quantity. Can optionally return an
///     itemInstanceId if the item is instanced - in which case, the quantity returned will be 1.
/// </summary>
public record DestinyItemQuantity : IDeepEquatable<DestinyItemQuantity>
{
    /// <summary>
    ///     Item in question.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    /// <summary>
    ///     If this quantity is referring to a specific instance of an item, this will have the item's instance ID. Normally,
    ///     this will be null.
    /// </summary>
    [JsonPropertyName("itemInstanceId")]
    public long? ItemInstanceId { get; init; }

    /// <summary>
    ///     The amount of the item needed/available depending on the context of where DestinyItemQuantity is being used.
    /// </summary>
    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }

    /// <summary>
    ///     Indicates that this item quantity may be conditionally shown or hidden, based on various sources of state. For
    ///     example: server flags, account state, or character progress.
    /// </summary>
    [JsonPropertyName("hasConditionalVisibility")]
    public bool HasConditionalVisibility { get; init; }

    public bool DeepEquals(DestinyItemQuantity other)
    {
        return other is not null &&
               Item.DeepEquals(other.Item) &&
               Quantity == other.Quantity &&
               ItemInstanceId == other.ItemInstanceId &&
               HasConditionalVisibility == other.HasConditionalVisibility;
    }
}