using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Inventory;

public sealed class DestinyInventoryComponent
{

    [JsonPropertyName("items")]
    public List<Destiny.Entities.Items.DestinyItemComponent> Items { get; init; }
}
