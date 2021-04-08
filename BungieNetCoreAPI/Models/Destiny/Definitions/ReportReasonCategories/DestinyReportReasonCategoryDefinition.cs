using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.ReportReasonCategories
{
    [DestinyDefinition(DefinitionsEnum.DestinyReportReasonCategoryDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinyReportReasonCategoryDefinition : IDestinyDefinition, IDeepEquatable<DestinyReportReasonCategoryDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("reasons")]
        public ReadOnlyDictionary<uint, DestinyReportReasonDefinition> Reasons { get; init; } = Defaults.EmptyReadOnlyDictionary<uint, DestinyReportReasonDefinition>();
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }


        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyReportReasonCategoryDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Reasons.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndEquatableValue(other.Reasons) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            return;
        }
    }
}
