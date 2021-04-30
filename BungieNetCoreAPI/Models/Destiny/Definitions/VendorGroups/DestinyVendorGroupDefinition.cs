using NetBungieAPI.Attributes;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.VendorGroups
{
    [DestinyDefinition(DefinitionsEnum.DestinyVendorGroupDefinition)]
    public sealed record DestinyVendorGroupDefinition : IDestinyDefinition, IDeepEquatable<DestinyVendorGroupDefinition>
    {
        /// <summary>
        /// Vendor group name
        /// </summary>
        [JsonPropertyName("categoryName")]
        public string CategoryName { get; init; }
        [JsonPropertyName("order")]
        public int Order { get; init; }
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

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
