using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

public sealed class InventoryChangedResponse
{

    [JsonPropertyName("addedInventoryItems")]
    public List<Destiny.Entities.Items.DestinyItemComponent> AddedInventoryItems { get; init; }

    [JsonPropertyName("removedInventoryItems")]
    public List<Destiny.Entities.Items.DestinyItemComponent> RemovedInventoryItems { get; init; }
}
