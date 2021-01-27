using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Checklists
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyChecklistDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyChecklistDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public List<ChecklistEntry> Entries { get; }
        public int Scope { get; }
        public string ViewActionString { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyChecklistDefinition(DestinyDefinitionDisplayProperties displayProperties, List<ChecklistEntry> entries, int scope, string viewActionString,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            if (entries == null)
                Entries = new List<ChecklistEntry>();
            else
                Entries = entries;
            Scope = scope;
            ViewActionString = viewActionString;
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
