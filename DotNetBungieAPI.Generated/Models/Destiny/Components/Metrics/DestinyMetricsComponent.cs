namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Metrics;

public class DestinyMetricsComponent : IDeepEquatable<DestinyMetricsComponent>
{
    [JsonPropertyName("metrics")]
    public Dictionary<uint, Destiny.Components.Metrics.DestinyMetricComponent> Metrics { get; set; }

    [JsonPropertyName("metricsRootNodeHash")]
    public uint MetricsRootNodeHash { get; set; }

    public bool DeepEquals(DestinyMetricsComponent? other)
    {
        return other is not null &&
               Metrics.DeepEqualsDictionary(other.Metrics) &&
               MetricsRootNodeHash == other.MetricsRootNodeHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMetricsComponent? other)
    {
        if (other is null) return;
        if (!Metrics.DeepEqualsDictionary(other.Metrics))
        {
            Metrics = other.Metrics;
            OnPropertyChanged(nameof(Metrics));
        }
        if (MetricsRootNodeHash != other.MetricsRootNodeHash)
        {
            MetricsRootNodeHash = other.MetricsRootNodeHash;
            OnPropertyChanged(nameof(MetricsRootNodeHash));
        }
    }
}