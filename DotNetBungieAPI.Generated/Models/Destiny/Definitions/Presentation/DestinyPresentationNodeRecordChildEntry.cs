namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeRecordChildEntry : IDeepEquatable<DestinyPresentationNodeRecordChildEntry>
{
    [JsonPropertyName("recordHash")]
    public uint RecordHash { get; set; }

    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; set; }

    public bool DeepEquals(DestinyPresentationNodeRecordChildEntry? other)
    {
        return other is not null &&
               RecordHash == other.RecordHash &&
               NodeDisplayPriority == other.NodeDisplayPriority;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPresentationNodeRecordChildEntry? other)
    {
        if (other is null) return;
        if (RecordHash != other.RecordHash)
        {
            RecordHash = other.RecordHash;
            OnPropertyChanged(nameof(RecordHash));
        }
        if (NodeDisplayPriority != other.NodeDisplayPriority)
        {
            NodeDisplayPriority = other.NodeDisplayPriority;
            OnPropertyChanged(nameof(NodeDisplayPriority));
        }
    }
}