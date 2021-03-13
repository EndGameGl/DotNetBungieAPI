using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    /// <summary>
    /// Represents the status and other related information for a challenge that is - or was - available to a player.
    /// <para/>
    /// A challenge is a bonus objective, generally tacked onto Quests or Activities, that provide additional variations on play.
    /// </summary>
    public class DestinyChallengeStatus
    {
        /// <summary>
        /// The progress - including completion status - of the active challenge.
        /// </summary>
        public DestinyObjectiveProgress Objective { get; }

        [JsonConstructor]
        internal DestinyChallengeStatus(DestinyObjectiveProgress objective)
        {
            Objective = objective;
        }
    }
}
