using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Bungie.Applications
{
    public class Series
    {
        public ReadOnlyCollection<Datapoint> Datapoints { get; }
        public string Target { get; }

        [JsonConstructor]
        internal Series(Datapoint[] datapoints, string target)
        {
            Datapoints = datapoints.AsReadOnlyOrEmpty();
            Target = target;
        }
    }
}
