using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Common.Models;

public sealed class Destiny2CoreSettings
{

    [JsonPropertyName("collectionRootNode")]
    public uint CollectionRootNode { get; init; }

    [JsonPropertyName("badgesRootNode")]
    public uint BadgesRootNode { get; init; }

    [JsonPropertyName("recordsRootNode")]
    public uint RecordsRootNode { get; init; }

    [JsonPropertyName("medalsRootNode")]
    public uint MedalsRootNode { get; init; }

    [JsonPropertyName("metricsRootNode")]
    public uint MetricsRootNode { get; init; }

    [JsonPropertyName("activeTriumphsRootNodeHash")]
    public uint ActiveTriumphsRootNodeHash { get; init; }

    [JsonPropertyName("activeSealsRootNodeHash")]
    public uint ActiveSealsRootNodeHash { get; init; }

    [JsonPropertyName("legacyTriumphsRootNodeHash")]
    public uint LegacyTriumphsRootNodeHash { get; init; }

    [JsonPropertyName("legacySealsRootNodeHash")]
    public uint LegacySealsRootNodeHash { get; init; }

    [JsonPropertyName("medalsRootNodeHash")]
    public uint MedalsRootNodeHash { get; init; }

    [JsonPropertyName("exoticCatalystsRootNodeHash")]
    public uint ExoticCatalystsRootNodeHash { get; init; }

    [JsonPropertyName("loreRootNodeHash")]
    public uint LoreRootNodeHash { get; init; }

    [JsonPropertyName("currentRankProgressionHashes")]
    public List<uint> CurrentRankProgressionHashes { get; init; }

    [JsonPropertyName("insertPlugFreeProtectedPlugItemHashes")]
    public List<uint> InsertPlugFreeProtectedPlugItemHashes { get; init; }

    [JsonPropertyName("insertPlugFreeBlockedSocketTypeHashes")]
    public List<uint> InsertPlugFreeBlockedSocketTypeHashes { get; init; }

    [JsonPropertyName("undiscoveredCollectibleImage")]
    public string UndiscoveredCollectibleImage { get; init; }

    [JsonPropertyName("ammoTypeHeavyIcon")]
    public string AmmoTypeHeavyIcon { get; init; }

    [JsonPropertyName("ammoTypeSpecialIcon")]
    public string AmmoTypeSpecialIcon { get; init; }

    [JsonPropertyName("ammoTypePrimaryIcon")]
    public string AmmoTypePrimaryIcon { get; init; }

    [JsonPropertyName("currentSeasonalArtifactHash")]
    public uint CurrentSeasonalArtifactHash { get; init; }

    [JsonPropertyName("currentSeasonHash")]
    public uint? CurrentSeasonHash { get; init; }

    [JsonPropertyName("seasonalChallengesPresentationNodeHash")]
    public uint? SeasonalChallengesPresentationNodeHash { get; init; }

    [JsonPropertyName("futureSeasonHashes")]
    public List<uint> FutureSeasonHashes { get; init; }

    [JsonPropertyName("pastSeasonHashes")]
    public List<uint> PastSeasonHashes { get; init; }
}
