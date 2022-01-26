namespace DotNetBungieAPI.Generated.Models.Ignores;

public class IgnoreResponse : IDeepEquatable<IgnoreResponse>
{
    [JsonPropertyName("isIgnored")]
    public bool IsIgnored { get; set; }

    [JsonPropertyName("ignoreFlags")]
    public Ignores.IgnoreStatus IgnoreFlags { get; set; }

    public bool DeepEquals(IgnoreResponse? other)
    {
        return other is not null &&
               IsIgnored == other.IsIgnored &&
               IgnoreFlags == other.IgnoreFlags;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(IgnoreResponse? other)
    {
        if (other is null) return;
        if (IsIgnored != other.IsIgnored)
        {
            IsIgnored = other.IsIgnored;
            OnPropertyChanged(nameof(IsIgnored));
        }
        if (IgnoreFlags != other.IgnoreFlags)
        {
            IgnoreFlags = other.IgnoreFlags;
            OnPropertyChanged(nameof(IgnoreFlags));
        }
    }
}