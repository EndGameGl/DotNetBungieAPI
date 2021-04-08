using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPostGameCarnageReportTeam
    {
        public int TeamId { get; init; }
        public DestinyHistoricalStatsValue Standing { get; init; }
        public DestinyHistoricalStatsValue Score { get; init; }
        public string TeamName { get; init; }

        [JsonConstructor]
        internal DestinyPostGameCarnageReportTeam(int teamId, DestinyHistoricalStatsValue standing, DestinyHistoricalStatsValue score, string teamName) 
        {
            TeamId = teamId;
            Standing = standing;
            Score = score;
            TeamName = teamName;
        }
    }
}
