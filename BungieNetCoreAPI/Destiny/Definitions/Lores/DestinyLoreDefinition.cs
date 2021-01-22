using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.Lores
{
    [DestinyDefinition(name: "DestinyLoreDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyLoreDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public string Subtitle { get; }

        [JsonConstructor]
        private DestinyLoreDefinition(DestinyDefinitionDisplayProperties displayProperties, string subtitle, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            Subtitle = subtitle;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
