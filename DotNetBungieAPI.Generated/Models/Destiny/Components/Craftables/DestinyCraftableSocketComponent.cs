namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Craftables;

public class DestinyCraftableSocketComponent
{
    [Destiny2Definition<Destiny.Definitions.Sockets.DestinyPlugSetDefinition>("Destiny.Definitions.Sockets.DestinyPlugSetDefinition")]
    [JsonPropertyName("plugSetHash")]
    public uint? PlugSetHash { get; set; }

    /// <summary>
    ///     Unlock state for plugs in the socket plug set definition
    /// </summary>
    [JsonPropertyName("plugs")]
    public List<Destiny.Components.Craftables.DestinyCraftableSocketPlugComponent> Plugs { get; set; }
}
