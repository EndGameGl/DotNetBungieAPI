using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Common.Models;

public sealed class Destiny2CoreSettings
{

    [JsonPropertyName("collectionRootNode")]
    public uint CollectionRootNode { get; init; } // DestinyPresentationNodeDefinition

    [JsonPropertyName("badgesRootNode")]
    public uint BadgesRootNode { get; init; } // DestinyPresentationNodeDefinition

    [JsonPropertyName("recordsRootNode")]
    public uint RecordsRootNode { get; init; } // DestinyPresentationNodeDefinition

    [JsonPropertyName("medalsRootNode")]
    public uint MedalsRootNode { get; init; } // DestinyPresentationNodeDefinition

    [JsonPropertyName("metricsRootNode")]
    public uint MetricsRootNode { get; init; } // DestinyPresentationNodeDefinition

    [JsonPropertyName("activeTriumphsRootNodeHash")]
    public uint ActiveTriumphsRootNodeHash { get; init; } // DestinyPresentationNodeDefinition

    [JsonPropertyName("activeSealsRootNodeHash")]
    public uint ActiveSealsRootNodeHash { get; init; } // DestinyPresentationNodeDefinition

    [JsonPropertyName("legacyTriumphsRootNodeHash")]
    public uint LegacyTriumphsRootNodeHash { get; init; } // DestinyPresentationNodeDefinition

    [JsonPropertyName("legacySealsRootNodeHash")]
    public uint LegacySealsRootNodeHash { get; init; } // DestinyPresentationNodeDefinition

    [JsonPropertyName("medalsRootNodeHash")]
    public uint MedalsRootNodeHash { get; init; } // DestinyPresentationNodeDefinition

    [JsonPropertyName("exoticCatalystsRootNodeHash")]
    public uint ExoticCatalystsRootNodeHash { get; init; } // DestinyPresentationNodeDefinition

    [JsonPropertyName("loreRootNodeHash")]
    public uint LoreRootNodeHash { get; init; } // DestinyPresentationNodeDefinition

    [JsonPropertyName("currentRankProgressionHashes")]
    public List<uint> CurrentRankProgressionHashes { get; init; } // DestinyProgressionDefinition

    [JsonPropertyName("insertPlugFreeProtectedPlugItemHashes")]
    public List<uint> InsertPlugFreeProtectedPlugItemHashes { get; init; } // DestinyInventoryItemDefinition

    [JsonPropertyName("insertPlugFreeBlockedSocketTypeHashes")]
    public List<uint> InsertPlugFreeBlockedSocketTypeHashes { get; init; } // DestinySocketTypeDefinition

    [JsonPropertyName("undiscoveredCollectibleImage")]
    public string UndiscoveredCollectibleImage { get; init; }

    [JsonPropertyName("ammoTypeHeavyIcon")]
    public string AmmoTypeHeavyIcon { get; init; }

    [JsonPropertyName("ammoTypeSpecialIcon")]
    public string AmmoTypeSpecialIcon { get; init; }

    [JsonPropertyName("ammoTypePrimaryIcon")]
    public string AmmoTypePrimaryIcon { get; init; }

    [JsonPropertyName("currentSeasonalArtifactHash")]
    public uint CurrentSeasonalArtifactHash { get; init; } // DestinyVendorDefinition

    [JsonPropertyName("currentSeasonHash")]
    public uint? CurrentSeasonHash { get; init; } // DestinySeasonDefinition

    [JsonPropertyName("seasonalChallengesPresentationNodeHash")]
    public uint? SeasonalChallengesPresentationNodeHash { get; init; } // DestinyPresentationNodeDefinition

    [JsonPropertyName("futureSeasonHashes")]
    public List<uint> FutureSeasonHashes { get; init; } // DestinySeasonDefinition

    [JsonPropertyName("pastSeasonHashes")]
    public List<uint> PastSeasonHashes { get; init; } // DestinySeasonDefinition
}
