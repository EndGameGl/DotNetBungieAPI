using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.PlugSets
{
    public sealed record DestinyItemSocketEntryPlugItemRandomizedDefinition : IDeepEquatable<DestinyItemSocketEntryPlugItemRandomizedDefinition>
    {
        [JsonPropertyName("weight")]
        public double Weight { get; init; }
        [JsonPropertyName("alternateWeight")]
        public double AlternateWeight { get; init; }
        [JsonPropertyName("plugItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("currentlyCanRoll")]
        public bool CurrentlyCanRoll { get; init; }

        public bool DeepEquals(DestinyItemSocketEntryPlugItemRandomizedDefinition other)
        {
            return other != null &&
                   Weight == other.Weight &&
                   AlternateWeight == other.AlternateWeight &&
                   PlugItem.DeepEquals(other.PlugItem) &&
                   CurrentlyCanRoll == other.CurrentlyCanRoll;
        }
    }
}
