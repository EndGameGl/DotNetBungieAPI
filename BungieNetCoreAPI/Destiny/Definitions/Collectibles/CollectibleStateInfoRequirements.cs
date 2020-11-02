using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Collectibles
{
    public class CollectibleStateInfoRequirements
    {
        public string EntitlementUnavailableMessage { get; }

        [JsonConstructor]
        private CollectibleStateInfoRequirements(string entitlementUnavailableMessage)
        {
            EntitlementUnavailableMessage = entitlementUnavailableMessage;
        }
    }
}
