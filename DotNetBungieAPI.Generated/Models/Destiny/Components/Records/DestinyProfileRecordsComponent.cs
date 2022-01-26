namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Records;

public class DestinyProfileRecordsComponent : IDeepEquatable<DestinyProfileRecordsComponent>
{
    /// <summary>
    ///     Your 'active' Triumphs score, maintained for backwards compatibility.
    /// </summary>
    [JsonPropertyName("score")]
    public int Score { get; set; }

    /// <summary>
    ///     Your 'active' Triumphs score.
    /// </summary>
    [JsonPropertyName("activeScore")]
    public int ActiveScore { get; set; }

    /// <summary>
    ///     Your 'legacy' Triumphs score.
    /// </summary>
    [JsonPropertyName("legacyScore")]
    public int LegacyScore { get; set; }

    /// <summary>
    ///     Your 'lifetime' Triumphs score.
    /// </summary>
    [JsonPropertyName("lifetimeScore")]
    public int LifetimeScore { get; set; }

    /// <summary>
    ///     If this profile is tracking a record, this is the hash identifier of the record it is tracking.
    /// </summary>
    [JsonPropertyName("trackedRecordHash")]
    public uint? TrackedRecordHash { get; set; }

    [JsonPropertyName("records")]
    public Dictionary<uint, Destiny.Components.Records.DestinyRecordComponent> Records { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of Triumph categories.
    /// </summary>
    [JsonPropertyName("recordCategoriesRootNodeHash")]
    public uint RecordCategoriesRootNodeHash { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of Triumph Seals.
    /// </summary>
    [JsonPropertyName("recordSealsRootNodeHash")]
    public uint RecordSealsRootNodeHash { get; set; }

    public bool DeepEquals(DestinyProfileRecordsComponent? other)
    {
        return other is not null &&
               Score == other.Score &&
               ActiveScore == other.ActiveScore &&
               LegacyScore == other.LegacyScore &&
               LifetimeScore == other.LifetimeScore &&
               TrackedRecordHash == other.TrackedRecordHash &&
               Records.DeepEqualsDictionary(other.Records) &&
               RecordCategoriesRootNodeHash == other.RecordCategoriesRootNodeHash &&
               RecordSealsRootNodeHash == other.RecordSealsRootNodeHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyProfileRecordsComponent? other)
    {
        if (other is null) return;
        if (Score != other.Score)
        {
            Score = other.Score;
            OnPropertyChanged(nameof(Score));
        }
        if (ActiveScore != other.ActiveScore)
        {
            ActiveScore = other.ActiveScore;
            OnPropertyChanged(nameof(ActiveScore));
        }
        if (LegacyScore != other.LegacyScore)
        {
            LegacyScore = other.LegacyScore;
            OnPropertyChanged(nameof(LegacyScore));
        }
        if (LifetimeScore != other.LifetimeScore)
        {
            LifetimeScore = other.LifetimeScore;
            OnPropertyChanged(nameof(LifetimeScore));
        }
        if (TrackedRecordHash != other.TrackedRecordHash)
        {
            TrackedRecordHash = other.TrackedRecordHash;
            OnPropertyChanged(nameof(TrackedRecordHash));
        }
        if (!Records.DeepEqualsDictionary(other.Records))
        {
            Records = other.Records;
            OnPropertyChanged(nameof(Records));
        }
        if (RecordCategoriesRootNodeHash != other.RecordCategoriesRootNodeHash)
        {
            RecordCategoriesRootNodeHash = other.RecordCategoriesRootNodeHash;
            OnPropertyChanged(nameof(RecordCategoriesRootNodeHash));
        }
        if (RecordSealsRootNodeHash != other.RecordSealsRootNodeHash)
        {
            RecordSealsRootNodeHash = other.RecordSealsRootNodeHash;
            OnPropertyChanged(nameof(RecordSealsRootNodeHash));
        }
    }
}