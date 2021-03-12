using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.ReportReasonCategories
{
    public class ReportReason : IDeepEquatable<ReportReason>
    {
        public uint ReasonHash { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }

        [JsonConstructor]
        internal ReportReason(DestinyDefinitionDisplayProperties displayProperties, uint reasonHash)
        {
            DisplayProperties = displayProperties;
            ReasonHash = reasonHash;
        }

        public bool DeepEquals(ReportReason other)
        {
            return other != null &&
                   ReasonHash == other.ReasonHash &&
                   DisplayProperties.DeepEquals(other.DisplayProperties);
        }
    }
}
