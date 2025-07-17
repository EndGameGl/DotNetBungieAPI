namespace DotNetBungieAPI.Generated.Models.Common.Models;

public class Destiny2CoreSettings
{
    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("collectionRootNode")]
    public uint? CollectionRootNode { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("badgesRootNode")]
    public uint? BadgesRootNode { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("recordsRootNode")]
    public uint? RecordsRootNode { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("medalsRootNode")]
    public uint? MedalsRootNode { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("metricsRootNode")]
    public uint? MetricsRootNode { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("activeTriumphsRootNodeHash")]
    public uint? ActiveTriumphsRootNodeHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("activeSealsRootNodeHash")]
    public uint? ActiveSealsRootNodeHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("legacyTriumphsRootNodeHash")]
    public uint? LegacyTriumphsRootNodeHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("legacySealsRootNodeHash")]
    public uint? LegacySealsRootNodeHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("medalsRootNodeHash")]
    public uint? MedalsRootNodeHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("exoticCatalystsRootNodeHash")]
    public uint? ExoticCatalystsRootNodeHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("loreRootNodeHash")]
    public uint? LoreRootNodeHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("craftingRootNodeHash")]
    public uint? CraftingRootNodeHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Loadouts.DestinyLoadoutConstantsDefinition>("Destiny.Definitions.Loadouts.DestinyLoadoutConstantsDefinition")]
    [JsonPropertyName("loadoutConstantsHash")]
    public uint? LoadoutConstantsHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.GuardianRanks.DestinyGuardianRankConstantsDefinition>("Destiny.Definitions.GuardianRanks.DestinyGuardianRankConstantsDefinition")]
    [JsonPropertyName("guardianRankConstantsHash")]
    public uint? GuardianRankConstantsHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderConstantsDefinition>("Destiny.Definitions.FireteamFinder.DestinyFireteamFinderConstantsDefinition")]
    [JsonPropertyName("fireteamFinderConstantsHash")]
    public uint? FireteamFinderConstantsHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Items.DestinyInventoryItemConstantsDefinition>("Destiny.Definitions.Items.DestinyInventoryItemConstantsDefinition")]
    [JsonPropertyName("inventoryItemConstantsHash")]
    public uint? InventoryItemConstantsHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Inventory.DestinyItemFilterDefinition>("Destiny.Definitions.Inventory.DestinyItemFilterDefinition")]
    [JsonPropertyName("featuredItemsListHash")]
    public uint? FeaturedItemsListHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Sockets.DestinyPlugSetDefinition>("Destiny.Definitions.Sockets.DestinyPlugSetDefinition")]
    [JsonPropertyName("armorArchetypePlugSetHash")]
    public uint? ArmorArchetypePlugSetHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Seasons.DestinyEventCardDefinition>("Destiny.Definitions.Seasons.DestinyEventCardDefinition")]
    [JsonPropertyName("seasonalHubEventCardHash")]
    public uint? SeasonalHubEventCardHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("guardianRanksRootNodeHash")]
    public uint? GuardianRanksRootNodeHash { get; set; }

    [Destiny2DefinitionList<Destiny.Definitions.DestinyProgressionDefinition>("Destiny.Definitions.DestinyProgressionDefinition")]
    [JsonPropertyName("currentRankProgressionHashes")]
    public List<uint> CurrentRankProgressionHashes { get; set; }

    [Destiny2DefinitionList<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("insertPlugFreeProtectedPlugItemHashes")]
    public List<uint> InsertPlugFreeProtectedPlugItemHashes { get; set; }

    [Destiny2DefinitionList<Destiny.Definitions.Sockets.DestinySocketTypeDefinition>("Destiny.Definitions.Sockets.DestinySocketTypeDefinition")]
    [JsonPropertyName("insertPlugFreeBlockedSocketTypeHashes")]
    public List<uint> InsertPlugFreeBlockedSocketTypeHashes { get; set; }

    [Destiny2DefinitionList<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition>("Destiny.Definitions.FireteamFinder.DestinyFireteamFinderActivityGraphDefinition")]
    [JsonPropertyName("enabledFireteamFinderActivityGraphHashes")]
    public List<uint> EnabledFireteamFinderActivityGraphHashes { get; set; }

    [JsonPropertyName("undiscoveredCollectibleImage")]
    public string? UndiscoveredCollectibleImage { get; set; }

    [JsonPropertyName("ammoTypeHeavyIcon")]
    public string? AmmoTypeHeavyIcon { get; set; }

    [JsonPropertyName("ammoTypeSpecialIcon")]
    public string? AmmoTypeSpecialIcon { get; set; }

    [JsonPropertyName("ammoTypePrimaryIcon")]
    public string? AmmoTypePrimaryIcon { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyVendorDefinition>("Destiny.Definitions.DestinyVendorDefinition")]
    [JsonPropertyName("currentSeasonalArtifactHash")]
    public uint? CurrentSeasonalArtifactHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Seasons.DestinySeasonDefinition>("Destiny.Definitions.Seasons.DestinySeasonDefinition")]
    [JsonPropertyName("currentSeasonHash")]
    public uint? CurrentSeasonHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("seasonalChallengesPresentationNodeHash")]
    public uint? SeasonalChallengesPresentationNodeHash { get; set; }

    [Destiny2DefinitionList<Destiny.Definitions.Seasons.DestinySeasonDefinition>("Destiny.Definitions.Seasons.DestinySeasonDefinition")]
    [JsonPropertyName("futureSeasonHashes")]
    public List<uint> FutureSeasonHashes { get; set; }

    [Destiny2DefinitionList<Destiny.Definitions.Seasons.DestinySeasonDefinition>("Destiny.Definitions.Seasons.DestinySeasonDefinition")]
    [JsonPropertyName("pastSeasonHashes")]
    public List<uint> PastSeasonHashes { get; set; }
}
