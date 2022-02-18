namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeCollectibleChildEntry : IDeepEquatable<DestinyPresentationNodeCollectibleChildEntry>
{
    [JsonPropertyName("collectibleHash")]
    public uint CollectibleHash { get; set; }

    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; set; }

    public bool DeepEquals(DestinyPresentationNodeCollectibleChildEntry? other)
    {
        return other is not null &&
               CollectibleHash == other.CollectibleHash &&
               NodeDisplayPriority == other.NodeDisplayPriority;
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
        if (NodeDisplayPriority != other.NodeDisplayPriority)
        {
            NodeDisplayPriority = other.NodeDisplayPriority;
            OnPropertyChanged(nameof(NodeDisplayPriority));
        }
    }
}