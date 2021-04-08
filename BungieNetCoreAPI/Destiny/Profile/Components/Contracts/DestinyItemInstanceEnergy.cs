using NetBungieAPI.Destiny.Definitions;
using NetBungieAPI.Destiny.Definitions.EnergyTypes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyItemInstanceEnergy
    {
        public DefinitionHashPointer<DestinyEnergyTypeDefinition> EnergyType { get; init; }
        public DestinyEnergyType EnergyTypeEnumValue { get; init; }
        public int EnergyCapacity { get; init; }
        public int EnergyUsed { get; init; }
        public int EnergyUnused { get; init; }

        [JsonConstructor]
        internal DestinyItemInstanceEnergy(uint energyTypeHash, DestinyEnergyType energyType, int energyCapacity, int energyUsed, int energyUnused)
        {
            EnergyType = new DefinitionHashPointer<DestinyEnergyTypeDefinition>(energyTypeHash, DefinitionsEnum.DestinyEnergyTypeDefinition);
            EnergyTypeEnumValue = energyType;
            EnergyCapacity = energyCapacity;
            EnergyUsed = energyUsed;
            EnergyUnused = energyUnused;
        }
    }
}
