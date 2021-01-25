using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Progressions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.TalentGrids
{
    [DestinyDefinition(name: "DestinyTalentGridDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyTalentGridDefinition : IDestinyDefinition
    {
        //public List<object> ExclusiveSets { get; }
        public int CalcMaxGridLevel { get; }
        public int CalcProgressToMaxLevel { get; }
        public int GridLevelPerColumn { get; }
        public Dictionary<uint, TalentGridGroup> Groups { get; }
        public List<int> IndependentNodeIndexes { get; }
        public int MaxGridLevel { get; }
        public int MaximumRandomMaterialRequirements { get; }
        public List<TalentGridNodeCategory> NodeCategories { get; }
        public List<TalentGridNode> Nodes { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyTalentGridDefinition(int calcMaxGridLevel, int calcProgressToMaxLevel, int gridLevelPerColumn,
            Dictionary<uint, TalentGridGroup> groups, List<int> independentNodeIndexes, int maxGridLevel, int maximumRandomMaterialRequirements, 
            List<TalentGridNodeCategory> nodeCategories, List<TalentGridNode> nodes, uint progressionHash, //, List<object> exclusiveSets
            bool blacklisted, uint hash, int index, bool redacted)
        {
            CalcMaxGridLevel = calcMaxGridLevel;
            CalcProgressToMaxLevel = calcProgressToMaxLevel;
            //ExclusiveSets = exclusiveSets;
            GridLevelPerColumn = gridLevelPerColumn;
            Groups = groups;
            IndependentNodeIndexes = independentNodeIndexes;
            MaxGridLevel = maxGridLevel;
            MaximumRandomMaterialRequirements = maximumRandomMaterialRequirements;
            NodeCategories = nodeCategories;
            Nodes = nodes;
            Progression = new DefinitionHashPointer<DestinyProgressionDefinition>(progressionHash, DefinitionsEnum.DestinyProgressionDefinition);
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
