using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Activities
{
    /// <summary>
    /// Information about matchmaking and party size for the activity.
    /// </summary>
    public class ActivityMatchmaking : IDeepEquatable<ActivityMatchmaking>
    {
        /// <summary>
        /// If TRUE, the activity is matchmade. Otherwise, it requires explicit forming of a party.
        /// </summary>
        public bool IsMatchmade { get; }
        /// <summary>
        /// The maximum # of people allowed in a Fireteam.
        /// </summary>
        public int MaxParty { get; }
        /// <summary>
        /// The maximum # of people allowed across all teams in the activity.
        /// </summary>
        public int MaxPlayers { get; }
        /// <summary>
        /// The minimum # of people in the fireteam for the activity to launch.
        /// </summary>
        public int MinParty { get; }
        /// <summary>
        /// If true, you have to Solemnly Swear to be up to Nothing But Good(tm) to play.
        /// </summary>
        public bool RequiresGuardianOath { get; }

        [JsonConstructor]
        internal ActivityMatchmaking(bool isMatchmade, int maxParty, int maxPlayers, int minParty, bool requiresGuardianOath)
        {
            IsMatchmade = isMatchmade;
            MaxParty = maxParty;
            MaxPlayers = maxPlayers;
            MinParty = minParty;
            RequiresGuardianOath = requiresGuardianOath;
        }

        public bool DeepEquals(ActivityMatchmaking other)
        {
            return other != null &&
                    IsMatchmade == other.IsMatchmade &&
                    MaxParty == other.MaxParty &&
                    MaxPlayers == other.MaxPlayers &&
                    MinParty == other.MinParty &&
                    RequiresGuardianOath == other.RequiresGuardianOath;
        }
    }
}
