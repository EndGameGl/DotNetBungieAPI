using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorItemAction
    {
        public double ExecuteSeconds { get; }
        public bool IsPositive { get; }

        [JsonConstructor]
        private VendorItemAction(double executeSeconds, bool isPositive)
        {
            ExecuteSeconds = executeSeconds;
            IsPositive = isPositive;
        }
    }
}
