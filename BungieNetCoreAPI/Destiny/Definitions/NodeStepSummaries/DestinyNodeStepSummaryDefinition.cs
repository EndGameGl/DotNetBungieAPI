using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.SandboxPerks;
using BungieNetCoreAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.NodeStepSummaries
{
    [DestinyDefinition(DefinitionsEnum.DestinyNodeStepSummaryDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyNodeStepSummaryDefinition : IDestinyDefinition, IDeepEquatable<DestinyNodeStepSummaryDefinition>
    {
        public uint NodeStepHash { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinySandboxPerkDefinition>> Perks { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyStatDefinition>> Stats { get; }
        public bool AffectsQuality { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyNodeStepSummaryDefinition(DestinyDefinitionDisplayProperties displayProperties, uint nodeStepHash, uint[] perkHashes, uint[] statHashes,
            bool affectsQuality, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            NodeStepHash = nodeStepHash;
            Perks = perkHashes.DefinitionsAsReadOnlyOrEmpty<DestinySandboxPerkDefinition>(DefinitionsEnum.DestinySandboxPerkDefinition);
            Stats = statHashes.DefinitionsAsReadOnlyOrEmpty<DestinyStatDefinition>(DefinitionsEnum.DestinyStatDefinition);
            AffectsQuality = affectsQuality;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyNodeStepSummaryDefinition other)
        {
            return other != null &&
                   NodeStepHash == other.NodeStepHash &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Perks.DeepEqualsReadOnlyCollections(other.Perks) &&
                   Stats.DeepEqualsReadOnlyCollections(other.Stats) &&
                   AffectsQuality == other.AffectsQuality &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
