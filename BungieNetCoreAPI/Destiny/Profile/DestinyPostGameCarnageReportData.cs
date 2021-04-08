using NetBungieAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile
{
    public class DestinyPostGameCarnageReportData
    {
        public DateTime Period { get; init; }
        public int? StartingPhaseIndex { get; init; }
        public DestinyHistoricalStatsActivity ActivityDetails { get; init; }
        public ReadOnlyCollection<DestinyPostGameCarnageReport> Entries { get; init; }
        public ReadOnlyCollection<DestinyPostGameCarnageReportTeam> Teams { get; init; }

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
