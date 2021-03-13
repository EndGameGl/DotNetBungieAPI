using Newtonsoft.Json;
using System;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorUnlockRange : IDeepEquatable<VendorUnlockRange>
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        [JsonConstructor]
        internal VendorUnlockRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public bool DeepEquals(VendorUnlockRange other)
        {
            return other != null &&
                   Start == other.Start &&
                   End == other.End;
        }
    }
}
