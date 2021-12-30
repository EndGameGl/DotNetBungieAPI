using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

public sealed class DestinyEnergyCostEntry
{

    [JsonPropertyName("energyCost")]
    public int EnergyCost { get; init; }

    [JsonPropertyName("energyTypeHash")]
    public uint EnergyTypeHash { get; init; }

    [JsonPropertyName("energyType")]
    public Destiny.DestinyEnergyType EnergyType { get; init; }
}
