using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardAdjusterPointers
{
    [DestinyDefinition("DestinyRewardAdjusterPointerDefinition")]
    public class DestinyRewardAdjusterPointerDefinition : DestinyDefinition
    {
        public int AdjusterType { get; }
        [JsonConstructor]
        private DestinyRewardAdjusterPointerDefinition(int adjusterType, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            AdjusterType = adjusterType;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
