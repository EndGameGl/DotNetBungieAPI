namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Collectibles;

public class DestinyCollectibleStateBlock : IDeepEquatable<DestinyCollectibleStateBlock>
{
    [JsonPropertyName("obscuredOverrideItemHash")]
    public uint? ObscuredOverrideItemHash { get; set; }

    [JsonPropertyName("requirements")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock Requirements { get; set; }

    public bool DeepEquals(DestinyCollectibleStateBlock? other)
    {
        return other is not null &&
               ObscuredOverrideItemHash == other.ObscuredOverrideItemHash &&
               (Requirements is not null ? Requirements.DeepEquals(other.Requirements) : other.Requirements is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyCollectibleStateBlock? other)
    {
        if (other is null) return;
        if (ObscuredOverrideItemHash != other.ObscuredOverrideItemHash)
        {
            ObscuredOverrideItemHash = other.ObscuredOverrideItemHash;
            OnPropertyChanged(nameof(ObscuredOverrideItemHash));
        }
        if (!Requirements.DeepEquals(other.Requirements))
        {
            Requirements.Update(other.Requirements);
            OnPropertyChanged(nameof(Requirements));
        }
    }
}