namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public class DestinyItemChangeResponse
{
    [JsonPropertyName("item")]
    public Destiny.Responses.DestinyItemResponse? Item { get; set; }

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
