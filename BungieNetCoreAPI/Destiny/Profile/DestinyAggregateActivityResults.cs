using NetBungieAPI.Destiny.Profile.Components.Contracts;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile
{
    public class DestinyAggregateActivityResults
    {
        public ReadOnlyCollection<DestinyAggregateActivityStats> Activities { get; }
        [JsonConstructor]
        internal DestinyAggregateActivityResults(DestinyAggregateActivityStats[] activities)
        {
            Activities = activities.AsReadOnlyOrEmpty();
        }
    }
}
