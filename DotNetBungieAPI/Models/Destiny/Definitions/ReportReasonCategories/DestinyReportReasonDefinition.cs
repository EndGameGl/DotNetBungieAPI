using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.ReportReasonCategories
{
    /// <summary>
    ///     A specific reason for being banned. Only accessible under the related category
    ///     (DestinyReportReasonCategoryDefinition) under which it is shown. Note that this means that report reasons'
    ///     reasonHash are not globally unique: and indeed, entries like "Other" are defined under most categories for example.
    /// </summary>
    public sealed record DestinyReportReasonDefinition : IDeepEquatable<DestinyReportReasonDefinition>
    {
        /// <summary>
        ///     The identifier for the reason: they are only guaranteed unique under the Category in which they are found.
        /// </summary>
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