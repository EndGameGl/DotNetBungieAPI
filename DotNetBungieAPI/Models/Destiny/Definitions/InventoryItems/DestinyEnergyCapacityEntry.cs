using DotNetBungieAPI.Models.Destiny.Definitions.EnergyTypes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    ///     Items can have Energy Capacity, and plugs can provide that capacity such as on a piece of Armor in Armor 2.0. This
    ///     is how much "Energy" can be spent on activating plugs for this item.
    /// </summary>
    public sealed record DestinyEnergyCapacityEntry : IDeepEquatable<DestinyEnergyCapacityEntry>
    {
        /// <summary>
        ///     How much energy capacity this plug provides.
        /// </summary>
        [JsonPropertyName("capacityValue")]
        public int CapacityValue { get; init; }

        /// <summary>
        ///     Energy provided by a plug is always of a specific type - this is the DestinyEnergyTypeDefinition for the energy
        ///     type for which it provides Capacity.
        /// </summary>
        [JsonPropertyName("energyTypeHash")]
        public DefinitionHashPointer<DestinyEnergyTypeDefinition> EnergyType { get; init; } =
            DefinitionHashPointer<DestinyEnergyTypeDefinition>.Empty;

        /// <summary>
        ///     The Energy Type for this energy capacity, in enum form for easy use.
        /// </summary>
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