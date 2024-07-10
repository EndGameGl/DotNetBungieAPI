using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

[DestinyDefinition(DefinitionsEnum.DestinyFireteamFinderConstantsDefinition)]
public sealed record DestinyFireteamFinderConstantsDefinition
    : IDestinyDefinition,
        IDisplayProperties
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    public DefinitionsEnum DefinitionEnumValue =>
        DefinitionsEnum.DestinyFireteamFinderConstantsDefinition;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
