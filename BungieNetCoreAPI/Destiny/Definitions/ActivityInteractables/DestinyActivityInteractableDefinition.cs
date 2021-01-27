using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityInteractables
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyActivityInteractableDefinition, presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyActivityInteractableDefinition : IDestinyDefinition, IDeepEquatable<DestinyActivityInteractableDefinition>
    {
        public ReadOnlyCollection<ActivityInteractableEntry> Entries { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyActivityInteractableDefinition(ActivityInteractableEntry[] entries, bool blacklisted, uint hash, int index, bool redacted)
        {
            Entries = entries.AsReadOnlyOrEmpty();
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public void MapValues()
        {
            foreach (var entry in Entries)
            {
                entry.Activity.TryMapValue();
            }
        }

        public bool DeepEquals(DestinyActivityInteractableDefinition other)
        {
            return other != null &&
                   Entries.DeepEqualsReadOnlyCollections(other.Entries) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }        
    }
}
