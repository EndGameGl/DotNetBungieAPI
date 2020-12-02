using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityInteractables
{
    [DestinyDefinition("DestinyActivityInteractableDefinition")]
    public class DestinyActivityInteractableDefinition : DestinyDefinition
    {
        public List<ActivityInteractableEntry> Entries { get; }

        [JsonConstructor]
        private DestinyActivityInteractableDefinition(List<ActivityInteractableEntry> entries, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            if (entries == null)
                Entries = new List<ActivityInteractableEntry>();
            else
                Entries = entries;
        }
    }
}
