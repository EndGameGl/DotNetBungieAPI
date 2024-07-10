using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

[DestinyDefinition(DefinitionsEnum.DestinyFireteamFinderActivityGraphDefinition)]
public sealed record DestinyFireteamFinderActivityGraphDefinition
    : IDestinyDefinition,
        IDisplayProperties
{
    [JsonPropertyName("color")]
    public DestinyColor Color { get; init; }

    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("isPlayerElectedDifficultyNode")]
    public bool IsPlayerElectedDifficultyNode { get; init; }

    public DefinitionsEnum DefinitionEnumValue =>
        DefinitionsEnum.DestinyFireteamFinderActivityGraphDefinition;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
