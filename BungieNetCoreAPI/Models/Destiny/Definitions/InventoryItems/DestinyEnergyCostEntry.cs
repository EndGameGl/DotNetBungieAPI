using NetBungieAPI.Models.Destiny.Definitions.EnergyTypes;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// Some plugs cost Energy, which is a stat on the item that can be increased by other plugs (that, at least in Armor 2.0, have a "masterworks-like" mechanic for upgrading). If a plug has costs, the details of that cost are defined here.
    /// </summary>
    public sealed record DestinyEnergyCostEntry : IDeepEquatable<DestinyEnergyCostEntry>
    {
        [JsonPropertyName("energyCost")]
        public int EnergyCost { get; init; }
        [JsonPropertyName("energyTypeHash")]
        public DefinitionHashPointer<DestinyEnergyTypeDefinition> EnergyType { get; init; } = DefinitionHashPointer<DestinyEnergyTypeDefinition>.Empty;
        [JsonPropertyName("energyType")]
        public DestinyEnergyType EnergyTypeEnumValue { get; init; }

        public bool DeepEquals(DestinyEnergyCostEntry other)
        {
            return other != null &&
                   EnergyCost == other.EnergyCost &&
                   EnergyType.DeepEquals(other.EnergyType) &&
                   EnergyTypeEnumValue == other.EnergyTypeEnumValue;
        }
    }
}