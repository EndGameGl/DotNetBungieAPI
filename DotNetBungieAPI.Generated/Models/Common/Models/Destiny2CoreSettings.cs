namespace DotNetBungieAPI.Generated.Models.Common.Models;

public class Destiny2CoreSettings : IDeepEquatable<Destiny2CoreSettings>
{
    [JsonPropertyName("collectionRootNode")]
    public uint CollectionRootNode { get; set; }

    [JsonPropertyName("badgesRootNode")]
    public uint BadgesRootNode { get; set; }

    [JsonPropertyName("recordsRootNode")]
    public uint RecordsRootNode { get; set; }

    [JsonPropertyName("medalsRootNode")]
    public uint MedalsRootNode { get; set; }

    [JsonPropertyName("metricsRootNode")]
    public uint MetricsRootNode { get; set; }

    [JsonPropertyName("activeTriumphsRootNodeHash")]
    public uint ActiveTriumphsRootNodeHash { get; set; }

    [JsonPropertyName("activeSealsRootNodeHash")]
    public uint ActiveSealsRootNodeHash { get; set; }

    [JsonPropertyName("legacyTriumphsRootNodeHash")]
    public uint LegacyTriumphsRootNodeHash { get; set; }

    [JsonPropertyName("legacySealsRootNodeHash")]
    public uint LegacySealsRootNodeHash { get; set; }

    [JsonPropertyName("medalsRootNodeHash")]
    public uint MedalsRootNodeHash { get; set; }

    [JsonPropertyName("exoticCatalystsRootNodeHash")]
    public uint ExoticCatalystsRootNodeHash { get; set; }

    [JsonPropertyName("loreRootNodeHash")]
    public uint LoreRootNodeHash { get; set; }

    [JsonPropertyName("currentRankProgressionHashes")]
    public List<uint> CurrentRankProgressionHashes { get; set; }

    [JsonPropertyName("insertPlugFreeProtectedPlugItemHashes")]
    public List<uint> InsertPlugFreeProtectedPlugItemHashes { get; set; }

    [JsonPropertyName("insertPlugFreeBlockedSocketTypeHashes")]
    public List<uint> InsertPlugFreeBlockedSocketTypeHashes { get; set; }

    [JsonPropertyName("undiscoveredCollectibleImage")]
    public string UndiscoveredCollectibleImage { get; set; }

    [JsonPropertyName("ammoTypeHeavyIcon")]
    public string AmmoTypeHeavyIcon { get; set; }

    [JsonPropertyName("ammoTypeSpecialIcon")]
    public string AmmoTypeSpecialIcon { get; set; }

    [JsonPropertyName("ammoTypePrimaryIcon")]
    public string AmmoTypePrimaryIcon { get; set; }

    [JsonPropertyName("currentSeasonalArtifactHash")]
    public uint CurrentSeasonalArtifactHash { get; set; }

    [JsonPropertyName("currentSeasonHash")]
    public uint? CurrentSeasonHash { get; set; }

    [JsonPropertyName("seasonalChallengesPresentationNodeHash")]
    public uint? SeasonalChallengesPresentationNodeHash { get; set; }

    [JsonPropertyName("futureSeasonHashes")]
    public List<uint> FutureSeasonHashes { get; set; }

    [JsonPropertyName("pastSeasonHashes")]
    public List<uint> PastSeasonHashes { get; set; }

    public bool DeepEquals(Destiny2CoreSettings? other)
    {
        return other is not null &&
               CollectionRootNode == other.CollectionRootNode &&
               BadgesRootNode == other.BadgesRootNode &&
               RecordsRootNode == other.RecordsRootNode &&
               MedalsRootNode == other.MedalsRootNode &&
               MetricsRootNode == other.MetricsRootNode &&
               ActiveTriumphsRootNodeHash == other.ActiveTriumphsRootNodeHash &&
               ActiveSealsRootNodeHash == other.ActiveSealsRootNodeHash &&
               LegacyTriumphsRootNodeHash == other.LegacyTriumphsRootNodeHash &&
               LegacySealsRootNodeHash == other.LegacySealsRootNodeHash &&
               MedalsRootNodeHash == other.MedalsRootNodeHash &&
               ExoticCatalystsRootNodeHash == other.ExoticCatalystsRootNodeHash &&
               LoreRootNodeHash == other.LoreRootNodeHash &&
               CurrentRankProgressionHashes.DeepEqualsListNaive(other.CurrentRankProgressionHashes) &&
               InsertPlugFreeProtectedPlugItemHashes.DeepEqualsListNaive(other.InsertPlugFreeProtectedPlugItemHashes) &&
               InsertPlugFreeBlockedSocketTypeHashes.DeepEqualsListNaive(other.InsertPlugFreeBlockedSocketTypeHashes) &&
               UndiscoveredCollectibleImage == other.UndiscoveredCollectibleImage &&
               AmmoTypeHeavyIcon == other.AmmoTypeHeavyIcon &&
               AmmoTypeSpecialIcon == other.AmmoTypeSpecialIcon &&
               AmmoTypePrimaryIcon == other.AmmoTypePrimaryIcon &&
               CurrentSeasonalArtifactHash == other.CurrentSeasonalArtifactHash &&
               CurrentSeasonHash == other.CurrentSeasonHash &&
               SeasonalChallengesPresentationNodeHash == other.SeasonalChallengesPresentationNodeHash &&
               FutureSeasonHashes.DeepEqualsListNaive(other.FutureSeasonHashes) &&
               PastSeasonHashes.DeepEqualsListNaive(other.PastSeasonHashes);
    }
}