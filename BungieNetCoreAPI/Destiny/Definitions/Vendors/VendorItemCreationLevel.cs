using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorItemCreationLevel
    {
        public int Level { get; }

        [JsonConstructor]
        private VendorItemCreationLevel(int level)
        {
            Level = level;
        }
    }
}
