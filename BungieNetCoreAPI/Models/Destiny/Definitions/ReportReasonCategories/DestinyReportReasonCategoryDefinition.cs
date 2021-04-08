using NetBungieAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Models.Destiny.Definitions.ReportReasonCategories
{
    [DestinyDefinition(DefinitionsEnum.DestinyReportReasonCategoryDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyReportReasonCategoryDefinition : IDestinyDefinition, IDeepEquatable<DestinyReportReasonCategoryDefinition>
    {
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public ReadOnlyDictionary<uint, ReportReason> Reasons { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }
        [JsonConstructor]
        internal DestinyReportReasonCategoryDefinition(DestinyDisplayPropertiesDefinition displayProperties, Dictionary<uint, ReportReason> reasons,
            bool blacklisted, uint hash, int index, bool redacted)  
        {
            DisplayProperties = displayProperties;
            Reasons = reasons.AsReadOnlyDictionaryOrEmpty();
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }
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
