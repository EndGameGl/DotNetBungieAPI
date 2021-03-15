using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorService : IDeepEquatable<VendorService>
    {
        public string Name { get; }

        [JsonConstructor]
        internal VendorService(string name)
        {
            Name = name;
        }

        public bool DeepEquals(VendorService other)
        {
            return other != null &&
                   Name == other.Name;
        }
    }
}
