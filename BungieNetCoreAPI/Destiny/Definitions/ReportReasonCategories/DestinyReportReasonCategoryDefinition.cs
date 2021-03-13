using NetBungieApi.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Definitions.ReportReasonCategories
{
    [DestinyDefinition(DefinitionsEnum.DestinyReportReasonCategoryDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyReportReasonCategoryDefinition : IDestinyDefinition, IDeepEquatable<DestinyReportReasonCategoryDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public ReadOnlyDictionary<uint, ReportReason> Reasons { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }
        [JsonConstructor]
        internal DestinyReportReasonCategoryDefinition(DestinyDefinitionDisplayProperties displayProperties, Dictionary<uint, ReportReason> reasons,
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
