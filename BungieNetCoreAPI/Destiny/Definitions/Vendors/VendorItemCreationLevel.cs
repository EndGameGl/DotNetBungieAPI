using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Vendors
{
    public class VendorItemCreationLevel : IDeepEquatable<VendorItemCreationLevel>
    {
        public int Level { get; }

        [JsonConstructor]
        internal VendorItemCreationLevel(int level)
        {
            Level = level;
        }

        public bool DeepEquals(VendorItemCreationLevel other)
        {
            return other != null &&
                   Level == other.Level;
        }
    }
}
