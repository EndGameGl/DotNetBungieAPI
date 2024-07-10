using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

[DestinyDefinition(DefinitionsEnum.DestinyFireteamFinderOptionDefinition)]
public sealed record DestinyFireteamFinderOptionDefinition : IDestinyDefinition, IDisplayProperties
{
    [JsonPropertyName("availability")]
    public int Availability { get; init; }

    [JsonPropertyName("codeOptionType")]
    public int CodeOptionType { get; init; }

    [JsonPropertyName("descendingSortPriority")]
    public int DescendingSortPriority { get; init; }

    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("groupHash")]
    public DefinitionHashPointer<DestinyFireteamFinderOptionGroupDefinition> Group { get; init; } =
        DefinitionHashPointer<DestinyFireteamFinderOptionGroupDefinition>.Empty;

    [JsonPropertyName("uiDisplayStyle")]
    public string UiDisplayStyle { get; init; }

    [JsonPropertyName("values")]
    public DestinyFireteamFinderOptionValuesDefinition Values { get; init; }

    [JsonPropertyName("visibility")]
    public int Visibility { get; init; }

    public DefinitionsEnum DefinitionEnumValue =>
        DefinitionsEnum.DestinyFireteamFinderOptionDefinition;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
