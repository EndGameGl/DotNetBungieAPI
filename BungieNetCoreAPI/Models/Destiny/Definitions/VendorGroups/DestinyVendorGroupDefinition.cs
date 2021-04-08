using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Models.Destiny.Definitions.VendorGroups
{
    [DestinyDefinition(DefinitionsEnum.DestinyVendorGroupDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyVendorGroupDefinition : IDestinyDefinition, IDeepEquatable<DestinyVendorGroupDefinition>
    {
        /// <summary>
        /// Vendor group name
        /// </summary>
        public string CategoryName { get; init; }
        public int Order { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

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
