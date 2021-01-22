using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    [DestinyDefinition(name: "DestinyActivityGraphDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyActivityGraphDefinition : DestinyDefinition
    {
        public List<ActivityGraphArtElementEntry> ArtElements { get; }
        public List<ActivityGraphConnectionEntry> Connections { get; }
        public List<ActivityGraphDisplayObjectiveEntry> DisplayObjectives { get; }
        public List<ActivityGraphDisplayProgressionEntry> DisplayProgressions { get; }
        public bool IgnoreForMilestones { get; }
        public List<ActivityGraphLinkedGraphEntry> LinkedGraphs { get; }
        public List<ActivityGraphNode> Nodes { get; }
        public int UIScreen { get; }

        [JsonConstructor]
        private DestinyActivityGraphDefinition(List<ActivityGraphArtElementEntry> artElements, List<ActivityGraphConnectionEntry> connections, List<ActivityGraphDisplayObjectiveEntry> displayObjectives, 
            List<ActivityGraphDisplayProgressionEntry> displayProgressions, bool ignoreForMilestones, List<ActivityGraphLinkedGraphEntry> linkedGraphs, List<ActivityGraphNode> nodes, int uiScreen, 
            bool blacklisted, uint hash, int index, bool redacted) 
            : base(blacklisted, hash, index, redacted)
        {
            if (artElements == null)
                ArtElements = new List<ActivityGraphArtElementEntry>();
            else
                ArtElements = artElements;
            if (connections == null)
                Connections = new List<ActivityGraphConnectionEntry>();
            else
                Connections = connections; 
            if (displayObjectives == null)
                DisplayObjectives = new List<ActivityGraphDisplayObjectiveEntry>();
            else
                DisplayObjectives = displayObjectives; 
            if (displayProgressions == null)
                DisplayProgressions = new List<ActivityGraphDisplayProgressionEntry>();
            else
                DisplayProgressions = displayProgressions;
            IgnoreForMilestones = ignoreForMilestones;
            if (linkedGraphs == null)
                LinkedGraphs = new List<ActivityGraphLinkedGraphEntry>();
            else
                LinkedGraphs = linkedGraphs; 
            if (nodes == null)
                Nodes = new List<ActivityGraphNode>();
            else
                Nodes = nodes;
            UIScreen = uiScreen;
        }
    }
}
