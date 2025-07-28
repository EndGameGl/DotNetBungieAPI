namespace DotNetBungieAPI.Generated.Models.Destiny.Components.PlugSets;

/// <summary>
///     Sockets may refer to a "Plug Set": a set of reusable plugs that may be shared across multiple sockets (or even, in theory, multiple sockets over multiple items).
/// <para />
///     This is the set of those plugs that we came across in the users' inventory, along with the values for plugs in the set. Any given set in this component may be represented in Character and Profile-level, as some plugs may be Profile-level restricted, and some character-level restricted. (note that the ones that are even more specific will remain on the actual socket component itself, as they cannot be reused)
/// </summary>
public class DestinyPlugSetsComponent
{
    /// <summary>
    ///     The shared list of plugs for each relevant PlugSet, keyed by the hash identifier of the PlugSet (DestinyPlugSetDefinition).
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Sockets.DestinyPlugSetDefinition>("Destiny.Definitions.Sockets.DestinyPlugSetDefinition")]
    [JsonPropertyName("plugs")]
    public Dictionary<uint, Destiny.Sockets.DestinyItemPlug[]>? Plugs { get; set; }
}
