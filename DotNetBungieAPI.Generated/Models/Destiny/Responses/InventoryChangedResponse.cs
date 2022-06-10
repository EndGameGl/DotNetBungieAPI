namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

/// <summary>
///     A response containing all of the components for all requested vendors.
/// </summary>
public class InventoryChangedResponse
{
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
}
