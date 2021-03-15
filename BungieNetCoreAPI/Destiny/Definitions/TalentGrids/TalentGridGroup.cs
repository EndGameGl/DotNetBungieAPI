using NetBungieAPI.Destiny.Definitions.Lores;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.TalentGrids
{
    public class TalentGridGroup : IDeepEquatable<TalentGridGroup>
    {
        public uint GroupHash { get; }
        public DefinitionHashPointer<DestinyLoreDefinition> Lore { get; }
        public ReadOnlyCollection<uint> NodeHashes { get; }
        public ReadOnlyCollection<uint> OpposingGroupHashes { get; }
        public ReadOnlyCollection<uint> OpposingNodeHashes { get; }

        [JsonConstructor]
        internal TalentGridGroup(uint groupHash, uint loreHash, uint[] nodeHashes, uint[] opposingGroupHashes, uint[] opposingNodeHashes)
        {
            GroupHash = groupHash;
            Lore = new DefinitionHashPointer<DestinyLoreDefinition>(loreHash, DefinitionsEnum.DestinyLoreDefinition);
            NodeHashes = nodeHashes.AsReadOnlyOrEmpty();
            OpposingGroupHashes = opposingGroupHashes.AsReadOnlyOrEmpty();
            OpposingNodeHashes = opposingNodeHashes.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(TalentGridGroup other)
        {
            return other != null &&
                   GroupHash == other.GroupHash &&
                   Lore.DeepEquals(other.Lore) &&
                   NodeHashes.DeepEqualsReadOnlySimpleCollection(other.NodeHashes) &&
                   OpposingGroupHashes.DeepEqualsReadOnlySimpleCollection(other.OpposingGroupHashes) &&
                   OpposingNodeHashes.DeepEqualsReadOnlySimpleCollection(other.OpposingNodeHashes);
        }
    }
}
