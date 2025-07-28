namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.FireteamFinder;

public class DestinyFireteamFinderActivityGraphDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    [JsonPropertyName("color")]
    public Destiny.Misc.DestinyColor? Color { get; set; }

    [JsonPropertyName("isPlayerElectedDifficultyNode")]
    public bool IsPlayerElectedDifficultyNode { get; set; }

    [Destiny2Definition<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition>("Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition")]
    [JsonPropertyName("parentHash")]
    public uint? ParentHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition>("Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition")]
    [JsonPropertyName("children")]
    public uint[]? Children { get; set; }

    [Destiny2Definition<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition>("Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition")]
    [JsonPropertyName("selfAndAllDescendantHashes")]
    public uint[]? SelfAndAllDescendantHashes { get; set; }

    [Destiny2Definition<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivitySetDefinition>("Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivitySetDefinition")]
    [JsonPropertyName("relatedActivitySetHashes")]
    public uint[]? RelatedActivitySetHashes { get; set; }

    [Destiny2Definition<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivitySetDefinition>("Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivitySetDefinition")]
    [JsonPropertyName("specificActivitySetHash")]
    public uint? SpecificActivitySetHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyActivityDefinition>("Destiny.Definitions.DestinyActivityDefinition")]
    [JsonPropertyName("relatedActivityHashes")]
    public uint[]? RelatedActivityHashes { get; set; }

    [JsonPropertyName("relatedDirectorNodes")]
    public Destiny.Definitions.FireteamFinder.DestinyActivityGraphReference[]? RelatedDirectorNodes { get; set; }

    [JsonPropertyName("relatedInteractableActivities")]
    public Destiny.Definitions.FireteamFinder.DestinyActivityInteractableReference[]? RelatedInteractableActivities { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyLocationDefinition>("Destiny.Definitions.DestinyLocationDefinition")]
    [JsonPropertyName("relatedLocationHashes")]
    public uint[]? RelatedLocationHashes { get; set; }

    [JsonPropertyName("sortMatchmadeActivitiesToFront")]
    public bool SortMatchmadeActivitiesToFront { get; set; }

    [JsonPropertyName("enabledOnTreeTypesListEnum")]
    public Destiny.DestinyActivityTreeType[]? EnabledOnTreeTypesListEnum { get; set; }

    [JsonPropertyName("activityTreeChildSortMode")]
    public Destiny.DestinyActivityTreeChildSortMode ActivityTreeChildSortMode { get; set; }

    [JsonPropertyName("sortPriority")]
    public int? SortPriority { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }
}
