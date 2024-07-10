using DotNetBungieAPI.Models.Destiny.Definitions.GuardianRanks;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Definitions.Loadouts;
using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using DotNetBungieAPI.Models.Destiny.Definitions.Progressions;
using DotNetBungieAPI.Models.Destiny.Definitions.Seasons;
using DotNetBungieAPI.Models.Destiny.Definitions.SocketTypes;
using DotNetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace DotNetBungieAPI.Models.Common;

public sealed record Destiny2CoreSettings
{
    [JsonPropertyName("collectionRootNode")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> CollectionRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("badgesRootNode")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> BadgesRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("recordsRootNode")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordsRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("medalsRootNode")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> SealsRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("metricsRootNode")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> MetricsRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("activeTriumphsRootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> ActiveTriumphsRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("activeSealsRootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> ActiveSealsRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("legacyTriumphsRootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> LegacyTriumphsRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("legacySealsRootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> LegacySealsRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("medalsRootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> MedalsRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("exoticCatalystsRootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> ExoticCatalystsRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("loreRootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> LoreRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("craftingRootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> CraftingRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("loadoutConstantsHash")]
    public DefinitionHashPointer<DestinyLoadoutConstantsDefinition> LoadoutConstants { get; init; } =
        DefinitionHashPointer<DestinyLoadoutConstantsDefinition>.Empty;

    [JsonPropertyName("guardianRankConstantsHash")]
    public DefinitionHashPointer<DestinyGuardianRankConstantsDefinition> GuardianRankConstants { get; init; } =
        DefinitionHashPointer<DestinyGuardianRankConstantsDefinition>.Empty;

    [JsonPropertyName("guardianRanksRootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> GuardianRanksRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("currentRankProgressionHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyProgressionDefinition>
    > CurrentRankProgressions { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyProgressionDefinition>>.Empty;

    [JsonPropertyName("insertPlugFreeProtectedPlugItemHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyInventoryItemDefinition>
    > InsertPlugFreeProtectedPlugItems { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyInventoryItemDefinition>>.Empty;

    [JsonPropertyName("insertPlugFreeBlockedSocketTypeHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinySocketTypeDefinition>
    > InsertPlugFreeBlockedSocketTypes { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinySocketTypeDefinition>>.Empty;

    [JsonPropertyName("undiscoveredCollectibleImage")]
    public BungieNetResource UndiscoveredCollectibleImage { get; init; }

    [JsonPropertyName("ammoTypeHeavyIcon")]
    public BungieNetResource AmmoTypeHeavyIcon { get; init; }

    [JsonPropertyName("ammoTypeSpecialIcon")]
    public BungieNetResource AmmoTypeSpecialIcon { get; init; }

    [JsonPropertyName("ammoTypePrimaryIcon")]
    public BungieNetResource AmmoTypePrimaryIcon { get; init; }

    [JsonPropertyName("currentSeasonalArtifactHash")]
    public DefinitionHashPointer<DestinyVendorDefinition> CurrentSeasonalArtifact { get; init; } =
        DefinitionHashPointer<DestinyVendorDefinition>.Empty;

    [JsonPropertyName("currentSeasonHash")]
    public DefinitionHashPointer<DestinySeasonDefinition> СurrentSeason { get; init; } =
        DefinitionHashPointer<DestinySeasonDefinition>.Empty;

    [JsonPropertyName("seasonalChallengesPresentationNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> SeasonalChallengesPresentationNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("futureSeasonHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinySeasonDefinition>
    > FutureSeasons { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinySeasonDefinition>>.Empty;

    [JsonPropertyName("pastSeasonHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinySeasonDefinition>
    > PastSeasons { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinySeasonDefinition>>.Empty;
}
