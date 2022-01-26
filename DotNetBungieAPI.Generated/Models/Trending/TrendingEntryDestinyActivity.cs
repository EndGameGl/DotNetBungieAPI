namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingEntryDestinyActivity : IDeepEquatable<TrendingEntryDestinyActivity>
{
    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; set; }

    [JsonPropertyName("status")]
    public Destiny.Activities.DestinyPublicActivityStatus Status { get; set; }

    public bool DeepEquals(TrendingEntryDestinyActivity? other)
    {
        return other is not null &&
               ActivityHash == other.ActivityHash &&
               (Status is not null ? Status.DeepEquals(other.Status) : other.Status is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(TrendingEntryDestinyActivity? other)
    {
        if (other is null) return;
        if (ActivityHash != other.ActivityHash)
        {
            ActivityHash = other.ActivityHash;
            OnPropertyChanged(nameof(ActivityHash));
        }
        if (!Status.DeepEquals(other.Status))
        {
            Status.Update(other.Status);
            OnPropertyChanged(nameof(Status));
        }
    }
}