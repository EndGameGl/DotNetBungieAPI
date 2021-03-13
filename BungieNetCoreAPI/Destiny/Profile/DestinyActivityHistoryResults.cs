using NetBungieApi.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieApi.Destiny.Profile
{
    public class DestinyActivityHistoryResults
    {
        public ReadOnlyCollection<DestinyHistoricalStatsPeriodGroup> Activities { get; }

        [JsonConstructor]
        internal DestinyActivityHistoryResults(DestinyHistoricalStatsPeriodGroup[] activities)
        {
            Activities = activities.AsReadOnlyOrEmpty();
        }
    }
}
