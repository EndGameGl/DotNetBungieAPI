using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    public class ActivityGraphLinkedGraphEntry
    {
        public string Description { get; }
        public string Name { get; }
        public string Overview { get; }
        public uint LinkedGraphId { get; }
        public ActivityGraphLinkedGraphEntryUnlockExpression UnlockExpression { get; }
        public ReadOnlyCollection<ActivityGraphLinkedGraphEntryLinkedGraphEntry> LinkedGraphs { get; }

        [JsonConstructor]
        private ActivityGraphLinkedGraphEntry(string description, string name, string overview, uint linkedGraphId, ActivityGraphLinkedGraphEntryUnlockExpression unlockExpression,
            ActivityGraphLinkedGraphEntryLinkedGraphEntry[] linkedGraphs)
        {
            Description = description;
            Name = name;
            Overview = overview;
            LinkedGraphId = linkedGraphId;
            UnlockExpression = unlockExpression;
            LinkedGraphs = linkedGraphs.AsReadOnlyOrEmpty();
        }

        public override string ToString()
        {
            return $"{LinkedGraphId} {Name}: {Description}";
        }
    }
}
