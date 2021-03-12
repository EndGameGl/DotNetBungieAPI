using BungieNetCoreAPI.Destiny.Definitions.Lores;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.TalentGrids
{
    public class TalentGridNode : IDeepEquatable<TalentGridNode>
    {
        public int NodeIndex { get; }
        public uint NodeHash { get; }
        public int Row { get; }
        public int Column { get; }
        public ReadOnlyCollection<int> PrerequisiteNodeIndexes { get; }
        public int BinaryPairNodeIndex { get; }
        public bool AutoUnlocks { get; }
        public bool LastStepRepeats { get; }
        public bool IsRandom { get; }
        public NodeActivationRequirement RandomActivationRequirement { get; }
        public bool IsRandomRepurchasable { get; }
        public ReadOnlyCollection<TalentGridNodeStep> Steps { get; }
        public ReadOnlyCollection<uint> ExclusiveWithNodeHashes { get; }
        public int RandomStartProgressionBarAtProgression { get; }     
        public string LayoutIdentifier { get; }
        public uint? GroupHash { get; }
        public DefinitionHashPointer<DestinyLoreDefinition> Lore { get; }
        public string NodeStyleIdentifier { get; }
        public bool IgnoreForCompletion { get; }
        public uint ExclusiveSetHash { get; }
        public int GroupScopeIndex { get; }
        public bool IsRealStepSelectionRandom { get; }
        public uint OriginalNodeHash { get; }
        public int TalentNodeTypes { get; }

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
