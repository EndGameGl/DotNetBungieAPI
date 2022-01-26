namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeCollectibleChildEntry : IDeepEquatable<DestinyPresentationNodeCollectibleChildEntry>
{
    [JsonPropertyName("collectibleHash")]
    public uint CollectibleHash { get; set; }

    public bool DeepEquals(DestinyPresentationNodeCollectibleChildEntry? other)
    {
        return other is not null &&
               CollectibleHash == other.CollectibleHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPresentationNodeCollectibleChildEntry? other)
    {
        if (other is null) return;
        if (CollectibleHash != other.CollectibleHash)
        {
            CollectibleHash = other.CollectibleHash;
            OnPropertyChanged(nameof(CollectibleHash));
        }
    }
}