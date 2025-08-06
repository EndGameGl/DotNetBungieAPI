namespace DotNetBungieAPI.Models.Destiny.Responses;

public sealed class DestinyItemChangeResponse
{
    [JsonPropertyName("item")]
    public Destiny.Responses.DestinyItemResponse? Item { get; init; }

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
