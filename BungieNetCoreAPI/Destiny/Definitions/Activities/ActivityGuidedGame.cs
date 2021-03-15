using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Activities
{
    /// <summary>
    /// Guided Game information for activity.
    /// </summary>
    public class ActivityGuidedGame : IDeepEquatable<ActivityGuidedGame>
    {
        /// <summary>
        /// If -1, the guided group cannot be disbanded. Otherwise, take the total # of players in the activity and subtract this number: that is the total # of votes needed for the guided group to disband.
        /// </summary>
        public int GuidedDisbandCount { get; }
        /// <summary>
        /// The maximum amount of people that can be in the waiting lobby.
        /// </summary>
        public int GuidedMaxLobbySize { get; }
        /// <summary>
        /// The minimum amount of people that can be in the waiting lobby.
        /// </summary>
        public int GuidedMinLobbySize { get; }

        [JsonConstructor]
        internal ActivityGuidedGame(int guidedDisbandCount, int guidedMaxLobbySize, int guidedMinLobbySize)
        {
            GuidedDisbandCount = guidedDisbandCount;
            GuidedMaxLobbySize = guidedMaxLobbySize;
            GuidedMinLobbySize = guidedMinLobbySize;
        }

        public bool DeepEquals(ActivityGuidedGame other)
        {
            return
                other != null &&
                GuidedDisbandCount == other.GuidedDisbandCount &&
                GuidedMaxLobbySize == other.GuidedMaxLobbySize &&
                GuidedMinLobbySize == other.GuidedMinLobbySize;
        }
    }
}
