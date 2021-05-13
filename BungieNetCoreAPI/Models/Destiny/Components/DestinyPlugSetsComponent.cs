using NetBungieAPI.Models.Destiny.Definitions.PlugSets;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Sockets;

namespace NetBungieAPI.Models.Destiny.Components
{
    /// <summary>
    /// Sockets may refer to a "Plug Set": a set of reusable plugs that may be shared across multiple sockets (or even, in theory, multiple sockets over multiple items).
    /// <para/>
    /// This is the set of those plugs that we came across in the users' inventory, along with the values for plugs in the set. Any given set in this component may be represented in Character and Profile-level, as some plugs may be Profile-level restricted, and some character-level restricted. (note that the ones that are even more specific will remain on the actual socket component itself, as they cannot be reused)
    /// </summary>
    public sealed record DestinyPlugSetsComponent
    {
        /// <summary>
        /// The shared list of plugs for each relevant PlugSet, keyed by the hash identifier of the PlugSet (DestinyPlugSetDefinition).
        /// </summary>
        [JsonPropertyName("plugs")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyPlugSetDefinition>, ReadOnlyCollection<DestinyItemPlug>>
            Plugs { get; init; } =
            Defaults
                .EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyPlugSetDefinition>,
                    ReadOnlyCollection<DestinyItemPlug>>();
    }
}