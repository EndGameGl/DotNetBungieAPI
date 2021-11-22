using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.HistoricalStats
{
    public sealed record DestinyHistoricalWeaponStats
    {
        /// <summary>
        ///     The hash ID of the item definition that describes the weapon.
        /// </summary>
        [JsonPropertyName("referenceId")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> ItemReference { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        /// <summary>
        ///     Collection of stats for the period.
        /// </summary>
        [JsonPropertyName("values")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; init; } =
            ReadOnlyDictionaries<string, DestinyHistoricalStatsValue>.Empty;
    }
}