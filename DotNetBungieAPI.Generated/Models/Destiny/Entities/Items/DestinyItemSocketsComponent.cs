using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

public sealed class DestinyItemSocketsComponent
{

    [JsonPropertyName("sockets")]
    public List<Destiny.Entities.Items.DestinyItemSocketState> Sockets { get; init; }
}
