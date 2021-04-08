using Newtonsoft.Json;
using System;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorUnlockRange : IDeepEquatable<VendorUnlockRange>
    {
        public DateTime Start { get; init; }
        public DateTime End { get; init; }

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
