using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Items;

public sealed class DestinyItemReusablePlugsComponent
{

    [JsonPropertyName("plugs")]
    public Dictionary<int, List<Destiny.Sockets.DestinyItemPlugBase>> Plugs { get; init; }
}
