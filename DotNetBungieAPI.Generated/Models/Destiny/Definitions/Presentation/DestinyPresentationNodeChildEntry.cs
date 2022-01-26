namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeChildEntry : IDeepEquatable<DestinyPresentationNodeChildEntry>
{
    [JsonPropertyName("presentationNodeHash")]
    public uint PresentationNodeHash { get; set; }

    public bool DeepEquals(DestinyPresentationNodeChildEntry? other)
    {
        return other is not null &&
               PresentationNodeHash == other.PresentationNodeHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPresentationNodeChildEntry? other)
    {
        if (other is null) return;
        if (PresentationNodeHash != other.PresentationNodeHash)
        {
            PresentationNodeHash = other.PresentationNodeHash;
            OnPropertyChanged(nameof(PresentationNodeHash));
        }
    }
}