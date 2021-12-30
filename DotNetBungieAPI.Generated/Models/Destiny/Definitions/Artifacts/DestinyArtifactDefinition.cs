using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Artifacts;

public sealed class DestinyArtifactDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("translationBlock")]
    public Destiny.Definitions.DestinyItemTranslationBlockDefinition TranslationBlock { get; init; }

    [JsonPropertyName("tiers")]
    public List<Destiny.Definitions.Artifacts.DestinyArtifactTierDefinition> Tiers { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
