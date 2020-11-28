using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardItemLists
{
    public class DestinyRewardItemListDefinition : DestinyDefinition
    {
        [JsonConstructor]
        private DestinyRewardItemListDefinition(bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        { }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
