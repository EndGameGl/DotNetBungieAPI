using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

[DestinyDefinition(DefinitionsEnum.DestinyFireteamFinderConstantsDefinition)]
public sealed record DestinyFireteamFinderConstantsDefinition
    : IDestinyDefinition,
        IDisplayProperties
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("fireteamFinderActivityGraphRootCategoryHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyFireteamFinderActivityGraphDefinition>
    > FireteamFinderActivityGraphRootCategories { get; init; } =
        ReadOnlyCollections<
            DefinitionHashPointer<DestinyFireteamFinderActivityGraphDefinition>
        >.Empty;

    [JsonPropertyName("allFireteamFinderActivityHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyActivityDefinition>
    > AllFireteamFinderActivities { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyActivityDefinition>>.Empty;

    [JsonPropertyName("guardianOathDisplayProperties")]
    public DestinyDisplayPropertiesDefinition? GuardianOathDisplayProperties { get; init; }

    [JsonPropertyName("guardianOathTenets")]
    public ReadOnlyCollection<DestinyDisplayPropertiesDefinition> GuardianOathTenets { get; init; } =
        ReadOnlyCollections<DestinyDisplayPropertiesDefinition>.Empty;

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
