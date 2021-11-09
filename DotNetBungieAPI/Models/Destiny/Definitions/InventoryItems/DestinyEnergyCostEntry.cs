using DotNetBungieAPI.Models.Destiny.Definitions.EnergyTypes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    ///     Some plugs cost Energy, which is a stat on the item that can be increased by other plugs (that, at least in Armor
    ///     2.0, have a "masterworks-like" mechanic for upgrading). If a plug has costs, the details of that cost are defined
    ///     here.
    /// </summary>
    public sealed record DestinyEnergyCostEntry : IDeepEquatable<DestinyEnergyCostEntry>
    {
        /// <summary>
        ///     The Energy cost for inserting this plug.
        /// </summary>
        [JsonPropertyName("energyCost")]
        public int EnergyCost { get; init; }

        /// <summary>
        ///     The type of energy that this plug costs, as a reference to the DestinyEnergyTypeDefinition of the energy type.
        /// </summary>
        [JsonPropertyName("energyTypeHash")]
        public DefinitionHashPointer<DestinyEnergyTypeDefinition> EnergyType { get; init; } =
            DefinitionHashPointer<DestinyEnergyTypeDefinition>.Empty;

        /// <summary>
        ///     The type of energy that this plug costs, in enum form.
        /// </summary>
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