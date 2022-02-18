namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationNodeMetricChildEntry : IDeepEquatable<DestinyPresentationNodeMetricChildEntry>
{
    [JsonPropertyName("metricHash")]
    public uint MetricHash { get; set; }

    /// <summary>
    ///     Use this value to sort the presentation node children in ascending order.
    /// </summary>
    [JsonPropertyName("nodeDisplayPriority")]
    public uint NodeDisplayPriority { get; set; }

    public bool DeepEquals(DestinyPresentationNodeMetricChildEntry? other)
    {
        return other is not null &&
               MetricHash == other.MetricHash &&
               NodeDisplayPriority == other.NodeDisplayPriority;
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
        if (NodeDisplayPriority != other.NodeDisplayPriority)
        {
            NodeDisplayPriority = other.NodeDisplayPriority;
            OnPropertyChanged(nameof(NodeDisplayPriority));
        }
    }
}