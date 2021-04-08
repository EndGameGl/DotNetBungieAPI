using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorItemAction : IDeepEquatable<VendorItemAction>
    {
        public double ExecuteSeconds { get; init; }
        public bool IsPositive { get; init; }

        [JsonConstructor]
        internal VendorItemAction(double executeSeconds, bool isPositive)
        {
            ExecuteSeconds = executeSeconds;
            IsPositive = isPositive;
        }

        public bool DeepEquals(VendorItemAction other)
        {
            return other != null &&
                   ExecuteSeconds == other.ExecuteSeconds &&
                   IsPositive == other.IsPositive;
        }
    }
}
