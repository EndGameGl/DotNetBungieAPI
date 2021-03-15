using Newtonsoft.Json;
using System;

namespace NetBungieAPI.Bungie.Applications
{
    public class Datapoint
    {
        public DateTime Time { get; }
        public double? Count { get; }

        [JsonConstructor]
        internal Datapoint(DateTime time, double? count)
        {
            Time = time;
            Count = count;
        }
    }
}
