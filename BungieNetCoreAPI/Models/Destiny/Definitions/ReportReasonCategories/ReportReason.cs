using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.ReportReasonCategories
{
    public class ReportReason : IDeepEquatable<ReportReason>
    {
        public uint ReasonHash { get; init; }
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        [JsonConstructor]
        internal ReportReason(DestinyDisplayPropertiesDefinition displayProperties, uint reasonHash)
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
