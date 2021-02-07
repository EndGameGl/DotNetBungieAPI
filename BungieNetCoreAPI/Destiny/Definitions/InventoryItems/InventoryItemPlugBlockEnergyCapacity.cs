using BungieNetCoreAPI.Destiny.Definitions.EnergyTypes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Items can have Energy Capacity, and plugs can provide that capacity such as on a piece of Armor in Armor 2.0. This is how much "Energy" can be spent on activating plugs for this item.
    /// </summary>
    public class InventoryItemPlugBlockEnergyCapacity : IDeepEquatable<InventoryItemPlugBlockEnergyCapacity>
    {
        public int CapacityValue { get; }
        public DefinitionHashPointer<DestinyEnergyTypeDefinition> EnergyType { get; }
        public DestinyEnergyType EnergyTypeEnumValue { get; }

        [JsonConstructor]
        internal InventoryItemPlugBlockEnergyCapacity(int capacityValue, uint energyTypeHash, DestinyEnergyType energyType)
        {
            CapacityValue = capacityValue;
            EnergyType = new DefinitionHashPointer<DestinyEnergyTypeDefinition>(energyTypeHash, DefinitionsEnum.DestinyEnergyTypeDefinition);
            EnergyTypeEnumValue = energyType;
        }

        public bool DeepEquals(InventoryItemPlugBlockEnergyCapacity other)
        {
            return other != null &&
                   CapacityValue == other.CapacityValue &&
                   EnergyType.DeepEquals(other.EnergyType) &&
                   EnergyTypeEnumValue == other.EnergyTypeEnumValue;
        }
    }
}
