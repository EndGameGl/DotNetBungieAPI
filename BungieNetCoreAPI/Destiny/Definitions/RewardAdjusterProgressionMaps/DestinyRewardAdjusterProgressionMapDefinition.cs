using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardAdjusterProgressionMaps
{
    [DestinyDefinition(name: "DestinyRewardAdjusterProgressionMapDefinition", presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyRewardAdjusterProgressionMapDefinition : IDestinyDefinition
    {
        public bool IsAdditive { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }
        [JsonConstructor]
        private DestinyRewardAdjusterProgressionMapDefinition(bool isAdditive, bool blacklisted, uint hash, int index, bool redacted)
        {
            IsAdditive = isAdditive;
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
