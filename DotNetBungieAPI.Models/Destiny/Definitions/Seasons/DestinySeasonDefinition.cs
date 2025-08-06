namespace DotNetBungieAPI.Models.Destiny.Definitions.Seasons;

/// <summary>
///     Defines a canonical "Season" of Destiny: a range of a few months where the game highlights certain challenges, provides new loot, has new Clan-related rewards and celebrates various seasonal events.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinySeasonDefinition)]
public sealed class DestinySeasonDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinySeasonDefinition;

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    [JsonPropertyName("backgroundImagePath")]
    public string BackgroundImagePath { get; init; }

    [JsonPropertyName("seasonNumber")]
    public int SeasonNumber { get; init; }

    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [JsonPropertyName("seasonPassHash")]
    public DefinitionHashPointer<Destiny.Definitions.Seasons.DestinySeasonPassDefinition>? SeasonPassHash { get; init; }

    [JsonPropertyName("seasonPassList")]
    public Destiny.Definitions.Seasons.DestinySeasonPassReference[]? SeasonPassList { get; init; }

    [JsonPropertyName("seasonPassProgressionHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyProgressionDefinition>? SeasonPassProgressionHash { get; init; }

    [JsonPropertyName("artifactItemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition>? ArtifactItemHash { get; init; }

    [JsonPropertyName("sealPresentationNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>? SealPresentationNodeHash { get; init; }

    /// <summary>
    ///     A list of Acts for the Episode
    /// </summary>
    [JsonPropertyName("acts")]
    public Destiny.Definitions.Seasons.DestinySeasonActDefinition[]? Acts { get; init; }

    [JsonPropertyName("seasonalChallengesPresentationNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>? SeasonalChallengesPresentationNodeHash { get; init; }

    /// <summary>
    ///     Optional - Defines the promotional text, images, and links to preview this season.
    /// </summary>
    [JsonPropertyName("preview")]
    public Destiny.Definitions.Seasons.DestinySeasonPreviewDefinition? Preview { get; init; }

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
