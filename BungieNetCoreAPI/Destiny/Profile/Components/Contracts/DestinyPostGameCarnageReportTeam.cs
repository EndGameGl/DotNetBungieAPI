using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyPostGameCarnageReportTeam
    {
        public int TeamId { get; }
        public DestinyHistoricalStatsValue Standing { get; }
        public DestinyHistoricalStatsValue Score { get; }
        public string TeamName { get; }

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
