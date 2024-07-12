using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

[DestinyDefinition(DefinitionsEnum.DestinyFireteamFinderOptionDefinition)]
public sealed record DestinyFireteamFinderOptionDefinition : IDestinyDefinition, IDisplayProperties
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("descendingSortPriority")]
    public int DescendingSortPriority { get; init; }

    [JsonPropertyName("groupHash")]
    public DefinitionHashPointer<DestinyFireteamFinderOptionGroupDefinition> Group { get; init; } =
        DefinitionHashPointer<DestinyFireteamFinderOptionGroupDefinition>.Empty;

    [JsonPropertyName("codeOptionType")]
    public FireteamFinderCodeOptionType CodeOptionType { get; init; }

    [JsonPropertyName("availability")]
    public FireteamFinderOptionAvailability Availability { get; init; }

    [JsonPropertyName("visibility")]
    public FireteamFinderOptionVisibility Visibility { get; init; }

    [JsonPropertyName("uiDisplayStyle")]
    public string UiDisplayStyle { get; init; }

    [JsonPropertyName("creatorSettings")]
    public DestinyFireteamFinderOptionCreatorSettings CreatorSettings { get; init; }

    [JsonPropertyName("searcherSettings")]
    public DestinyFireteamFinderOptionSearcherSettings SearcherSettings { get; init; }

    [JsonPropertyName("values")]
    public DestinyFireteamFinderOptionValues Values { get; init; }

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
