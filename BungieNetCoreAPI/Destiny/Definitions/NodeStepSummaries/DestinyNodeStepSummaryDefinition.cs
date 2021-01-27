using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.SandboxPerks;
using BungieNetCoreAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.NodeStepSummaries
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyNodeStepSummaryDefinition, presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyNodeStepSummaryDefinition : IDestinyDefinition
    {
        public uint NodeStepHash { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public List<DefinitionHashPointer<DestinySandboxPerkDefinition>> Perks { get; }
        public List<DefinitionHashPointer<DestinyStatDefinition>> Stats { get; }
        public bool AffectsQuality { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyNodeStepSummaryDefinition(DestinyDefinitionDisplayProperties displayProperties, uint nodeStepHash, List<uint> perkHashes, List<uint> statHashes,
            bool affectsQuality, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            NodeStepHash = nodeStepHash;
            Perks = new List<DefinitionHashPointer<DestinySandboxPerkDefinition>>();
            if (perkHashes != null)
            {
                foreach (var perkHash in perkHashes)
                {
                    Perks.Add(new DefinitionHashPointer<DestinySandboxPerkDefinition>(perkHash, DefinitionsEnum.DestinySandboxPerkDefinition));
                }
            }
            Stats = new List<DefinitionHashPointer<DestinyStatDefinition>>();
            if (statHashes != null)
            {
                foreach (var statHash in statHashes)
                {
                    Stats.Add(new DefinitionHashPointer<DestinyStatDefinition>(statHash, DefinitionsEnum.DestinyStatDefinition));
                }
            }
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
    }
}
