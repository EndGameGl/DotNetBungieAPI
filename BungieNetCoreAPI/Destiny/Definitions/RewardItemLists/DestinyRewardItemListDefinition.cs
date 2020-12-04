using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.RewardItemLists
{
    /// <summary>
    /// Empty atm
    /// </summary>
    [DestinyDefinition("DestinyRewardItemListDefinition")]
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
