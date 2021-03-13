using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Progressions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.TalentGrids
{
    [DestinyDefinition(DefinitionsEnum.DestinyTalentGridDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyTalentGridDefinition : IDestinyDefinition, IDeepEquatable<DestinyTalentGridDefinition>
    {
        public ReadOnlyCollection<TalentNodeExclusiveSet> ExclusiveSets { get; }
        public int CalcMaxGridLevel { get; }
        public int CalcProgressToMaxLevel { get; }
        public int GridLevelPerColumn { get; }
        public ReadOnlyDictionary<uint, TalentGridGroup> Groups { get; }
        public ReadOnlyCollection<int> IndependentNodeIndexes { get; }
        public int MaxGridLevel { get; }
        public int MaximumRandomMaterialRequirements { get; }
        public ReadOnlyCollection<TalentGridNodeCategory> NodeCategories { get; }
        public ReadOnlyCollection<TalentGridNode> Nodes { get; }
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyTalentGridDefinition(int calcMaxGridLevel, int calcProgressToMaxLevel, int gridLevelPerColumn,
            Dictionary<uint, TalentGridGroup> groups, int[] independentNodeIndexes, int maxGridLevel, int maximumRandomMaterialRequirements, 
            TalentGridNodeCategory[] nodeCategories, TalentGridNode[] nodes, uint progressionHash, TalentNodeExclusiveSet[] exclusiveSets,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            CalcMaxGridLevel = calcMaxGridLevel;
            CalcProgressToMaxLevel = calcProgressToMaxLevel;
            ExclusiveSets = exclusiveSets.AsReadOnlyOrEmpty();
            GridLevelPerColumn = gridLevelPerColumn;
            Groups = groups.AsReadOnlyDictionaryOrEmpty();
            IndependentNodeIndexes = independentNodeIndexes.AsReadOnlyOrEmpty();
            MaxGridLevel = maxGridLevel;
            MaximumRandomMaterialRequirements = maximumRandomMaterialRequirements;
            NodeCategories = nodeCategories.AsReadOnlyOrEmpty();
            Nodes = nodes.AsReadOnlyOrEmpty();
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

        public void MapValues()
        {
            foreach (var groupValue in Groups.Values)
            {
                groupValue.Lore.TryMapValue();
            }
            Progression.TryMapValue();
            foreach (var node in Nodes)
            {
                node.Lore.TryMapValue();
                if (node.RandomActivationRequirement != null)
                {
                    foreach (var req in node.RandomActivationRequirement.MaterialRequirements)
                    {
                        req.TryMapValue();
                    }
                }
                foreach (var nodeStep in node.Steps)
                {
                    nodeStep.DamageType.TryMapValue();
                    foreach (var req in nodeStep.ActivationRequirement?.MaterialRequirements)
                    {
                        req.TryMapValue();
                    }
                    foreach (var perk in nodeStep.Perks)
                    {
                        perk.TryMapValue();
                    }
                    foreach (var stat in nodeStep.Stats)
                    {
                        stat.TryMapValue();
                    }
                    foreach (var replacement in nodeStep.SocketReplacements)
                    {
                        replacement.PlugItem.TryMapValue();
                        replacement.SocketType.TryMapValue();
                    }
                }
            }
        }

        public bool DeepEquals(DestinyTalentGridDefinition other)
        {
            return other != null &&
                   ExclusiveSets.DeepEqualsReadOnlyCollections(other.ExclusiveSets) &&
                   CalcMaxGridLevel == other.CalcMaxGridLevel &&
                   CalcProgressToMaxLevel == other.CalcProgressToMaxLevel &&
                   GridLevelPerColumn == other.GridLevelPerColumn &&
                   Groups.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndEquatableValue(other.Groups) &&
                   IndependentNodeIndexes.DeepEqualsReadOnlySimpleCollection(other.IndependentNodeIndexes) &&
                   MaxGridLevel == other.MaxGridLevel &&
                   MaximumRandomMaterialRequirements == other.MaximumRandomMaterialRequirements &&
                   NodeCategories.DeepEqualsReadOnlyCollections(other.NodeCategories) &&
                   Nodes.DeepEqualsReadOnlyCollections(other.Nodes) &&
                   Progression.DeepEquals(other.Progression) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
