namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

[DestinyDefinition(DefinitionsEnum.DestinyFireteamFinderActivityGraphDefinition)]
public sealed class DestinyFireteamFinderActivityGraphDefinition : IDestinyDefinition, IDisplayProperties
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyFireteamFinderActivityGraphDefinition;

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    [JsonPropertyName("color")]
    public Destiny.Misc.DestinyColor? Color { get; init; }

    [JsonPropertyName("isPlayerElectedDifficultyNode")]
    public bool IsPlayerElectedDifficultyNode { get; init; }

    [JsonPropertyName("parentHash")]
    public DefinitionHashPointer<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition> ParentHash { get; init; }

    [JsonPropertyName("children")]
    public DefinitionHashPointer<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition>[]? Children { get; init; }

    [JsonPropertyName("selfAndAllDescendantHashes")]
    public DefinitionHashPointer<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition>[]? SelfAndAllDescendantHashes { get; init; }

    [JsonPropertyName("relatedActivitySetHashes")]
    public DefinitionHashPointer<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivitySetDefinition>[]? RelatedActivitySetHashes { get; init; }

    [JsonPropertyName("specificActivitySetHash")]
    public DefinitionHashPointer<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivitySetDefinition> SpecificActivitySetHash { get; init; }

    [JsonPropertyName("relatedActivityHashes")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyActivityDefinition>[]? RelatedActivityHashes { get; init; }

    [JsonPropertyName("relatedDirectorNodes")]
    public Destiny.Definitions.FireteamFinder.DestinyActivityGraphReference[]? RelatedDirectorNodes { get; init; }

    [JsonPropertyName("relatedInteractableActivities")]
    public Destiny.Definitions.FireteamFinder.DestinyActivityInteractableReference[]? RelatedInteractableActivities { get; init; }

    [JsonPropertyName("relatedLocationHashes")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyLocationDefinition>[]? RelatedLocationHashes { get; init; }

    [JsonPropertyName("sortMatchmadeActivitiesToFront")]
    public bool SortMatchmadeActivitiesToFront { get; init; }

    [JsonPropertyName("enabledOnTreeTypesListEnum")]
    public Destiny.DestinyActivityTreeType[]? EnabledOnTreeTypesListEnum { get; init; }

    [JsonPropertyName("activityTreeChildSortMode")]
    public Destiny.DestinyActivityTreeChildSortMode ActivityTreeChildSortMode { get; init; }

    [JsonPropertyName("sortPriority")]
    public int? SortPriority { get; init; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
