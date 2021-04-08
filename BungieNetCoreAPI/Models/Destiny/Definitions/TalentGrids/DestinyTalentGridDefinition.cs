using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Progressions;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.TalentGrids
{
    [DestinyDefinition(DefinitionsEnum.DestinyTalentGridDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinyTalentGridDefinition : IDestinyDefinition, IDeepEquatable<DestinyTalentGridDefinition>
    {
        [JsonPropertyName("maxGridLevel")]
        public int MaxGridLevel { get; init; }
        [JsonPropertyName("gridLevelPerColumn")]
        public int GridLevelPerColumn { get; init; }
        [JsonPropertyName("progressionHash")]
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; init; } = DefinitionHashPointer<DestinyProgressionDefinition>.Empty;
        [JsonPropertyName("nodes")]
        public ReadOnlyCollection<DestinyTalentNodeDefinition> Nodes { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyTalentNodeDefinition>();
        [JsonPropertyName("exclusiveSets")]
        public ReadOnlyCollection<DestinyTalentNodeExclusiveSetDefinition> ExclusiveSets { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyTalentNodeExclusiveSetDefinition>();
        [JsonPropertyName("independentNodeIndexes")]
        public ReadOnlyCollection<int> IndependentNodeIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();
        [JsonPropertyName("groups")]
        public ReadOnlyDictionary<uint, DestinyTalentExclusiveGroup> Groups { get; init; } = Defaults.EmptyReadOnlyDictionary<uint, DestinyTalentExclusiveGroup>();
        [JsonPropertyName("nodeCategories")]
        public ReadOnlyCollection<TalentGridNodeCategory> NodeCategories { get; init; } = Defaults.EmptyReadOnlyCollection<TalentGridNodeCategory>();
        [JsonPropertyName("calcMaxGridLevel")]
        public int CalcMaxGridLevel { get; init; }
        [JsonPropertyName("calcProgressToMaxLevel")]
        public int CalcProgressToMaxLevel { get; init; }
        [JsonPropertyName("maximumRandomMaterialRequirements")]
        public int MaximumRandomMaterialRequirements { get; init; }
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

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
