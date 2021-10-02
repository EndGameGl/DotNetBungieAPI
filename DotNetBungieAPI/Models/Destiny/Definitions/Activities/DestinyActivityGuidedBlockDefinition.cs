using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities
{
    /// <summary>
    ///     Guided Game information for activity.
    /// </summary>
    public sealed record DestinyActivityGuidedBlockDefinition : IDeepEquatable<DestinyActivityGuidedBlockDefinition>
    {
        /// <summary>
        ///     If -1, the guided group cannot be disbanded. Otherwise, take the total # of players in the activity and subtract
        ///     this number: that is the total # of votes needed for the guided group to disband.
        /// </summary>
        [JsonPropertyName("guidedDisbandCount")]
        public int GuidedDisbandCount { get; init; }

        /// <summary>
        ///     The maximum amount of people that can be in the waiting lobby.
        /// </summary>
        [JsonPropertyName("guidedMaxLobbySize")]
        public int GuidedMaxLobbySize { get; init; }

        /// <summary>
        ///     The minimum amount of people that can be in the waiting lobby.
        /// </summary>
        [JsonPropertyName("guidedMinLobbySize")]
        public int GuidedMinLobbySize { get; init; }

        public bool DeepEquals(DestinyActivityGuidedBlockDefinition other)
        {
            return
                other != null &&
                GuidedDisbandCount == other.GuidedDisbandCount &&
                GuidedMaxLobbySize == other.GuidedMaxLobbySize &&
                GuidedMinLobbySize == other.GuidedMinLobbySize;
        }
    }
}