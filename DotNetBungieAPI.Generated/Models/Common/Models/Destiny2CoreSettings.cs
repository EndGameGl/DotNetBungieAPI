namespace DotNetBungieAPI.Generated.Models.Common.Models;

public class Destiny2CoreSettings
{
    [JsonPropertyName("collectionRootNode")]
    public uint? CollectionRootNode { get; set; }

    [JsonPropertyName("badgesRootNode")]
    public uint? BadgesRootNode { get; set; }

    [JsonPropertyName("recordsRootNode")]
    public uint? RecordsRootNode { get; set; }

    [JsonPropertyName("medalsRootNode")]
    public uint? MedalsRootNode { get; set; }

    [JsonPropertyName("metricsRootNode")]
    public uint? MetricsRootNode { get; set; }

    [JsonPropertyName("activeTriumphsRootNodeHash")]
    public uint? ActiveTriumphsRootNodeHash { get; set; }

    [JsonPropertyName("activeSealsRootNodeHash")]
    public uint? ActiveSealsRootNodeHash { get; set; }

    [JsonPropertyName("legacyTriumphsRootNodeHash")]
    public uint? LegacyTriumphsRootNodeHash { get; set; }

    [JsonPropertyName("legacySealsRootNodeHash")]
    public uint? LegacySealsRootNodeHash { get; set; }

    [JsonPropertyName("medalsRootNodeHash")]
    public uint? MedalsRootNodeHash { get; set; }

    [JsonPropertyName("exoticCatalystsRootNodeHash")]
    public uint? ExoticCatalystsRootNodeHash { get; set; }

    [JsonPropertyName("loreRootNodeHash")]
    public uint? LoreRootNodeHash { get; set; }

    [JsonPropertyName("craftingRootNodeHash")]
    public uint? CraftingRootNodeHash { get; set; }

    [JsonPropertyName("loadoutConstantsHash")]
    public uint? LoadoutConstantsHash { get; set; }

    [JsonPropertyName("guardianRankConstantsHash")]
    public uint? GuardianRankConstantsHash { get; set; }

    [JsonPropertyName("guardianRanksRootNodeHash")]
    public uint? GuardianRanksRootNodeHash { get; set; }

    [JsonPropertyName("currentRankProgressionHashes")]
    public List<uint> CurrentRankProgressionHashes { get; set; }

    [JsonPropertyName("insertPlugFreeProtectedPlugItemHashes")]
    public List<uint> InsertPlugFreeProtectedPlugItemHashes { get; set; }

    [JsonPropertyName("insertPlugFreeBlockedSocketTypeHashes")]
    public List<uint> InsertPlugFreeBlockedSocketTypeHashes { get; set; }

    [JsonPropertyName("undiscoveredCollectibleImage")]
    public string? UndiscoveredCollectibleImage { get; set; }

    [JsonPropertyName("ammoTypeHeavyIcon")]
    public string? AmmoTypeHeavyIcon { get; set; }

    [JsonPropertyName("ammoTypeSpecialIcon")]
    public string? AmmoTypeSpecialIcon { get; set; }

    [JsonPropertyName("ammoTypePrimaryIcon")]
    public string? AmmoTypePrimaryIcon { get; set; }

    [JsonPropertyName("currentSeasonalArtifactHash")]
    public uint? CurrentSeasonalArtifactHash { get; set; }

    [JsonPropertyName("currentSeasonHash")]
    public uint? CurrentSeasonHash { get; set; }

    [JsonPropertyName("seasonalChallengesPresentationNodeHash")]
    public uint? SeasonalChallengesPresentationNodeHash { get; set; }

    [JsonPropertyName("futureSeasonHashes")]
    public List<uint> FutureSeasonHashes { get; set; }

    [JsonPropertyName("pastSeasonHashes")]
    public List<uint> PastSeasonHashes { get; set; }
}
