using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.PlugSets;

public sealed class DestinyPlugSetsComponent
{

    [JsonPropertyName("plugs")]
    public Dictionary<uint, List<Destiny.Sockets.DestinyItemPlug>> Plugs { get; init; }
}
