using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    public class RecordRequirements
    {
        public string EntitlementUnavailableMessage { get; }

        [JsonConstructor]
        private RecordRequirements(string entitlementUnavailableMessage)
        {
            EntitlementUnavailableMessage = entitlementUnavailableMessage;
        }
    }
}
