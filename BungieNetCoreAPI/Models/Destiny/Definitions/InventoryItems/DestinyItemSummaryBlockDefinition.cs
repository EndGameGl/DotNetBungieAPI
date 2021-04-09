using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    public sealed record DestinyItemSummaryBlockDefinition : IDeepEquatable<DestinyItemSummaryBlockDefinition>
    {
        [JsonPropertyName("sortPriority")]
        public int SortPriority { get; init; }

        public bool DeepEquals(DestinyItemSummaryBlockDefinition other)
        {
            return other != null && SortPriority == other.SortPriority;
        }
    }
}
