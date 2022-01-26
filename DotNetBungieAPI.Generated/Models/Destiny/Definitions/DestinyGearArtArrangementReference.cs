namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyGearArtArrangementReference : IDeepEquatable<DestinyGearArtArrangementReference>
{
    [JsonPropertyName("classHash")]
    public uint ClassHash { get; set; }

    [JsonPropertyName("artArrangementHash")]
    public uint ArtArrangementHash { get; set; }

    public bool DeepEquals(DestinyGearArtArrangementReference? other)
    {
        return other is not null &&
               ClassHash == other.ClassHash &&
               ArtArrangementHash == other.ArtArrangementHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyGearArtArrangementReference? other)
    {
        if (other is null) return;
        if (ClassHash != other.ClassHash)
        {
            ClassHash = other.ClassHash;
            OnPropertyChanged(nameof(ClassHash));
        }
        if (ArtArrangementHash != other.ArtArrangementHash)
        {
            ArtArrangementHash = other.ArtArrangementHash;
            OnPropertyChanged(nameof(ArtArrangementHash));
        }
    }
}