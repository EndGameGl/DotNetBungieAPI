namespace DotNetBungieAPI.Models.Destiny.Definitions.Common;

[DestinyDefinition(DefinitionsEnum.DestinyGlobalConstantsDefinition)]
public sealed class DestinyGlobalConstantsDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyGlobalConstantsDefinition;

    /// <summary>
    ///     Assorted constants for Pathfinder objectives
    /// </summary>
    [JsonPropertyName("pathfinderConstants")]
    public Destiny.Definitions.Common.DestinyPathfinderConstantsDefinition? PathfinderConstants { get; init; }

    [JsonPropertyName("collectionsRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> CollectionsRootNodeHash { get; init; }

    [JsonPropertyName("collectionBadgesRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> CollectionBadgesRootNodeHash { get; init; }

    [JsonPropertyName("activeTriumphsRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> ActiveTriumphsRootNodeHash { get; init; }

    [JsonPropertyName("activeSealsRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> ActiveSealsRootNodeHash { get; init; }

    [JsonPropertyName("legacyTriumphsRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> LegacyTriumphsRootNodeHash { get; init; }

    [JsonPropertyName("legacySealsRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> LegacySealsRootNodeHash { get; init; }

    [JsonPropertyName("medalsRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> MedalsRootNodeHash { get; init; }

    [JsonPropertyName("exoticCatalystsRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> ExoticCatalystsRootNodeHash { get; init; }

    [JsonPropertyName("loreRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> LoreRootNodeHash { get; init; }

    [JsonPropertyName("metricsRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> MetricsRootNodeHash { get; init; }

    [JsonPropertyName("craftingRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> CraftingRootNodeHash { get; init; }

    [JsonPropertyName("guardianRanksRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> GuardianRanksRootNodeHash { get; init; }

    [JsonPropertyName("seasonalHubEventCardHash")]
    public DefinitionHashPointer<Destiny.Definitions.Seasons.DestinyEventCardDefinition> SeasonalHubEventCardHash { get; init; }

    [JsonPropertyName("destinyRewardPassRankSealImages")]
    public Destiny.Definitions.Common.DestinyRewardPassRankSealImages? DestinyRewardPassRankSealImages { get; init; }

    [JsonPropertyName("destinySeasonalHubRankIconImages")]
    public Destiny.Definitions.Common.DestinySeasonalHubRankIconImages? DestinySeasonalHubRankIconImages { get; init; }

    [JsonPropertyName("armorArchetypePlugSetHash")]
    public DefinitionHashPointer<Destiny.Definitions.Sockets.DestinyPlugSetDefinition> ArmorArchetypePlugSetHash { get; init; }

    [JsonPropertyName("featuredItemsListHash")]
    public DefinitionHashPointer<Destiny.Definitions.Inventory.DestinyItemFilterDefinition> FeaturedItemsListHash { get; init; }

    [JsonPropertyName("portalActivityGraphRootNodesWithIcons")]
    public Dictionary<uint, string>? PortalActivityGraphRootNodesWithIcons { get; init; }

    [JsonPropertyName("orderRewardsUnlockValueHashesToRewardItemHashes")]
    public Dictionary<uint, uint>? OrderRewardsUnlockValueHashesToRewardItemHashes { get; init; }

    [JsonPropertyName("questItemTraitToFeaturedQuestImagePath")]
    public Dictionary<uint, string>? QuestItemTraitToFeaturedQuestImagePath { get; init; }

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
