using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Records
{
    public class RecordRequirements : IDeepEquatable<RecordRequirements>
    {
        public string EntitlementUnavailableMessage { get; init; }

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
