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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(Destiny2CoreSettings? other)
    {
        if (other is null) return;
        if (CollectionRootNode != other.CollectionRootNode)
        {
            CollectionRootNode = other.CollectionRootNode;
            OnPropertyChanged(nameof(CollectionRootNode));
        }
        if (BadgesRootNode != other.BadgesRootNode)
        {
            BadgesRootNode = other.BadgesRootNode;
            OnPropertyChanged(nameof(BadgesRootNode));
        }
        if (RecordsRootNode != other.RecordsRootNode)
        {
            RecordsRootNode = other.RecordsRootNode;
            OnPropertyChanged(nameof(RecordsRootNode));
        }
        if (MedalsRootNode != other.MedalsRootNode)
        {
            MedalsRootNode = other.MedalsRootNode;
            OnPropertyChanged(nameof(MedalsRootNode));
        }
        if (MetricsRootNode != other.MetricsRootNode)
        {
            MetricsRootNode = other.MetricsRootNode;
            OnPropertyChanged(nameof(MetricsRootNode));
        }
        if (ActiveTriumphsRootNodeHash != other.ActiveTriumphsRootNodeHash)
        {
            ActiveTriumphsRootNodeHash = other.ActiveTriumphsRootNodeHash;
            OnPropertyChanged(nameof(ActiveTriumphsRootNodeHash));
        }
        if (ActiveSealsRootNodeHash != other.ActiveSealsRootNodeHash)
        {
            ActiveSealsRootNodeHash = other.ActiveSealsRootNodeHash;
            OnPropertyChanged(nameof(ActiveSealsRootNodeHash));
        }
        if (LegacyTriumphsRootNodeHash != other.LegacyTriumphsRootNodeHash)
        {
            LegacyTriumphsRootNodeHash = other.LegacyTriumphsRootNodeHash;
            OnPropertyChanged(nameof(LegacyTriumphsRootNodeHash));
        }
        if (LegacySealsRootNodeHash != other.LegacySealsRootNodeHash)
        {
            LegacySealsRootNodeHash = other.LegacySealsRootNodeHash;
            OnPropertyChanged(nameof(LegacySealsRootNodeHash));
        }
        if (MedalsRootNodeHash != other.MedalsRootNodeHash)
        {
            MedalsRootNodeHash = other.MedalsRootNodeHash;
            OnPropertyChanged(nameof(MedalsRootNodeHash));
        }
        if (ExoticCatalystsRootNodeHash != other.ExoticCatalystsRootNodeHash)
        {
            ExoticCatalystsRootNodeHash = other.ExoticCatalystsRootNodeHash;
            OnPropertyChanged(nameof(ExoticCatalystsRootNodeHash));
        }
        if (LoreRootNodeHash != other.LoreRootNodeHash)
        {
            LoreRootNodeHash = other.LoreRootNodeHash;
            OnPropertyChanged(nameof(LoreRootNodeHash));
        }
        if (!CurrentRankProgressionHashes.DeepEqualsListNaive(other.CurrentRankProgressionHashes))
        {
            CurrentRankProgressionHashes = other.CurrentRankProgressionHashes;
            OnPropertyChanged(nameof(CurrentRankProgressionHashes));
        }
        if (!InsertPlugFreeProtectedPlugItemHashes.DeepEqualsListNaive(other.InsertPlugFreeProtectedPlugItemHashes))
        {
            InsertPlugFreeProtectedPlugItemHashes = other.InsertPlugFreeProtectedPlugItemHashes;
            OnPropertyChanged(nameof(InsertPlugFreeProtectedPlugItemHashes));
        }
        if (!InsertPlugFreeBlockedSocketTypeHashes.DeepEqualsListNaive(other.InsertPlugFreeBlockedSocketTypeHashes))
        {
            InsertPlugFreeBlockedSocketTypeHashes = other.InsertPlugFreeBlockedSocketTypeHashes;
            OnPropertyChanged(nameof(InsertPlugFreeBlockedSocketTypeHashes));
        }
        if (UndiscoveredCollectibleImage != other.UndiscoveredCollectibleImage)
        {
            UndiscoveredCollectibleImage = other.UndiscoveredCollectibleImage;
            OnPropertyChanged(nameof(UndiscoveredCollectibleImage));
        }
        if (AmmoTypeHeavyIcon != other.AmmoTypeHeavyIcon)
        {
            AmmoTypeHeavyIcon = other.AmmoTypeHeavyIcon;
            OnPropertyChanged(nameof(AmmoTypeHeavyIcon));
        }
        if (AmmoTypeSpecialIcon != other.AmmoTypeSpecialIcon)
        {
            AmmoTypeSpecialIcon = other.AmmoTypeSpecialIcon;
            OnPropertyChanged(nameof(AmmoTypeSpecialIcon));
        }
        if (AmmoTypePrimaryIcon != other.AmmoTypePrimaryIcon)
        {
            AmmoTypePrimaryIcon = other.AmmoTypePrimaryIcon;
            OnPropertyChanged(nameof(AmmoTypePrimaryIcon));
        }
        if (CurrentSeasonalArtifactHash != other.CurrentSeasonalArtifactHash)
        {
            CurrentSeasonalArtifactHash = other.CurrentSeasonalArtifactHash;
            OnPropertyChanged(nameof(CurrentSeasonalArtifactHash));
        }
        if (CurrentSeasonHash != other.CurrentSeasonHash)
        {
            CurrentSeasonHash = other.CurrentSeasonHash;
            OnPropertyChanged(nameof(CurrentSeasonHash));
        }
        if (SeasonalChallengesPresentationNodeHash != other.SeasonalChallengesPresentationNodeHash)
        {
            SeasonalChallengesPresentationNodeHash = other.SeasonalChallengesPresentationNodeHash;
            OnPropertyChanged(nameof(SeasonalChallengesPresentationNodeHash));
        }
        if (!FutureSeasonHashes.DeepEqualsListNaive(other.FutureSeasonHashes))
        {
            FutureSeasonHashes = other.FutureSeasonHashes;
            OnPropertyChanged(nameof(FutureSeasonHashes));
        }
        if (!PastSeasonHashes.DeepEqualsListNaive(other.PastSeasonHashes))
        {
            PastSeasonHashes = other.PastSeasonHashes;
            OnPropertyChanged(nameof(PastSeasonHashes));
        }
    }
}