using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Vendors
{
    public class VendorService
    {
        public string Name { get; }

        [JsonConstructor]
        private VendorService(string name)
        {
            Name = name;
        }
    }
}
