using Newtonsoft.Json;
using System;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyProfileTransitoryCurrentActivity
    {
        public DateTime? StartTime { get; }
        public DateTime? EndTime { get; }
        public float Score { get; }
        public float HighestOpposingFactionScore { get; }
        public int NumberOfOpponents { get; }
        public int NumberOfPlayers { get; }

        [JsonConstructor]
        internal DestinyProfileTransitoryCurrentActivity(DateTime? startTime, DateTime? endTime, float score, float highestOpposingFactionScore, 
            int numberOfOpponents, int numberOfPlayers)
        {
            StartTime = startTime;
            EndTime = endTime;
            Score = score;
            HighestOpposingFactionScore = highestOpposingFactionScore;
            NumberOfOpponents = numberOfOpponents;
            NumberOfPlayers = numberOfPlayers;
        }
    }
}
