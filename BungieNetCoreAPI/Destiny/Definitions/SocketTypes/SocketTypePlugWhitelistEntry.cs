using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.SocketTypes
{
    public class SocketTypePlugWhitelistEntry
    {
        public uint CategoryHash { get; }
        public string CategoryIdentifier { get; }
        public List<DefinitionHashPointer<DestinyInventoryItemDefinition>> ReinitializationPossiblePlugs { get; }

        [JsonConstructor]
        private SocketTypePlugWhitelistEntry(uint categoryHash, string categoryIdentifier, List<uint> reinitializationPossiblePlugHashes)
        {
            CategoryHash = categoryHash;
            CategoryIdentifier = categoryIdentifier;
            if (reinitializationPossiblePlugHashes != null)
            {
                ReinitializationPossiblePlugs = new List<DefinitionHashPointer<DestinyInventoryItemDefinition>>();
                foreach (var reinitializationPossiblePlugHash in reinitializationPossiblePlugHashes)
                {
                    ReinitializationPossiblePlugs.Add(new DefinitionHashPointer<DestinyInventoryItemDefinition>(reinitializationPossiblePlugHash, DefinitionsEnum.DestinyInventoryItemDefinition));
                }
            }
        }
    }
}
