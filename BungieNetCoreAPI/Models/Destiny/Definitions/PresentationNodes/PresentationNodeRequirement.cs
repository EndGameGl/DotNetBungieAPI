using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.PresentationNodes
{
    public class PresentationNodeRequirement : IDeepEquatable<PresentationNodeRequirement>
    {
        public string EntitlementUnavailableMessage { get; init; }

        [JsonConstructor]
        internal PresentationNodeRequirement(string entitlementUnavailableMessage) 
        {
            EntitlementUnavailableMessage = entitlementUnavailableMessage;
        }

        public bool DeepEquals(PresentationNodeRequirement other)
        {
            return other != null && EntitlementUnavailableMessage == other.EntitlementUnavailableMessage;
        }
    }
}
