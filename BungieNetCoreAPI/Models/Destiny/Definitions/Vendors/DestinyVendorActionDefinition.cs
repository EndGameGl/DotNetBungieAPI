using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorActionDefinition : IDeepEquatable<DestinyVendorActionDefinition>
    {
        [JsonPropertyName("description")]
        public string Description { get; init; }
        [JsonPropertyName("executeSeconds")]
        public int ExecuteSeconds { get; init; }
        [JsonPropertyName("icon")]
        public string Icon { get; init; }
        [JsonPropertyName("name")]
        public string Name { get; init; }
        [JsonPropertyName("verb")]
        public string Verb { get; init; }
        [JsonPropertyName("isPositive")]
        public bool IsPositive { get; init; }
        [JsonPropertyName("actionId")]
        public string ActionId { get; init; }
        [JsonPropertyName("actionHash")]
        public uint ActionHash { get; init; }
        [JsonPropertyName("autoPerformAction")]
        public bool AutoPerformAction { get; init; }

        public bool DeepEquals(DestinyVendorActionDefinition other)
        {
            return other != null &&
                   Description == other.Description &&
                   ExecuteSeconds == other.ExecuteSeconds &&
                   Icon == other.Icon &&
                   Name == other.Name &&
                   Verb == other.Verb &&
                   IsPositive == other.IsPositive &&
                   ActionId == other.ActionId &&
                   ActionHash == other.ActionHash &&
                   AutoPerformAction == other.AutoPerformAction;
        }
    }
}
