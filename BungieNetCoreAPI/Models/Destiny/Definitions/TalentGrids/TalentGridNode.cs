using NetBungieAPI.Destiny.Definitions.Lores;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.TalentGrids
{
    public class TalentGridNode : IDeepEquatable<TalentGridNode>
    {
        public int NodeIndex { get; init; }
        public uint NodeHash { get; init; }
        public int Row { get; init; }
        public int Column { get; init; }
        public ReadOnlyCollection<int> PrerequisiteNodeIndexes { get; init; }
        public int BinaryPairNodeIndex { get; init; }
        public bool AutoUnlocks { get; init; }
        public bool LastStepRepeats { get; init; }
        public bool IsRandom { get; init; }
        public NodeActivationRequirement RandomActivationRequirement { get; init; }
        public bool IsRandomRepurchasable { get; init; }
        public ReadOnlyCollection<TalentGridNodeStep> Steps { get; init; }
        public ReadOnlyCollection<uint> ExclusiveWithNodeHashes { get; init; }
        public int RandomStartProgressionBarAtProgression { get; init; }     
        public string LayoutIdentifier { get; init; }
        public uint? GroupHash { get; init; }
        public DefinitionHashPointer<DestinyLoreDefinition> Lore { get; init; }
        public string NodeStyleIdentifier { get; init; }
        public bool IgnoreForCompletion { get; init; }
        public uint ExclusiveSetHash { get; init; }
        public int GroupScopeIndex { get; init; }
        public bool IsRealStepSelectionRandom { get; init; }
        public uint OriginalNodeHash { get; init; }
        public int TalentNodeTypes { get; init; }

        [JsonConstructor]
        internal TalentGridNode(bool autoUnlocks, int binaryPairNodeIndex, int column, uint exclusiveSetHash, uint? groupHash, int groupScopeIndex, bool ignoreForCompletion,
            bool isRandom, bool isRandomRepurchasable, bool isRealStepSelectionRandom, bool lastStepRepeats, string layoutIdentifier, uint loreHash, uint nodeHash,
            int nodeIndex, string nodeStyleIdentifier, uint originalNodeHash, int[] prerequisiteNodeIndexes, int randomStartProgressionBarAtProgression, int row,
            TalentGridNodeStep[] steps, int talentNodeTypes, NodeActivationRequirement randomActivationRequirement, uint[] exclusiveWithNodeHashes)
        {
            AutoUnlocks = autoUnlocks;
            BinaryPairNodeIndex = binaryPairNodeIndex;
            Column = column;
            ExclusiveSetHash = exclusiveSetHash;
            GroupHash = groupHash;
            GroupScopeIndex = groupScopeIndex;
            IgnoreForCompletion = ignoreForCompletion;
            IsRandom = isRandom;
            IsRandomRepurchasable = isRandomRepurchasable;
            IsRealStepSelectionRandom = isRealStepSelectionRandom;
            LastStepRepeats = lastStepRepeats;
            LayoutIdentifier = layoutIdentifier;
            Lore = new DefinitionHashPointer<DestinyLoreDefinition>(loreHash, DefinitionsEnum.DestinyLoreDefinition);
            NodeHash = nodeHash;
            NodeIndex = nodeIndex;
            NodeStyleIdentifier = nodeStyleIdentifier;
            OriginalNodeHash = originalNodeHash;
            PrerequisiteNodeIndexes = prerequisiteNodeIndexes.AsReadOnlyOrEmpty();
            RandomStartProgressionBarAtProgression = randomStartProgressionBarAtProgression;
            Row = row;
            Steps = steps.AsReadOnlyOrEmpty();
            TalentNodeTypes = talentNodeTypes;
            RandomActivationRequirement = randomActivationRequirement;
            ExclusiveWithNodeHashes = exclusiveWithNodeHashes.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(TalentGridNode other)
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
