using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ReportReasonCategories
{
    public class ReportReasonEntry
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public uint ReasonHash { get; }

        [JsonConstructor]
        private ReportReasonEntry(DestinyDefinitionDisplayProperties displayProperties, uint reasonHash)
        {
            DisplayProperties = displayProperties;
            ReasonHash = reasonHash;
        }
    }
}
