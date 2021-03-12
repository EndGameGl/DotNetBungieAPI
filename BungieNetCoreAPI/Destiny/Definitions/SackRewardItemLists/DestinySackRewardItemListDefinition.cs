using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.SackRewardItemLists
{
    /// <summary>
    /// Empty definition
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinySackRewardItemListDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinySackRewardItemListDefinition : IDestinyDefinition, IDeepEquatable<DestinySackRewardItemListDefinition>
    {
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinySackRewardItemListDefinition(bool blacklisted, uint hash, int index, bool redacted) 
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
        public bool DeepEquals(DestinySackRewardItemListDefinition other)
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
