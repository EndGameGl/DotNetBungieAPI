using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Collectibles
{
    /// <summary>
    /// Presentation nodes can be restricted by various requirements. This defines the rules of those requirements, and the message(s) to be shown if these requirements aren't met.
    /// </summary>
    public class CollectibleStateInfoRequirements : IDeepEquatable<CollectibleStateInfoRequirements>
    {
        /// <summary>
        /// If this node is not accessible due to Entitlements (for instance, you don't own the required game expansion), this is the message to show.
        /// </summary>
        public string EntitlementUnavailableMessage { get; }

        [JsonConstructor]
        internal CollectibleStateInfoRequirements(string entitlementUnavailableMessage)
        {
            EntitlementUnavailableMessage = entitlementUnavailableMessage;
        }

        public bool DeepEquals(CollectibleStateInfoRequirements other)
        {
            return other != null && 
                EntitlementUnavailableMessage == other.EntitlementUnavailableMessage;
        }
    }
}
