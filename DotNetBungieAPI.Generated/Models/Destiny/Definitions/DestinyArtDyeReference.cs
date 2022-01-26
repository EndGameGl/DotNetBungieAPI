namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyArtDyeReference : IDeepEquatable<DestinyArtDyeReference>
{
    [JsonPropertyName("artDyeChannelHash")]
    public uint ArtDyeChannelHash { get; set; }

    public bool DeepEquals(DestinyArtDyeReference? other)
    {
        return other is not null &&
               ArtDyeChannelHash == other.ArtDyeChannelHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyArtDyeReference? other)
    {
        if (other is null) return;
        if (ArtDyeChannelHash != other.ArtDyeChannelHash)
        {
            ArtDyeChannelHash = other.ArtDyeChannelHash;
            OnPropertyChanged(nameof(ArtDyeChannelHash));
        }
    }
}