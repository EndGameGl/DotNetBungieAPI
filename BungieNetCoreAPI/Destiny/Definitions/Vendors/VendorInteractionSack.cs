using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorInteractionSack
    {
        public uint SackType { get; }

        [JsonConstructor]
        private VendorInteractionSack(uint sackType)
        {
            SackType = sackType;
        }
    }
}
