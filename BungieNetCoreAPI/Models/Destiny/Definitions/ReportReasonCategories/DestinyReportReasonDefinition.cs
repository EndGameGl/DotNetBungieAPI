using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.ReportReasonCategories
{
    public sealed record DestinyReportReasonDefinition : IDeepEquatable<DestinyReportReasonDefinition>
    {
        [JsonPropertyName("reasonHash")]
        public uint ReasonHash { get; init; }
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        public bool DeepEquals(DestinyReportReasonDefinition other)
        {
            return other != null &&
                   ReasonHash == other.ReasonHash &&
                   DisplayProperties.DeepEquals(other.DisplayProperties);
        }
    }
}
