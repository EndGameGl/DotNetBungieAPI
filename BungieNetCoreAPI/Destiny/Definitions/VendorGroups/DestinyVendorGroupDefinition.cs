using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.VendorGroups
{
    [DestinyDefinition("DestinyVendorGroupDefinition")]
    public class DestinyVendorGroupDefinition : DestinyDefinition
    {
        public string CategoryName { get; }
        public int Order { get; }

        [JsonConstructor]
        private DestinyVendorGroupDefinition(string categoryName, int order, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            CategoryName = categoryName;
            Order = order;
        }

        public override string ToString()
        {
            return $"{Hash} {CategoryName}";
        }
    }
}
