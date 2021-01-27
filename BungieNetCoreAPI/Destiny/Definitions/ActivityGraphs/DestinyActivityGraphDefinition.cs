using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.ActivityGraphs
{
    /// <summary>
    /// Represents a Map View in the director: be them overview views, destination views, or other.
    /// <para/>
    /// They have nodes which map to activities, and other various visual elements that we(or others) may or may not be able to use.
    /// <para/>
    /// Activity graphs, most importantly, have nodes which can have activities in various states of playability.
    /// <para/>
    /// Unfortunately, activity graphs are combined at runtime with Game UI-only assets such as fragments of map images, various in-game special effects, decals etc... that we don't get in these definitions.
    /// <para/>
    /// If we end up having time, we may end up trying to manually populate those here: but the last time we tried that, before the lead-up to D1, it proved to be unmaintainable as the game's content changed. So don't bet the farm on us providing that content in this definition.
    /// </summary>
    [DestinyDefinition(name: "DestinyActivityGraphDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyActivityGraphDefinition : IDestinyDefinition
    {
        /// <summary>
        /// Represents one-off/special UI elements that appear on the map.
        /// </summary>
        public ReadOnlyCollection<ActivityGraphArtElementEntry> ArtElements { get; }
        public ReadOnlyCollection<ActivityGraphConnectionEntry> Connections { get; }
        public ReadOnlyCollection<ActivityGraphDisplayObjectiveEntry> DisplayObjectives { get; }
        public ReadOnlyCollection<ActivityGraphDisplayProgressionEntry> DisplayProgressions { get; }
        public bool IgnoreForMilestones { get; }
        public ReadOnlyCollection<ActivityGraphLinkedGraphEntry> LinkedGraphs { get; }
        public ReadOnlyCollection<ActivityGraphNode> Nodes { get; }
        public int UIScreen { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyActivityGraphDefinition(ActivityGraphArtElementEntry[] artElements, ActivityGraphConnectionEntry[] connections, ActivityGraphDisplayObjectiveEntry[] displayObjectives,
            ActivityGraphDisplayProgressionEntry[] displayProgressions, bool ignoreForMilestones, ActivityGraphLinkedGraphEntry[] linkedGraphs, ActivityGraphNode[] nodes, int uiScreen,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            ArtElements = artElements.AsReadOnlyOrEmpty();
            Connections = connections.AsReadOnlyOrEmpty();
            DisplayObjectives = displayObjectives.AsReadOnlyOrEmpty();
            DisplayProgressions = displayProgressions.AsReadOnlyOrEmpty();
            IgnoreForMilestones = ignoreForMilestones;
            LinkedGraphs = linkedGraphs.AsReadOnlyOrEmpty();
            Nodes = nodes.AsReadOnlyOrEmpty();
            UIScreen = uiScreen;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public void MapValues()
        {
            foreach (var displayObjective in DisplayObjectives)
            {
                displayObjective.Objective.TryMapValue();
            }
            foreach (var displayProgression in DisplayProgressions)
            {
                displayProgression.Progression.TryMapValue();
            }
        }
    }
}
