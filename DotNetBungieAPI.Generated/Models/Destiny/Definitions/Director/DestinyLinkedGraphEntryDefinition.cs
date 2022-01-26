namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

public class DestinyLinkedGraphEntryDefinition : IDeepEquatable<DestinyLinkedGraphEntryDefinition>
{
    [JsonPropertyName("activityGraphHash")]
    public uint ActivityGraphHash { get; set; }

    public bool DeepEquals(DestinyLinkedGraphEntryDefinition? other)
    {
        return other is not null &&
               ActivityGraphHash == other.ActivityGraphHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyLinkedGraphEntryDefinition? other)
    {
        if (other is null) return;
        if (ActivityGraphHash != other.ActivityGraphHash)
        {
            ActivityGraphHash = other.ActivityGraphHash;
            OnPropertyChanged(nameof(ActivityGraphHash));
        }
    }
}