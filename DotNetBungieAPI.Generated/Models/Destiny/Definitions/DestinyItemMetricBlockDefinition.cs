namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The metrics available for display and selection on an item.
/// </summary>
public class DestinyItemMetricBlockDefinition : IDeepEquatable<DestinyItemMetricBlockDefinition>
{
    /// <summary>
    ///     Hash identifiers for any DestinyPresentationNodeDefinition entry that can be used to list available metrics. Any metric listed directly below these nodes, or in any of these nodes' children will be made available for selection.
    /// </summary>
    [JsonPropertyName("availableMetricCategoryNodeHashes")]
    public List<uint> AvailableMetricCategoryNodeHashes { get; set; }

    public bool DeepEquals(DestinyItemMetricBlockDefinition? other)
    {
        return other is not null &&
               AvailableMetricCategoryNodeHashes.DeepEqualsListNaive(other.AvailableMetricCategoryNodeHashes);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemMetricBlockDefinition? other)
    {
        if (other is null) return;
        if (!AvailableMetricCategoryNodeHashes.DeepEqualsListNaive(other.AvailableMetricCategoryNodeHashes))
        {
            AvailableMetricCategoryNodeHashes = other.AvailableMetricCategoryNodeHashes;
            OnPropertyChanged(nameof(AvailableMetricCategoryNodeHashes));
        }
    }
}