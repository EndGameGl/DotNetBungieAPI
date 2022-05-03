namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeCraftableChildEntry : IDeepEquatable<DestinyPresentationNodeCraftableChildEntry>
{
    [JsonPropertyName("craftableItemHash")]
    public uint CraftableItemHash { get; set; }

    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; set; }

    public bool DeepEquals(DestinyPresentationNodeCraftableChildEntry? other)
    {
        return other is not null &&
               CraftableItemHash == other.CraftableItemHash &&
               NodeDisplayPriority == other.NodeDisplayPriority;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPresentationNodeCraftableChildEntry? other)
    {
        if (other is null) return;
        if (CraftableItemHash != other.CraftableItemHash)
        {
            CraftableItemHash = other.CraftableItemHash;
            OnPropertyChanged(nameof(CraftableItemHash));
        }
        if (NodeDisplayPriority != other.NodeDisplayPriority)
        {
            NodeDisplayPriority = other.NodeDisplayPriority;
            OnPropertyChanged(nameof(NodeDisplayPriority));
        }
    }
}