namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Seasons;

/// <summary>
///     Defines a canonical "Season" of Destiny: a range of a few months where the game highlights certain challenges, provides new loot, has new Clan-related rewards and celebrates various seasonal events.
/// </summary>
public class DestinySeasonDefinition : IDeepEquatable<DestinySeasonDefinition>
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    [JsonPropertyName("backgroundImagePath")]
    public string BackgroundImagePath { get; set; }

    [JsonPropertyName("seasonNumber")]
    public int SeasonNumber { get; set; }

    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; set; }

    [JsonPropertyName("seasonPassHash")]
    public uint? SeasonPassHash { get; set; }

    [JsonPropertyName("seasonPassProgressionHash")]
    public uint? SeasonPassProgressionHash { get; set; }

    [JsonPropertyName("artifactItemHash")]
    public uint? ArtifactItemHash { get; set; }

    [JsonPropertyName("sealPresentationNodeHash")]
    public uint? SealPresentationNodeHash { get; set; }

    [JsonPropertyName("seasonalChallengesPresentationNodeHash")]
    public uint? SeasonalChallengesPresentationNodeHash { get; set; }

    /// <summary>
    ///     Optional - Defines the promotional text, images, and links to preview this season.
    /// </summary>
    [JsonPropertyName("preview")]
    public Destiny.Definitions.Seasons.DestinySeasonPreviewDefinition Preview { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }

    public bool DeepEquals(DestinySeasonDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               BackgroundImagePath == other.BackgroundImagePath &&
               SeasonNumber == other.SeasonNumber &&
               StartDate == other.StartDate &&
               EndDate == other.EndDate &&
               SeasonPassHash == other.SeasonPassHash &&
               SeasonPassProgressionHash == other.SeasonPassProgressionHash &&
               ArtifactItemHash == other.ArtifactItemHash &&
               SealPresentationNodeHash == other.SealPresentationNodeHash &&
               SeasonalChallengesPresentationNodeHash == other.SeasonalChallengesPresentationNodeHash &&
               (Preview is not null ? Preview.DeepEquals(other.Preview) : other.Preview is null) &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinySeasonDefinition? other)
    {
        if (other is null) return;
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
        if (BackgroundImagePath != other.BackgroundImagePath)
        {
            BackgroundImagePath = other.BackgroundImagePath;
            OnPropertyChanged(nameof(BackgroundImagePath));
        }
        if (SeasonNumber != other.SeasonNumber)
        {
            SeasonNumber = other.SeasonNumber;
            OnPropertyChanged(nameof(SeasonNumber));
        }
        if (StartDate != other.StartDate)
        {
            StartDate = other.StartDate;
            OnPropertyChanged(nameof(StartDate));
        }
        if (EndDate != other.EndDate)
        {
            EndDate = other.EndDate;
            OnPropertyChanged(nameof(EndDate));
        }
        if (SeasonPassHash != other.SeasonPassHash)
        {
            SeasonPassHash = other.SeasonPassHash;
            OnPropertyChanged(nameof(SeasonPassHash));
        }
        if (SeasonPassProgressionHash != other.SeasonPassProgressionHash)
        {
            SeasonPassProgressionHash = other.SeasonPassProgressionHash;
            OnPropertyChanged(nameof(SeasonPassProgressionHash));
        }
        if (ArtifactItemHash != other.ArtifactItemHash)
        {
            ArtifactItemHash = other.ArtifactItemHash;
            OnPropertyChanged(nameof(ArtifactItemHash));
        }
        if (SealPresentationNodeHash != other.SealPresentationNodeHash)
        {
            SealPresentationNodeHash = other.SealPresentationNodeHash;
            OnPropertyChanged(nameof(SealPresentationNodeHash));
        }
        if (SeasonalChallengesPresentationNodeHash != other.SeasonalChallengesPresentationNodeHash)
        {
            SeasonalChallengesPresentationNodeHash = other.SeasonalChallengesPresentationNodeHash;
            OnPropertyChanged(nameof(SeasonalChallengesPresentationNodeHash));
        }
        if (!Preview.DeepEquals(other.Preview))
        {
            Preview.Update(other.Preview);
            OnPropertyChanged(nameof(Preview));
        }
        if (Hash != other.Hash)
        {
            Hash = other.Hash;
            OnPropertyChanged(nameof(Hash));
        }
        if (Index != other.Index)
        {
            Index = other.Index;
            OnPropertyChanged(nameof(Index));
        }
        if (Redacted != other.Redacted)
        {
            Redacted = other.Redacted;
            OnPropertyChanged(nameof(Redacted));
        }
    }
}