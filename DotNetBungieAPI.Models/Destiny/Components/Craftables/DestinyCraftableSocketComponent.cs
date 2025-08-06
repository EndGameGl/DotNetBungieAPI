namespace DotNetBungieAPI.Models.Destiny.Components.Craftables;

public sealed class DestinyCraftableSocketComponent
{
    [JsonPropertyName("plugSetHash")]
    public DefinitionHashPointer<Destiny.Definitions.Sockets.DestinyPlugSetDefinition> PlugSetHash { get; init; }

    /// <summary>
    ///     Unlock state for plugs in the socket plug set definition
    /// </summary>
    [JsonPropertyName("plugs")]
    public Destiny.Components.Craftables.DestinyCraftableSocketPlugComponent[]? Plugs { get; init; }
}
