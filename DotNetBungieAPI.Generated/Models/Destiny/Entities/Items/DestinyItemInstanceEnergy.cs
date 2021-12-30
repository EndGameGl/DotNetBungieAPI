using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

public sealed class DestinyItemInstanceEnergy
{

    [JsonPropertyName("energyTypeHash")]
    public uint EnergyTypeHash { get; init; }

    [JsonPropertyName("energyType")]
    public Destiny.DestinyEnergyType EnergyType { get; init; }

    [JsonPropertyName("energyCapacity")]
    public int EnergyCapacity { get; init; }

    [JsonPropertyName("energyUsed")]
    public int EnergyUsed { get; init; }

    [JsonPropertyName("energyUnused")]
    public int EnergyUnused { get; init; }
}
