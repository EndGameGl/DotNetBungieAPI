using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorServiceDefinition : IDeepEquatable<DestinyVendorServiceDefinition>
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        public bool DeepEquals(DestinyVendorServiceDefinition other)
        {
            return other != null &&
                   Name == other.Name;
        }
    }
}
