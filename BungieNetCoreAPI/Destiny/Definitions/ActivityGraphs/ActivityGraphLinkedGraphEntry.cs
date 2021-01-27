using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    /// <summary>
    /// This describes links between the current graph and others, as well as when that link is relevant.
    /// </summary>
    public class ActivityGraphLinkedGraphEntry : IDeepEquatable<ActivityGraphLinkedGraphEntry>
    {
        public string Description { get; }
        public string Name { get; }
        public string Overview { get; }
        public uint LinkedGraphId { get; }
        public ActivityGraphLinkedGraphEntryUnlockExpression UnlockExpression { get; }
        public ReadOnlyCollection<ActivityGraphLinkedGraphEntryLinkedGraphEntry> LinkedGraphs { get; }

        [JsonConstructor]
        internal ActivityGraphLinkedGraphEntry(string description, string name, string overview, uint linkedGraphId, ActivityGraphLinkedGraphEntryUnlockExpression unlockExpression,
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
        public bool DeepEquals(ActivityGraphLinkedGraphEntry other)
        {
            return other != null &&
                   Description == other.Description &&
                   Name == other.Name &&
                   Overview == other.Overview &&
                   LinkedGraphId == other.LinkedGraphId &&
                   UnlockExpression.DeepEquals(other.UnlockExpression) &&
                   LinkedGraphs.DeepEqualsReadOnlyCollections(other.LinkedGraphs);
        }
    }
}
