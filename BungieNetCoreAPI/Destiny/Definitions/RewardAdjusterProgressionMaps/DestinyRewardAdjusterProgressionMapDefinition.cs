using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardAdjusterProgressionMaps
{
    [DestinyDefinition(name: "DestinyRewardAdjusterProgressionMapDefinition", presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyRewardAdjusterProgressionMapDefinition : DestinyDefinition
    {
        public bool IsAdditive { get; }
        [JsonConstructor]
        private DestinyRewardAdjusterProgressionMapDefinition(bool isAdditive, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            IsAdditive = isAdditive;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
