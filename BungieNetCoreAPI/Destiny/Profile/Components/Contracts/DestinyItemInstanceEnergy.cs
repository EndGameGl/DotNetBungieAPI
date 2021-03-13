using NetBungieApi.Destiny.Definitions;
using NetBungieApi.Destiny.Definitions.EnergyTypes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Profile.Components.Contracts
{
    public class DestinyItemInstanceEnergy
    {
        public DefinitionHashPointer<DestinyEnergyTypeDefinition> EnergyType { get; }
        public DestinyEnergyType EnergyTypeEnumValue { get; }
        public int EnergyCapacity { get; }
        public int EnergyUsed { get; }
        public int EnergyUnused { get; }

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
