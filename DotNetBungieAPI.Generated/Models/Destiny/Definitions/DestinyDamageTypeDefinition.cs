using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyDamageTypeDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("transparentIconPath")]
    public string TransparentIconPath { get; init; }

    [JsonPropertyName("showIcon")]
    public bool ShowIcon { get; init; }

    [JsonPropertyName("enumValue")]
    public Destiny.DamageType EnumValue { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
