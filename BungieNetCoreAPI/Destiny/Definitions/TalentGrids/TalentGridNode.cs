using BungieNetCoreAPI.Destiny.Definitions.Lores;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.TalentGrids
{
    public class TalentGridNode
    {
        public bool AutoUnlocks { get; }
        public int BinaryPairNodeIndex { get; }
        public int Column { get; }
        public uint ExclusiveSetHash { get; }
        public uint GroupHash { get; }
        public int GroupScopeIndex { get; }
        public bool IgnoreForCompletion { get; }
        public bool IsRandom { get; }
        public bool IsRandomRepurchasable { get; }
        public bool IsRealStepSelectionRandom { get; }
        public bool LastStepRepeats { get; }
        public string LayoutIdentifier { get; }
        public DefinitionHashPointer<DestinyLoreDefinition> Lore { get; }
        public uint NodeHash { get; }
        public int NodeIndex { get; }
        public string NodeStyleIdentifier { get; }
        public uint OriginalNodeHash { get; }
        public List<int> PrerequisiteNodeIndexes { get; }
        public int RandomStartProgressionBarAtProgression { get; }
        public int Row { get; }
        public List<TalentGridNodeStep> Steps { get; }
        public int TalentNodeTypes { get; }

        [JsonConstructor]
        private TalentGridNode(bool autoUnlocks, int binaryPairNodeIndex, int column, uint exclusiveSetHash, uint groupHash, int groupScopeIndex, bool ignoreForCompletion,
            bool isRandom, bool isRandomRepurchasable, bool isRealStepSelectionRandom, bool lastStepRepeats, string layoutIdentifier, uint loreHash, uint nodeHash,
            int nodeIndex, string nodeStyleIdentifier, uint originalNodeHash, List<int> prerequisiteNodeIndexes, int randomStartProgressionBarAtProgression, int row,
            List<TalentGridNodeStep> steps, int talentNodeTypes)
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
            PrerequisiteNodeIndexes = prerequisiteNodeIndexes;
            RandomStartProgressionBarAtProgression = randomStartProgressionBarAtProgression;
            Row = row;
            Steps = steps;
            TalentNodeTypes = talentNodeTypes;
        }
    }
}
