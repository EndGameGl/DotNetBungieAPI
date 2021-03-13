using NetBungieApi.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile
{
    public class DestinyPostGameCarnageReportData
    {
        public DateTime Period { get; }
        public int? StartingPhaseIndex { get; }
        public DestinyHistoricalStatsActivity ActivityDetails { get; }
        public ReadOnlyCollection<DestinyPostGameCarnageReport> Entries { get; }
        public ReadOnlyCollection<DestinyPostGameCarnageReportTeam> Teams { get; }

        [JsonConstructor]
        internal DestinyPostGameCarnageReportData(DateTime period, int? startingPhaseIndex, DestinyHistoricalStatsActivity activityDetails,
            DestinyPostGameCarnageReport[] entries, DestinyPostGameCarnageReportTeam[] teams)
        {
            Period = period;
            StartingPhaseIndex = startingPhaseIndex;
            ActivityDetails = activityDetails;
            Entries = entries.AsReadOnlyOrEmpty();
            Teams = teams.AsReadOnlyOrEmpty();
        }
    }
}
