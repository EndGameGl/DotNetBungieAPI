namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public class DestinyRecordTitleBlock : IDeepEquatable<DestinyRecordTitleBlock>
{
    [JsonPropertyName("hasTitle")]
    public bool HasTitle { get; set; }

    [JsonPropertyName("titlesByGender")]
    public Dictionary<Destiny.DestinyGender, string> TitlesByGender { get; set; }

    /// <summary>
    ///     For those who prefer to use the definitions.
    /// </summary>
    [JsonPropertyName("titlesByGenderHash")]
    public Dictionary<uint, string> TitlesByGenderHash { get; set; }

    [JsonPropertyName("gildingTrackingRecordHash")]
    public uint? GildingTrackingRecordHash { get; set; }

    public bool DeepEquals(DestinyRecordTitleBlock? other)
    {
        return other is not null &&
               HasTitle == other.HasTitle &&
               TitlesByGender.DeepEqualsDictionaryNaive(other.TitlesByGender) &&
               TitlesByGenderHash.DeepEqualsDictionaryNaive(other.TitlesByGenderHash) &&
               GildingTrackingRecordHash == other.GildingTrackingRecordHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyRecordTitleBlock? other)
    {
        if (other is null) return;
        if (HasTitle != other.HasTitle)
        {
            HasTitle = other.HasTitle;
            OnPropertyChanged(nameof(HasTitle));
        }
        if (!TitlesByGender.DeepEqualsDictionaryNaive(other.TitlesByGender))
        {
            TitlesByGender = other.TitlesByGender;
            OnPropertyChanged(nameof(TitlesByGender));
        }
        if (!TitlesByGenderHash.DeepEqualsDictionaryNaive(other.TitlesByGenderHash))
        {
            TitlesByGenderHash = other.TitlesByGenderHash;
            OnPropertyChanged(nameof(TitlesByGenderHash));
        }
        if (GildingTrackingRecordHash != other.GildingTrackingRecordHash)
        {
            GildingTrackingRecordHash = other.GildingTrackingRecordHash;
            OnPropertyChanged(nameof(GildingTrackingRecordHash));
        }
    }
}