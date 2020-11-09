using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    public class DestinyRecordDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }

        [JsonConstructor]
        private DestinyRecordDefinition(DestinyDefinitionDisplayProperties displayProperties, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
