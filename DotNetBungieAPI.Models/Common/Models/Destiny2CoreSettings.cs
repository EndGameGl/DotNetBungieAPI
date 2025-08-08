namespace DotNetBungieAPI.Models.Common.Models;

public sealed class Destiny2CoreSettings
{
    [JsonPropertyName("collectionRootNode")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> CollectionRootNode { get; init; }

    [JsonPropertyName("badgesRootNode")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> BadgesRootNode { get; init; }

    [JsonPropertyName("recordsRootNode")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> RecordsRootNode { get; init; }

    [JsonPropertyName("medalsRootNode")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> MedalsRootNode { get; init; }

    [JsonPropertyName("metricsRootNode")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> MetricsRootNode { get; init; }

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

    [JsonPropertyName("craftingRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> CraftingRootNodeHash { get; init; }

    [JsonPropertyName("loadoutConstantsHash")]
    public DefinitionHashPointer<Destiny.Definitions.Loadouts.DestinyLoadoutConstantsDefinition> LoadoutConstantsHash { get; init; }

    [JsonPropertyName("guardianRankConstantsHash")]
    public DefinitionHashPointer<Destiny.Definitions.GuardianRanks.DestinyGuardianRankConstantsDefinition> GuardianRankConstantsHash { get; init; }

    [JsonPropertyName("fireteamFinderConstantsHash")]
    public DefinitionHashPointer<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderConstantsDefinition> FireteamFinderConstantsHash { get; init; }

    [JsonPropertyName("inventoryItemConstantsHash")]
    public DefinitionHashPointer<Destiny.Definitions.Items.DestinyInventoryItemConstantsDefinition> InventoryItemConstantsHash { get; init; }

    [JsonPropertyName("featuredItemsListHash")]
    public DefinitionHashPointer<Destiny.Definitions.Inventory.DestinyItemFilterDefinition> FeaturedItemsListHash { get; init; }

    [JsonPropertyName("armorArchetypePlugSetHash")]
    public DefinitionHashPointer<Destiny.Definitions.Sockets.DestinyPlugSetDefinition> ArmorArchetypePlugSetHash { get; init; }

    [JsonPropertyName("seasonalHubEventCardHash")]
    public DefinitionHashPointer<Destiny.Definitions.Seasons.DestinyEventCardDefinition> SeasonalHubEventCardHash { get; init; }

    [JsonPropertyName("guardianRanksRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> GuardianRanksRootNodeHash { get; init; }

    [JsonPropertyName("currentRankProgressionHashes")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyProgressionDefinition>[]? CurrentRankProgressionHashes { get; init; }

    [JsonPropertyName("insertPlugFreeProtectedPlugItemHashes")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition>[]? InsertPlugFreeProtectedPlugItemHashes { get; init; }

    [JsonPropertyName("insertPlugFreeBlockedSocketTypeHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Sockets.DestinySocketTypeDefinition>[]? InsertPlugFreeBlockedSocketTypeHashes { get; init; }

    [JsonPropertyName("enabledFireteamFinderActivityGraphHashes")]
    public DefinitionHashPointer<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition>[]? EnabledFireteamFinderActivityGraphHashes { get; init; }

    [JsonPropertyName("undiscoveredCollectibleImage")]
    public string UndiscoveredCollectibleImage { get; init; }

    [JsonPropertyName("ammoTypeHeavyIcon")]
    public string AmmoTypeHeavyIcon { get; init; }

    [JsonPropertyName("ammoTypeSpecialIcon")]
    public string AmmoTypeSpecialIcon { get; init; }

    [JsonPropertyName("ammoTypePrimaryIcon")]
    public string AmmoTypePrimaryIcon { get; init; }

    [JsonPropertyName("currentSeasonalArtifactHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyVendorDefinition> CurrentSeasonalArtifactHash { get; init; }

    [JsonPropertyName("currentSeasonHash")]
    public DefinitionHashPointer<Destiny.Definitions.Seasons.DestinySeasonDefinition> CurrentSeasonHash { get; init; }

    [JsonPropertyName("seasonalChallengesPresentationNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> SeasonalChallengesPresentationNodeHash { get; init; }

    [JsonPropertyName("futureSeasonHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Seasons.DestinySeasonDefinition>[]? FutureSeasonHashes { get; init; }

    [JsonPropertyName("pastSeasonHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Seasons.DestinySeasonDefinition>[]? PastSeasonHashes { get; init; }
}
