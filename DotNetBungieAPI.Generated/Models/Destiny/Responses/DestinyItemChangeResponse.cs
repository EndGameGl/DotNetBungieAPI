using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public sealed class DestinyItemChangeResponse
{

    [JsonPropertyName("item")]
    public Destiny.Responses.DestinyItemResponse Item { get; init; }

    [JsonPropertyName("addedInventoryItems")]
    public List<Destiny.Entities.Items.DestinyItemComponent> AddedInventoryItems { get; init; }

    [JsonPropertyName("removedInventoryItems")]
    public List<Destiny.Entities.Items.DestinyItemComponent> RemovedInventoryItems { get; init; }
}
