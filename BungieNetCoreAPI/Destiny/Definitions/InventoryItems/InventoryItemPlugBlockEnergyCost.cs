using NetBungieAPI.Destiny.Definitions.EnergyTypes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Some plugs cost Energy, which is a stat on the item that can be increased by other plugs (that, at least in Armor 2.0, have a "masterworks-like" mechanic for upgrading). If a plug has costs, the details of that cost are defined here.
    /// </summary>
    public class InventoryItemPlugBlockEnergyCost : IDeepEquatable<InventoryItemPlugBlockEnergyCost>
    {
        public int EnergyCost { get; }
        public DefinitionHashPointer<DestinyEnergyTypeDefinition> EnergyType { get; }
        public DestinyEnergyType EnergyTypeEnumValue { get; }

        [JsonConstructor]
        internal InventoryItemPlugBlockEnergyCost(int energyCost, uint energyTypeHash, DestinyEnergyType energyType)
        {
            EnergyCost = energyCost;
            EnergyType = new DefinitionHashPointer<DestinyEnergyTypeDefinition>(energyTypeHash, DefinitionsEnum.DestinyEnergyTypeDefinition);
            EnergyTypeEnumValue = energyType;
        }

        public bool DeepEquals(InventoryItemPlugBlockEnergyCost other)
        {
            return other != null &&
                   EnergyCost == other.EnergyCost &&
                   EnergyType.DeepEquals(other.EnergyType) &&
                   EnergyTypeEnumValue == other.EnergyTypeEnumValue;
        }
    }
}