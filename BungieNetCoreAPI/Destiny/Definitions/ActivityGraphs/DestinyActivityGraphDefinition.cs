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
    [DestinyDefinition(type: DefinitionsEnum.DestinyActivityGraphDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyActivityGraphDefinition : IDestinyDefinition, IDeepEquatable<DestinyActivityGraphDefinition>
    {
        /// <summary>
        /// Represents one-off/special UI elements that appear on the map.
        /// </summary>
        public ReadOnlyCollection<ActivityGraphArtElementEntry> ArtElements { get; }
        /// <summary>
        /// Represents connections between graph nodes. However, it lacks context that we'd need to make good use of it.
        /// </summary>
        public ReadOnlyCollection<ActivityGraphConnectionEntry> Connections { get; }
        /// <summary>
        /// Objectives can display on maps, and this is supposedly metadata for that. I have not had the time to analyze the details of what is useful within however: we could be missing important data to make this work. Expect this property to be expanded on later if possible.
        /// </summary>
        public ReadOnlyCollection<ActivityGraphDisplayObjectiveEntry> DisplayObjectives { get; }
        /// <summary>
        /// Progressions can also display on maps, but similarly to displayObjectives we appear to lack some required information and context right now. We will have to look into it later and add more data if possible.
        /// </summary>
        public ReadOnlyCollection<ActivityGraphDisplayProgressionEntry> DisplayProgressions { get; }
        public bool IgnoreForMilestones { get; }
        /// <summary>
        /// Represents links between this Activity Graph and other ones.
        /// </summary>
        public ReadOnlyCollection<ActivityGraphLinkedGraphEntry> LinkedGraphs { get; }
        /// <summary>
        /// These represent the visual "nodes" on the map's view. These are the activities you can click on in the map.
        /// </summary>
        public ReadOnlyCollection<ActivityGraphNode> Nodes { get; }
        public int UIScreen { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyActivityGraphDefinition(ActivityGraphArtElementEntry[] artElements, ActivityGraphConnectionEntry[] connections, ActivityGraphDisplayObjectiveEntry[] displayObjectives,
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
            foreach (var linkedGraph in LinkedGraphs)
            {
                foreach (var graph in linkedGraph.LinkedGraphs)
                {
                    graph.ActivityGraph.TryMapValue();
                }
            }
            foreach (var node in Nodes)
            {
                foreach (var activity in node.Activities)
                {
                    activity.Activity.TryMapValue();
                }

            }
        }

        public bool DeepEquals(DestinyActivityGraphDefinition other)
        {
            return other != null &&
                   ArtElements.DeepEqualsReadOnlyCollections(other.ArtElements) &&
                   Connections.DeepEqualsReadOnlyCollections(other.Connections) &&
                   DisplayObjectives.DeepEqualsReadOnlyCollections(other.DisplayObjectives) &&
                   DisplayProgressions.DeepEqualsReadOnlyCollections(other.DisplayProgressions) &&
                   IgnoreForMilestones == other.IgnoreForMilestones &&
                   LinkedGraphs.DeepEqualsReadOnlyCollections(other.LinkedGraphs) &&
                   Nodes.DeepEqualsReadOnlyCollections(other.Nodes) &&
                   UIScreen == other.UIScreen &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
