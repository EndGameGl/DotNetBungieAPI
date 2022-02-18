namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeChildEntry : IDeepEquatable<DestinyPresentationNodeChildEntry>
{
    [JsonPropertyName("presentationNodeHash")]
    public uint PresentationNodeHash { get; set; }

    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; set; }

    public bool DeepEquals(DestinyPresentationNodeChildEntry? other)
    {
        return other is not null &&
               PresentationNodeHash == other.PresentationNodeHash &&
               NodeDisplayPriority == other.NodeDisplayPriority;
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
        if (NodeDisplayPriority != other.NodeDisplayPriority)
        {
            NodeDisplayPriority = other.NodeDisplayPriority;
            OnPropertyChanged(nameof(NodeDisplayPriority));
        }
    }
}