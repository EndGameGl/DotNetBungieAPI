using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Inventory;

public sealed class DestinyPlatformSilverComponent
{

    [JsonPropertyName("platformSilver")]
    public Dictionary<BungieMembershipType, Destiny.Entities.Items.DestinyItemComponent> PlatformSilver { get; init; }
}
