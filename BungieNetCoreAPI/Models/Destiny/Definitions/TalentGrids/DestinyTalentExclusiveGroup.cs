using NetBungieAPI.Models.Destiny.Definitions.Lores;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.TalentGrids
{
    public sealed record DestinyTalentExclusiveGroup : IDeepEquatable<DestinyTalentExclusiveGroup>
    {
        [JsonPropertyName("groupHash")]
        public uint GroupHash { get; init; }
        [JsonPropertyName("loreHash")]
        public DefinitionHashPointer<DestinyLoreDefinition> Lore { get; init; } = DefinitionHashPointer<DestinyLoreDefinition>.Empty;
        [JsonPropertyName("nodeHashes")]
        public ReadOnlyCollection<uint> NodeHashes { get; init; } = Defaults.EmptyReadOnlyCollection<uint>();
        [JsonPropertyName("opposingGroupHashes")]
        public ReadOnlyCollection<uint> OpposingGroupHashes { get; init; } = Defaults.EmptyReadOnlyCollection<uint>();
        [JsonPropertyName("opposingNodeHashes")]
        public ReadOnlyCollection<uint> OpposingNodeHashes { get; init; } = Defaults.EmptyReadOnlyCollection<uint>();

        public bool DeepEquals(DestinyTalentExclusiveGroup other)
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
