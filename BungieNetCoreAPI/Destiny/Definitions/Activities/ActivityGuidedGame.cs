using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    public class ActivityGuidedGame
    {
        public int GuidedDisbandCount { get; }
        public int GuidedMaxLobbySize { get; }
        public int GuidedMinLobbySize { get; }

        [JsonConstructor]
        private ActivityGuidedGame(int guidedDisbandCount, int guidedMaxLobbySize, int guidedMinLobbySize)
        {
            GuidedDisbandCount = guidedDisbandCount;
            GuidedMaxLobbySize = guidedMaxLobbySize;
            GuidedMinLobbySize = guidedMinLobbySize;
        }
    }
}
