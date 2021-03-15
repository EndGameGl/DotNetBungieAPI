using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.VendorGroups
{
    [DestinyDefinition(DefinitionsEnum.DestinyVendorGroupDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyVendorGroupDefinition : IDestinyDefinition, IDeepEquatable<DestinyVendorGroupDefinition>
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
        internal DestinyVendorGroupDefinition(string categoryName, int order, bool blacklisted, uint hash, int index, bool redacted)
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

        public void MapValues()
        {
            return;
        }

        public bool DeepEquals(DestinyVendorGroupDefinition other)
        {
            return other != null &&
                   CategoryName == other.CategoryName &&
                   Order == other.Order &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
