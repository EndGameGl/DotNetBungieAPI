using NetBungieApi.Attributes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.RewardItemLists
{
    /// <summary>
    /// Empty atm
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyRewardItemListDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyRewardItemListDefinition : IDestinyDefinition, IDeepEquatable<DestinyRewardItemListDefinition>
    {
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyRewardItemListDefinition(bool blacklisted, uint hash, int index, bool redacted) 
        {
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }

        public bool DeepEquals(DestinyRewardItemListDefinition other)
        {
            return other != null &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public void MapValues()
        {
            return;
        }
    }
}
