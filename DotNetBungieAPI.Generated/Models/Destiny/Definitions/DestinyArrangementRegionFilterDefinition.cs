namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyArrangementRegionFilterDefinition : IDeepEquatable<DestinyArrangementRegionFilterDefinition>
{
    [JsonPropertyName("artArrangementRegionHash")]
    public uint ArtArrangementRegionHash { get; set; }

    [JsonPropertyName("artArrangementRegionIndex")]
    public int ArtArrangementRegionIndex { get; set; }

    [JsonPropertyName("statHash")]
    public uint StatHash { get; set; }

    [JsonPropertyName("arrangementIndexByStatValue")]
    public Dictionary<int, int> ArrangementIndexByStatValue { get; set; }

    public bool DeepEquals(DestinyArrangementRegionFilterDefinition? other)
    {
        return other is not null &&
               ArtArrangementRegionHash == other.ArtArrangementRegionHash &&
               ArtArrangementRegionIndex == other.ArtArrangementRegionIndex &&
               StatHash == other.StatHash &&
               ArrangementIndexByStatValue.DeepEqualsDictionaryNaive(other.ArrangementIndexByStatValue);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyArrangementRegionFilterDefinition? other)
    {
        if (other is null) return;
        if (ArtArrangementRegionHash != other.ArtArrangementRegionHash)
        {
            ArtArrangementRegionHash = other.ArtArrangementRegionHash;
            OnPropertyChanged(nameof(ArtArrangementRegionHash));
        }
        if (ArtArrangementRegionIndex != other.ArtArrangementRegionIndex)
        {
            ArtArrangementRegionIndex = other.ArtArrangementRegionIndex;
            OnPropertyChanged(nameof(ArtArrangementRegionIndex));
        }
        if (StatHash != other.StatHash)
        {
            StatHash = other.StatHash;
            OnPropertyChanged(nameof(StatHash));
        }
        if (!ArrangementIndexByStatValue.DeepEqualsDictionaryNaive(other.ArrangementIndexByStatValue))
        {
            ArrangementIndexByStatValue = other.ArrangementIndexByStatValue;
            OnPropertyChanged(nameof(ArrangementIndexByStatValue));
        }
    }
}