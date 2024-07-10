using DotNetBungieAPI.Models.Attributes;

namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

[DestinyDefinition(DefinitionsEnum.DestinyFireteamFinderActivitySetDefinition)]
public sealed record DestinyFireteamFinderActivitySetDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue =>
        DefinitionsEnum.DestinyFireteamFinderActivitySetDefinition;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
