using DotNetBungieAPI.Models.Destiny.Definitions.EnergyTypes;

namespace DotNetBungieAPI.Models.Destiny.Items
{
    public sealed record DestinyItemInstanceEnergy
    {
        /// <summary>
        ///     The type of energy for this item. Plugs that require Energy can only be inserted if they have the "Any" Energy Type
        ///     or the matching energy type of this item. This is a reference to the DestinyEnergyTypeDefinition for the energy
        ///     type, where you can find extended info about it.
        /// </summary>
        [JsonPropertyName("energyTypeHash")]
        public DefinitionHashPointer<DestinyEnergyTypeDefinition> EnergyType { get; init; } =
            DefinitionHashPointer<DestinyEnergyTypeDefinition>.Empty;

        /// <summary>
        ///     This is the enum version of the Energy Type value, for convenience.
        /// </summary>
        [JsonPropertyName("energyType")]
        public DestinyEnergyType EnergyTypeEnumValue { get; init; }

        /// <summary>
        ///     The total capacity of Energy that the item currently has, regardless of if it is currently being used.
        /// </summary>
        [JsonPropertyName("energyCapacity")]
        public int EnergyCapacity { get; init; }

        /// <summary>
        ///     The amount of Energy currently in use by inserted plugs.
        /// </summary>
        [JsonPropertyName("energyUsed")]
        public int EnergyUsed { get; init; }

        /// <summary>
        ///     The amount of energy still available for inserting new plugs.
        /// </summary>
        [JsonPropertyName("energyUnused")]
        public int EnergyUnused { get; init; }
    }
}