using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Bungie.Applications
{
    public class ApiUsage
    {
        public ReadOnlyCollection<Series> ApiCalls { get; }
        public ReadOnlyCollection<Series> ThrottledRequests { get; }

        [JsonConstructor]
        internal ApiUsage(Series[] apiCalls, Series[] throttledRequests)
        {
            ApiCalls = apiCalls.AsReadOnlyOrEmpty();
            ThrottledRequests = throttledRequests.AsReadOnlyOrEmpty();
        }
    }
}
