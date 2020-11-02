using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Collectibles
{
    public class CollectibleStateInfo
    {
        public CollectibleStateInfoRequirements Requirements { get; }

        [JsonConstructor]
        private CollectibleStateInfo(CollectibleStateInfoRequirements requirements)
        {
            Requirements = requirements;
        }
    }
}
