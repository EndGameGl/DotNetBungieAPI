using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.SandboxPerks;
using BungieNetCoreAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.NodeStepSummaries
{
    [DestinyDefinition("DestinyNodeStepSummaryDefinition")]
    public class DestinyNodeStepSummaryDefinition : DestinyDefinition
    {
        public uint NodeStepHash { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public List<DefinitionHashPointer<DestinySandboxPerkDefinition>> Perks { get; }
        public List<DefinitionHashPointer<DestinyStatDefinition>> Stats { get; }
        public bool AffectsQuality { get; }

        [JsonConstructor]
        private DestinyNodeStepSummaryDefinition(DestinyDefinitionDisplayProperties displayProperties, uint nodeStepHash, List<uint> perkHashes, List<uint> statHashes,
            bool affectsQuality, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            NodeStepHash = nodeStepHash;
            Perks = new List<DefinitionHashPointer<DestinySandboxPerkDefinition>>();
            if (perkHashes != null)
            {
                foreach (var perkHash in perkHashes)
                {
                    Perks.Add(new DefinitionHashPointer<DestinySandboxPerkDefinition>(perkHash, "DestinySandboxPerkDefinition"));
                }
            }
            Stats = new List<DefinitionHashPointer<DestinyStatDefinition>>();
            if (statHashes != null)
            {
                foreach (var statHash in statHashes)
                {
                    Stats.Add(new DefinitionHashPointer<DestinyStatDefinition>(statHash, "DestinyStatDefinition"));
                }
            }
            AffectsQuality = affectsQuality;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
