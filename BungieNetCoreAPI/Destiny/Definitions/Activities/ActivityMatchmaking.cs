using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    public class ActivityMatchmaking
    {
        public bool IsMatchmade { get; }
        public int MaxParty { get; }
        public int MaxPlayers { get; }
        public int MinParty { get; }
        public bool RequiresGuardianOath { get; }

        [JsonConstructor]
        private ActivityMatchmaking(bool isMatchmade, int maxParty, int maxPlayers, int minParty, bool requiresGuardianOath)
        {
            IsMatchmade = isMatchmade;
            MaxParty = maxParty;
            MaxPlayers = maxPlayers;
            MinParty = minParty;
            RequiresGuardianOath = requiresGuardianOath;
        }
    }
}
