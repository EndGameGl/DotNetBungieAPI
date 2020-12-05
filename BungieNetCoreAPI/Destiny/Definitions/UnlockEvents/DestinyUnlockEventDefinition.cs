using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.UnlockValues;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockEvents
{
    /// <summary>
    /// Nothing usable atm
    /// </summary>
    [DestinyDefinition("DestinyUnlockEventDefinition")]
    public class DestinyUnlockEventDefinition : DestinyDefinition
    {
        public DefinitionHashPointer<DestinyUnlockValueDefinition> SequenceLastUpdatedUnlockValue { get; }
        public DefinitionHashPointer<DestinyUnlockValueDefinition> SequenceUnlockValue { get; }
        public uint NewSequenceRewardSiteHash { get; }
        public List<UnlockEventUnlockEntry> UnlockEntries { get; }

        [JsonConstructor]
        private DestinyUnlockEventDefinition(uint sequenceLastUpdatedUnlockValueHash, uint sequenceUnlockValueHash, uint newSequenceRewardSiteHash,
            List<UnlockEventUnlockEntry> unlockEntries, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            SequenceLastUpdatedUnlockValue = new DefinitionHashPointer<DestinyUnlockValueDefinition>(sequenceLastUpdatedUnlockValueHash, "DestinyUnlockValueDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            SequenceUnlockValue = new DefinitionHashPointer<DestinyUnlockValueDefinition>(sequenceUnlockValueHash, "DestinyUnlockValueDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            NewSequenceRewardSiteHash = newSequenceRewardSiteHash;
            UnlockEntries = unlockEntries;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
