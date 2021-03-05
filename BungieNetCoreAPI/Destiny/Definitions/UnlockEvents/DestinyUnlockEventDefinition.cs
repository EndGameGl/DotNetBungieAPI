using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.UnlockValues;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockEvents
{
    /// <summary>
    /// Nothing usable atm
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyUnlockEventDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyUnlockEventDefinition : IDestinyDefinition
    {
        public DefinitionHashPointer<DestinyUnlockValueDefinition> SequenceLastUpdatedUnlockValue { get; }
        public DefinitionHashPointer<DestinyUnlockValueDefinition> SequenceUnlockValue { get; }
        public uint NewSequenceRewardSiteHash { get; }
        public List<UnlockEventUnlockEntry> UnlockEntries { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyUnlockEventDefinition(uint sequenceLastUpdatedUnlockValueHash, uint sequenceUnlockValueHash, uint newSequenceRewardSiteHash,
            List<UnlockEventUnlockEntry> unlockEntries, bool blacklisted, uint hash, int index, bool redacted)
        {
            SequenceLastUpdatedUnlockValue = new DefinitionHashPointer<DestinyUnlockValueDefinition>(sequenceLastUpdatedUnlockValueHash, DefinitionsEnum.DestinyUnlockValueDefinition);
            SequenceUnlockValue = new DefinitionHashPointer<DestinyUnlockValueDefinition>(sequenceUnlockValueHash, DefinitionsEnum.DestinyUnlockValueDefinition);
            NewSequenceRewardSiteHash = newSequenceRewardSiteHash;
            UnlockEntries = unlockEntries;
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
