using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.PresentationNodes
{
    public class PresentationNodeRequirement
    {
        public string EntitlementUnavailableMessage { get; }

        [JsonConstructor]
        private PresentationNodeRequirement(string entitlementUnavailableMessage) 
        {
            EntitlementUnavailableMessage = entitlementUnavailableMessage;
        }
    }
}
