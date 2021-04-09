using NetBungieAPI.Models.Destiny.Definitions.EnergyTypes;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Items can have Energy Capacity, and plugs can provide that capacity such as on a piece of Armor in Armor 2.0. This is how much "Energy" can be spent on activating plugs for this item.
    /// </summary>
    public sealed record DestinyEnergyCapacityEntry : IDeepEquatable<DestinyEnergyCapacityEntry>
    {
        [JsonPropertyName("capacityValue")]
        public int CapacityValue { get; init; }
        [JsonPropertyName("energyTypeHash")]
        public DefinitionHashPointer<DestinyEnergyTypeDefinition> EnergyType { get; init; } = DefinitionHashPointer<DestinyEnergyTypeDefinition>.Empty;
        [JsonPropertyName("energyType")]
        public DestinyEnergyType EnergyTypeEnumValue { get; init; }

        public bool DeepEquals(DestinyEnergyCapacityEntry other)
        {
            return other != null &&
                   CapacityValue == other.CapacityValue &&
                   EnergyType.DeepEquals(other.EnergyType) &&
                   EnergyTypeEnumValue == other.EnergyTypeEnumValue;
        }
    }
}
