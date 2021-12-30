using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Items;

public sealed class DestinyEnergyCapacityEntry
{

    [JsonPropertyName("capacityValue")]
    public int CapacityValue { get; init; }

    [JsonPropertyName("energyTypeHash")]
    public uint EnergyTypeHash { get; init; }

    [JsonPropertyName("energyType")]
    public Destiny.DestinyEnergyType EnergyType { get; init; }
}
