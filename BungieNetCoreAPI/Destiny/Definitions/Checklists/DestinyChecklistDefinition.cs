using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Checklists
{
    [DestinyDefinition("DestinyChecklistDefinition")]
    public class DestinyChecklistDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public List<ChecklistEntry> Entries { get; }
        public int Scope { get; }
        public string ViewActionString { get; }

        [JsonConstructor]
        private DestinyChecklistDefinition(DestinyDefinitionDisplayProperties displayProperties, List<ChecklistEntry> entries, int scope, string viewActionString,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            if (entries == null)
                Entries = new List<ChecklistEntry>();
            else
                Entries = entries;
            Scope = scope;
            ViewActionString = viewActionString;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
