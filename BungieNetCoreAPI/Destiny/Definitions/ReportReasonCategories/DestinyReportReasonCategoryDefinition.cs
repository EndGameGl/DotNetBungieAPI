using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.ReportReasonCategories
{
    [DestinyDefinition(DefinitionsEnum.DestinyReportReasonCategoryDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyReportReasonCategoryDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public Dictionary<uint, ReportReasonEntry> Reasons { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }
        [JsonConstructor]
        private DestinyReportReasonCategoryDefinition(DestinyDefinitionDisplayProperties displayProperties, Dictionary<uint, ReportReasonEntry> reasons,
            bool blacklisted, uint hash, int index, bool redacted)  
        {
            DisplayProperties = displayProperties;
            Reasons = reasons;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }
        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
