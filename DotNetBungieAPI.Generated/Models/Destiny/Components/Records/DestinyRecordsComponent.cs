namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Records;

public class DestinyRecordsComponent : IDeepEquatable<DestinyRecordsComponent>
{
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

    public bool DeepEquals(DestinyRecordsComponent? other)
    {
        return other is not null &&
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

    public void Update(DestinyRecordsComponent? other)
    {
        if (other is null) return;
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