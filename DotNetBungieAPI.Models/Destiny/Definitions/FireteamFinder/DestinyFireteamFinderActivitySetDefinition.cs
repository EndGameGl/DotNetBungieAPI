using System.Collections.ObjectModel;
using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Activities;

namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

[DestinyDefinition(DefinitionsEnum.DestinyFireteamFinderActivitySetDefinition)]
public sealed record DestinyFireteamFinderActivitySetDefinition : IDestinyDefinition
{
    [JsonPropertyName("maximumPartySize")]
    public int MaximumPartySize { get; init; }

    [JsonPropertyName("optionHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyFireteamFinderOptionDefinition>
    > Options { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinyFireteamFinderOptionDefinition>>.Empty;

    [JsonPropertyName("labelHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyFireteamFinderLabelDefinition>
    > Labels { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinyFireteamFinderLabelDefinition>>.Empty;

    [JsonPropertyName("activityGraphHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyFireteamFinderActivityGraphDefinition>
    > ActivityGraphs { get; init; } =
        ReadOnlyCollection<
            DefinitionHashPointer<DestinyFireteamFinderActivityGraphDefinition>
        >.Empty;

    [JsonPropertyName("activityHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyActivityDefinition>
    > Activities { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinyActivityDefinition>>.Empty;

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
