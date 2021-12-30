using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.EnergyTypes;

public sealed class DestinyEnergyTypeDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("transparentIconPath")]
    public string TransparentIconPath { get; init; }

    [JsonPropertyName("showIcon")]
    public bool ShowIcon { get; init; }

    [JsonPropertyName("enumValue")]
    public Destiny.DestinyEnergyType EnumValue { get; init; }

    [JsonPropertyName("capacityStatHash")]
    public uint? CapacityStatHash { get; init; }

    [JsonPropertyName("costStatHash")]
    public uint CostStatHash { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
