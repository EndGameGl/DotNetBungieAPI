namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeRecordChildEntry : IDeepEquatable<DestinyPresentationNodeRecordChildEntry>
{
    [JsonPropertyName("recordHash")]
    public uint RecordHash { get; set; }

    public bool DeepEquals(DestinyPresentationNodeRecordChildEntry? other)
    {
        return other is not null &&
               RecordHash == other.RecordHash;
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
    }
}