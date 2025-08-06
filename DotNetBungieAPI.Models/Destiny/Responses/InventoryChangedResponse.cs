namespace DotNetBungieAPI.Models.Destiny.Responses;

/// <summary>
///     A response containing all of the components for all requested vendors.
/// </summary>
public sealed class InventoryChangedResponse
{
    /// <summary>
    ///     Items that appeared in the inventory possibly as a result of an action.
    /// </summary>
    [JsonPropertyName("addedInventoryItems")]
    public Destiny.Entities.Items.DestinyItemComponent[]? AddedInventoryItems { get; init; }

    /// <summary>
    ///     Items that disappeared from the inventory possibly as a result of an action.
    /// </summary>
    [JsonPropertyName("removedInventoryItems")]
    public Destiny.Entities.Items.DestinyItemComponent[]? RemovedInventoryItems { get; init; }
}
