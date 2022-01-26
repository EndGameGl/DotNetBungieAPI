namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeMetricChildEntry : IDeepEquatable<DestinyPresentationNodeMetricChildEntry>
{
    [JsonPropertyName("metricHash")]
    public uint MetricHash { get; set; }

    public bool DeepEquals(DestinyPresentationNodeMetricChildEntry? other)
    {
        return other is not null &&
               MetricHash == other.MetricHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPresentationNodeMetricChildEntry? other)
    {
        if (other is null) return;
        if (MetricHash != other.MetricHash)
        {
            MetricHash = other.MetricHash;
            OnPropertyChanged(nameof(MetricHash));
        }
    }
}