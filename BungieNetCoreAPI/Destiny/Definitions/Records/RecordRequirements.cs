using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    public class RecordRequirements : IDeepEquatable<RecordRequirements>
    {
        public string EntitlementUnavailableMessage { get; }

        [JsonConstructor]
        internal RecordRequirements(string entitlementUnavailableMessage)
        {
            EntitlementUnavailableMessage = entitlementUnavailableMessage;
        }

        public bool DeepEquals(RecordRequirements other)
        {
            return other != null &&
                   EntitlementUnavailableMessage == other.EntitlementUnavailableMessage;
        }
    }
}
