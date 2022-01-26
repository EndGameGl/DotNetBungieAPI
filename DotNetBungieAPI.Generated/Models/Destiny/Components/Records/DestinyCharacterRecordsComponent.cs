namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Records;

public class DestinyCharacterRecordsComponent : IDeepEquatable<DestinyCharacterRecordsComponent>
{
    [JsonPropertyName("featuredRecordHashes")]
    public List<uint> FeaturedRecordHashes { get; set; }

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

    public bool DeepEquals(DestinyCharacterRecordsComponent? other)
    {
        return other is not null &&
               FeaturedRecordHashes.DeepEqualsListNaive(other.FeaturedRecordHashes) &&
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

    public void Update(DestinyCharacterRecordsComponent? other)
    {
        if (other is null) return;
        if (!FeaturedRecordHashes.DeepEqualsListNaive(other.FeaturedRecordHashes))
        {
            FeaturedRecordHashes = other.FeaturedRecordHashes;
            OnPropertyChanged(nameof(FeaturedRecordHashes));
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