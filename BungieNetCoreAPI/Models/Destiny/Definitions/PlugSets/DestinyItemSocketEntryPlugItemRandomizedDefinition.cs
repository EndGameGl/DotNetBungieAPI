using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.PlugSets
{
    public sealed record DestinyItemSocketEntryPlugItemRandomizedDefinition
        : IDeepEquatable<DestinyItemSocketEntryPlugItemRandomizedDefinition>
    {
        [JsonPropertyName("weight")] public double Weight { get; init; }
        [JsonPropertyName("alternateWeight")] public double AlternateWeight { get; init; }

        /// <summary>
        /// DestinyInventoryItemDefinition representing the plug that can be inserted.
        /// </summary>
        [JsonPropertyName("plugItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        /// <summary>
        /// Indicates if the plug can be rolled on the current version of the item. For example, older versions of weapons may have plug rolls that are no longer possible on the current versions.
        /// </summary>
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