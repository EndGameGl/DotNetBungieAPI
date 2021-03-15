using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.ActivityGraphs
{
    /// <summary>
    /// Represents a single state that a graph node might end up in. Depending on what's going on in the game, graph nodes could be shown in different ways or even excluded from view entirely.
    /// </summary>
    public class ActivityGraphNodeState : IDeepEquatable<ActivityGraphNodeState>
    {
        public GraphNodeState State { get; }

        [JsonConstructor]
        internal ActivityGraphNodeState(GraphNodeState state)
        {
            State = state;
        }

        public bool DeepEquals(ActivityGraphNodeState other)
        {
            return other != null && State == other.State;
        }
    }
}
