using NetBungieApi.Attributes;
using NetBungieApi.Destiny.Definitions.UnlockValues;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.UnlockEvents
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
        public ReadOnlyCollection<UnlockEventUnlock> UnlockEntries { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyUnlockEventDefinition(uint sequenceLastUpdatedUnlockValueHash, uint sequenceUnlockValueHash, uint newSequenceRewardSiteHash,
            UnlockEventUnlock[] unlockEntries, bool blacklisted, uint hash, int index, bool redacted)
        {
            SequenceLastUpdatedUnlockValue = new DefinitionHashPointer<DestinyUnlockValueDefinition>(sequenceLastUpdatedUnlockValueHash, DefinitionsEnum.DestinyUnlockValueDefinition);
            SequenceUnlockValue = new DefinitionHashPointer<DestinyUnlockValueDefinition>(sequenceUnlockValueHash, DefinitionsEnum.DestinyUnlockValueDefinition);
            NewSequenceRewardSiteHash = newSequenceRewardSiteHash;
            UnlockEntries = unlockEntries.AsReadOnlyOrEmpty();
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
            SequenceLastUpdatedUnlockValue.TryMapValue();
            SequenceUnlockValue.TryMapValue();
            foreach (var entry in UnlockEntries)
            {
                entry.Unlock.TryMapValue();
                entry.UnlockValue.TryMapValue();
            }
        }
    }
}
