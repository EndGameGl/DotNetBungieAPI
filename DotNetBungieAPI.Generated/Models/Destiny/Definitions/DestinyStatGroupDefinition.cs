using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyStatGroupDefinition
{

    [JsonPropertyName("maximumValue")]
    public int MaximumValue { get; init; }

    [JsonPropertyName("uiPosition")]
    public int UiPosition { get; init; }

    [JsonPropertyName("scaledStats")]
    public List<Destiny.Definitions.DestinyStatDisplayDefinition> ScaledStats { get; init; }

    [JsonPropertyName("overrides")]
    public Dictionary<uint, Destiny.Definitions.DestinyStatOverrideDefinition> Overrides { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
