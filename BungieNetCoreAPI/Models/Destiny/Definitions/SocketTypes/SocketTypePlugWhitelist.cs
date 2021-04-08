using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.SocketTypes
{
    public class SocketTypePlugWhitelist : IDeepEquatable<SocketTypePlugWhitelist>
    {
        public uint CategoryHash { get; init; }
        public string CategoryIdentifier { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>> ReinitializationPossiblePlugs { get; init; }

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
