using Newtonsoft.Json;
using System;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorUnlockRange
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        [JsonConstructor]
        private VendorUnlockRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
}
