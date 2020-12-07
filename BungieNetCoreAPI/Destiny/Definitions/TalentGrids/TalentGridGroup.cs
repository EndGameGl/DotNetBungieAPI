using BungieNetCoreAPI.Destiny.Definitions.Lores;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.TalentGrids
{
    public class TalentGridGroup
    {
        public uint GroupHash { get; }
        public DefinitionHashPointer<DestinyLoreDefinition> Lore { get; }
        public List<uint> NodeHashes { get; }
        public List<uint> OpposingGroupHashes { get; }
        public List<uint> OpposingNodeHashes { get; }

        [JsonConstructor]
        private TalentGridGroup(uint groupHash, uint loreHash, List<uint> nodeHashes, List<uint> opposingGroupHashes, List<uint> opposingNodeHashes)
        {
            GroupHash = groupHash;
            Lore = new DefinitionHashPointer<DestinyLoreDefinition>(loreHash, "DestinyLoreDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            NodeHashes = nodeHashes;
            OpposingGroupHashes = opposingGroupHashes;
            OpposingNodeHashes = opposingNodeHashes;
        }
    }
}
