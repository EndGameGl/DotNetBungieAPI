using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityInteractables
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyActivityInteractableDefinition, presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyActivityInteractableDefinition : IDestinyDefinition
    {
        public List<ActivityInteractableEntry> Entries { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyActivityInteractableDefinition(List<ActivityInteractableEntry> entries, bool blacklisted, uint hash, int index, bool redacted)
        {
            if (entries == null)
                Entries = new List<ActivityInteractableEntry>();
            else
                Entries = entries;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }
    }
}
