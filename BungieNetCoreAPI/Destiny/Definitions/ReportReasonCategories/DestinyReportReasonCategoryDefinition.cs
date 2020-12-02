using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.ReportReasonCategories
{
    [DestinyDefinition("DestinyReportReasonCategoryDefinition")]
    public class DestinyReportReasonCategoryDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public Dictionary<uint, ReportReasonEntry> Reasons { get; }
        [JsonConstructor]
        private DestinyReportReasonCategoryDefinition(DestinyDefinitionDisplayProperties displayProperties, Dictionary<uint, ReportReasonEntry> reasons,
            bool blacklisted, uint hash, int index, bool redacted) 
            : base(blacklisted, hash, index, redacted) 
        {
            DisplayProperties = displayProperties;
            Reasons = reasons;
        }
        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
