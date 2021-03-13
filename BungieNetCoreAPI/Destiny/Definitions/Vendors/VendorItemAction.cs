using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Vendors
{
    public class VendorItemAction : IDeepEquatable<VendorItemAction>
    {
        public double ExecuteSeconds { get; }
        public bool IsPositive { get; }

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
