using Newtonsoft.Json;
using System;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyProfileTransitoryCurrentActivity
    {
        public DateTime? StartTime { get; init; }
        public DateTime? EndTime { get; init; }
        public float Score { get; init; }
        public float HighestOpposingFactionScore { get; init; }
        public int NumberOfOpponents { get; init; }
        public int NumberOfPlayers { get; init; }

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
