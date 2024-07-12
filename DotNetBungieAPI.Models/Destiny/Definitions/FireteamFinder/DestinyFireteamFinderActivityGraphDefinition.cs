using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.Locations;

namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

[DestinyDefinition(DefinitionsEnum.DestinyFireteamFinderActivityGraphDefinition)]
public sealed record DestinyFireteamFinderActivityGraphDefinition
    : IDestinyDefinition,
        IDisplayProperties
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("color")]
    public DestinyColor Color { get; init; }

    [JsonPropertyName("isPlayerElectedDifficultyNode")]
    public bool IsPlayerElectedDifficultyNode { get; init; }

    [JsonPropertyName("parentHash")]
    public DefinitionHashPointer<DestinyFireteamFinderActivityGraphDefinition> Parent { get; init; } =
        DefinitionHashPointer<DestinyFireteamFinderActivityGraphDefinition>.Empty;

    [JsonPropertyName("children")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyFireteamFinderActivityGraphDefinition>
    > Children { get; init; } =
        ReadOnlyCollections<
            DefinitionHashPointer<DestinyFireteamFinderActivityGraphDefinition>
        >.Empty;

    [JsonPropertyName("selfAndAllDescendantHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyFireteamFinderActivityGraphDefinition>
    > SelfAndAllDescendants { get; init; } =
        ReadOnlyCollections<
            DefinitionHashPointer<DestinyFireteamFinderActivityGraphDefinition>
        >.Empty;

    [JsonPropertyName("relatedActivitySetHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyFireteamFinderActivitySetDefinition>
    > RelatedActivitySets { get; init; } =
        ReadOnlyCollections<
            DefinitionHashPointer<DestinyFireteamFinderActivitySetDefinition>
        >.Empty;

    [JsonPropertyName("specificActivitySetHash")]
    public DefinitionHashPointer<DestinyFireteamFinderActivitySetDefinition> SpecificActivitySet { get; init; } =
        DefinitionHashPointer<DestinyFireteamFinderActivitySetDefinition>.Empty;

    [JsonPropertyName("relatedActivityHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyActivityDefinition>
    > RelatedActivities { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyActivityDefinition>>.Empty;

    [JsonPropertyName("relatedDirectorNodes")]
    public ReadOnlyCollection<DestinyActivityGraphReference> RelatedDirectorNodes { get; init; } =
        ReadOnlyCollections<DestinyActivityGraphReference>.Empty;

    [JsonPropertyName("relatedInteractableActivities")]
    public ReadOnlyCollection<DestinyActivityInteractableReference> RelatedInteractableActivities { get; init; } =
        ReadOnlyCollections<DestinyActivityInteractableReference>.Empty;

    [JsonPropertyName("relatedLocationHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyLocationDefinition>
    > RelatedLocations { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyLocationDefinition>>.Empty;

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
