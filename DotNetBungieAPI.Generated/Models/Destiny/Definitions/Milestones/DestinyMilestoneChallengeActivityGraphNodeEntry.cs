namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public class DestinyMilestoneChallengeActivityGraphNodeEntry : IDeepEquatable<DestinyMilestoneChallengeActivityGraphNodeEntry>
{
    [JsonPropertyName("activityGraphHash")]
    public uint ActivityGraphHash { get; set; }

    [JsonPropertyName("activityGraphNodeHash")]
    public uint ActivityGraphNodeHash { get; set; }

    public bool DeepEquals(DestinyMilestoneChallengeActivityGraphNodeEntry? other)
    {
        return other is not null &&
               ActivityGraphHash == other.ActivityGraphHash &&
               ActivityGraphNodeHash == other.ActivityGraphNodeHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMilestoneChallengeActivityGraphNodeEntry? other)
    {
        if (other is null) return;
        if (ActivityGraphHash != other.ActivityGraphHash)
        {
            ActivityGraphHash = other.ActivityGraphHash;
            OnPropertyChanged(nameof(ActivityGraphHash));
        }
        if (ActivityGraphNodeHash != other.ActivityGraphNodeHash)
        {
            ActivityGraphNodeHash = other.ActivityGraphNodeHash;
            OnPropertyChanged(nameof(ActivityGraphNodeHash));
        }
    }
}