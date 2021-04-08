using NetBungieAPI.Models.Destiny.Definitions.Lores;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.TalentGrids
{
    public sealed record DestinyTalentNodeDefinition : IDeepEquatable<DestinyTalentNodeDefinition>
    {
        [JsonPropertyName("nodeIndex")]
        public int NodeIndex { get; init; }
        [JsonPropertyName("nodeHash")]
        public uint NodeHash { get; init; }
        [JsonPropertyName("row")]
        public int Row { get; init; }
        [JsonPropertyName("column")]
        public int Column { get; init; }
        [JsonPropertyName("prerequisiteNodeIndexes")]
        public ReadOnlyCollection<int> PrerequisiteNodeIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();
        [JsonPropertyName("binaryPairNodeIndex")]
        public int BinaryPairNodeIndex { get; init; }
        [JsonPropertyName("autoUnlocks")]
        public bool AutoUnlocks { get; init; }
        [JsonPropertyName("lastStepRepeats")]
        public bool LastStepRepeats { get; init; }
        [JsonPropertyName("isRandom")]
        public bool IsRandom { get; init; }
        [JsonPropertyName("randomActivationRequirement")]
        public DestinyNodeActivationRequirement RandomActivationRequirement { get; init; }
        [JsonPropertyName("isRandomRepurchasable")]
        public bool IsRandomRepurchasable { get; init; }
        [JsonPropertyName("steps")]
        public ReadOnlyCollection<DestinyNodeStepDefinition> Steps { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyNodeStepDefinition>();
        [JsonPropertyName("exclusiveWithNodeHashes")]
        public ReadOnlyCollection<uint> ExclusiveWithNodeHashes { get; init; } = Defaults.EmptyReadOnlyCollection<uint>();
        [JsonPropertyName("randomStartProgressionBarAtProgression")]
        public int RandomStartProgressionBarAtProgression { get; init; }
        [JsonPropertyName("layoutIdentifier")]
        public string LayoutIdentifier { get; init; }
        [JsonPropertyName("groupHash")]
        public uint? GroupHash { get; init; }
        [JsonPropertyName("loreHash")]
        public DefinitionHashPointer<DestinyLoreDefinition> Lore { get; init; } = DefinitionHashPointer<DestinyLoreDefinition>.Empty;
        [JsonPropertyName("nodeStyleIdentifier")]
        public string NodeStyleIdentifier { get; init; }
        [JsonPropertyName("ignoreForCompletion")]
        public bool IgnoreForCompletion { get; init; }
        [JsonPropertyName("exclusiveSetHash")]
        public uint ExclusiveSetHash { get; init; }
        [JsonPropertyName("groupScopeIndex")]
        public int GroupScopeIndex { get; init; }
        [JsonPropertyName("isRealStepSelectionRandom")]
        public bool IsRealStepSelectionRandom { get; init; }
        [JsonPropertyName("originalNodeHash")]
        public uint OriginalNodeHash { get; init; }
        [JsonPropertyName("talentNodeTypes")]
        public int TalentNodeTypes { get; init; }

        public bool DeepEquals(DestinyTalentNodeDefinition other)
        {
            return other != null &&
                   NodeIndex == other.NodeIndex &&
                   NodeHash == other.NodeHash &&
                   Row == other.Row &&
                   Column == other.Column &&
                   PrerequisiteNodeIndexes.DeepEqualsReadOnlySimpleCollection(other.PrerequisiteNodeIndexes) &&
                   BinaryPairNodeIndex == other.BinaryPairNodeIndex &&
                   AutoUnlocks == other.AutoUnlocks &&
                   LastStepRepeats == other.LastStepRepeats &&
                   IsRandom == other.IsRandom &&
                   RandomActivationRequirement.DeepEquals(other.RandomActivationRequirement) &&
                   IsRandomRepurchasable == other.IsRandomRepurchasable &&
                   Steps.DeepEqualsReadOnlyCollections(other.Steps) &&
                   ExclusiveWithNodeHashes.DeepEqualsReadOnlySimpleCollection(other.ExclusiveWithNodeHashes) &&
                   RandomStartProgressionBarAtProgression == other.RandomStartProgressionBarAtProgression &&
                   LayoutIdentifier == other.LayoutIdentifier &&
                   GroupHash == other.GroupHash &&
                   Lore.DeepEquals(other.Lore) &&
                   NodeStyleIdentifier == other.NodeStyleIdentifier &&
                   IgnoreForCompletion == other.IgnoreForCompletion &&
                   ExclusiveSetHash == other.ExclusiveSetHash &&
                   GroupScopeIndex == other.GroupScopeIndex &&
                   IsRealStepSelectionRandom == other.IsRealStepSelectionRandom &&
                   OriginalNodeHash == other.OriginalNodeHash &&
                   TalentNodeTypes == other.TalentNodeTypes;
        }
    }
}
