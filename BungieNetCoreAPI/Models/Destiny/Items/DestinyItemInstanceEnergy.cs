using NetBungieAPI.Models.Destiny.Definitions.EnergyTypes;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Items
{
    public sealed record DestinyItemInstanceEnergy
    {
        [JsonPropertyName("energyTypeHash")]
        public DefinitionHashPointer<DestinyEnergyTypeDefinition> EnergyType { get; init; } = DefinitionHashPointer<DestinyEnergyTypeDefinition>.Empty;
        [JsonPropertyName("energyType")]
        public DestinyEnergyType EnergyTypeEnumValue { get; init; }
        [JsonPropertyName("energyCapacity")]
        public int EnergyCapacity { get; init; }
        [JsonPropertyName("energyUsed")]
        public int EnergyUsed { get; init; }
        [JsonPropertyName("energyUnused")]
        public int EnergyUnused { get; init; }
    }
}
