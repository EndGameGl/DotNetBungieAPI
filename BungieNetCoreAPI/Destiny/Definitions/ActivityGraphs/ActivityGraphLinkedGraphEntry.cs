using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    public class ActivityGraphLinkedGraphEntry
    {
        public string Description { get; }
        public string Name { get; }
        public string Overview { get; }
        public uint LinkedGraphId { get; }
        public ActivityGraphLinkedGraphEntryUnlockExpression UnlockExpression { get; }
        public List<ActivityGraphLinkedGraphEntryLinkedGraphEntry> LinkedGraphs { get; }

        [JsonConstructor]
        private ActivityGraphLinkedGraphEntry(string description, string name, string overview, uint linkedGraphId, ActivityGraphLinkedGraphEntryUnlockExpression unlockExpression,
            List<ActivityGraphLinkedGraphEntryLinkedGraphEntry> linkedGraphs)
        {
            Description = description;
            Name = name;
            Overview = overview;
            LinkedGraphId = linkedGraphId;
            UnlockExpression = unlockExpression;
            if (linkedGraphs == null)
                LinkedGraphs = new List<ActivityGraphLinkedGraphEntryLinkedGraphEntry>();
            else
                LinkedGraphs = linkedGraphs;
        }

        public override string ToString()
        {
            return $"{LinkedGraphId} {Name}: {Description}";
        }
    }
}
