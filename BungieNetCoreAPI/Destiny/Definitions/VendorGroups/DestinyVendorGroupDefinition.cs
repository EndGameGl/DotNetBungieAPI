using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.VendorGroups
{
    [DestinyDefinition(name: "DestinyVendorGroupDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyVendorGroupDefinition : IDestinyDefinition
    {
        /// <summary>
        /// Vendor group name
        /// </summary>
        public string CategoryName { get; }
        public int Order { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyVendorGroupDefinition(string categoryName, int order, bool blacklisted, uint hash, int index, bool redacted)
        {
            CategoryName = categoryName;
            Order = order;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {CategoryName}";
        }
    }
}
