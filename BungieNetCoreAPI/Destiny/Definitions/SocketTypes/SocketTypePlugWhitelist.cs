using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.SocketTypes
{
    public class SocketTypePlugWhitelist : IDeepEquatable<SocketTypePlugWhitelist>
    {
        public uint CategoryHash { get; }
        public string CategoryIdentifier { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>> ReinitializationPossiblePlugs { get; }

        [JsonConstructor]
        internal SocketTypePlugWhitelist(uint categoryHash, string categoryIdentifier, uint[] reinitializationPossiblePlugHashes)
        {
            CategoryHash = categoryHash;
            CategoryIdentifier = categoryIdentifier;
            ReinitializationPossiblePlugs = reinitializationPossiblePlugHashes.DefinitionsAsReadOnlyOrEmpty<DestinyInventoryItemDefinition>(DefinitionsEnum.DestinyInventoryItemDefinition);
        }

        public bool DeepEquals(SocketTypePlugWhitelist other)
        {
            return other != null &&
                   CategoryHash == other.CategoryHash &&
                   CategoryIdentifier == other.CategoryIdentifier &&
                   ReinitializationPossiblePlugs.DeepEqualsReadOnlyCollections(other.ReinitializationPossiblePlugs);
        }
    }
}
