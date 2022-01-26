namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

/// <summary>
///     As/if presentation nodes begin to host more entities as children, these lists will be added to. One list property exists per type of entity that can be treated as a child of this presentation node, and each holds the identifier of the entity and any associated information needed to display the UI for that entity (if anything)
/// </summary>
public class DestinyPresentationNodeChildrenBlock : IDeepEquatable<DestinyPresentationNodeChildrenBlock>
{
    [JsonPropertyName("presentationNodes")]
    public List<Destiny.Definitions.Presentation.DestinyPresentationNodeChildEntry> PresentationNodes { get; set; }

    [JsonPropertyName("collectibles")]
    public List<Destiny.Definitions.Presentation.DestinyPresentationNodeCollectibleChildEntry> Collectibles { get; set; }

    [JsonPropertyName("records")]
    public List<Destiny.Definitions.Presentation.DestinyPresentationNodeRecordChildEntry> Records { get; set; }

    [JsonPropertyName("metrics")]
    public List<Destiny.Definitions.Presentation.DestinyPresentationNodeMetricChildEntry> Metrics { get; set; }

    public bool DeepEquals(DestinyPresentationNodeChildrenBlock? other)
    {
        return other is not null &&
               PresentationNodes.DeepEqualsList(other.PresentationNodes) &&
               Collectibles.DeepEqualsList(other.Collectibles) &&
               Records.DeepEqualsList(other.Records) &&
               Metrics.DeepEqualsList(other.Metrics);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPresentationNodeChildrenBlock? other)
    {
        if (other is null) return;
        if (!PresentationNodes.DeepEqualsList(other.PresentationNodes))
        {
            PresentationNodes = other.PresentationNodes;
            OnPropertyChanged(nameof(PresentationNodes));
        }
        if (!Collectibles.DeepEqualsList(other.Collectibles))
        {
            Collectibles = other.Collectibles;
            OnPropertyChanged(nameof(Collectibles));
        }
        if (!Records.DeepEqualsList(other.Records))
        {
            Records = other.Records;
            OnPropertyChanged(nameof(Records));
        }
        if (!Metrics.DeepEqualsList(other.Metrics))
        {
            Metrics = other.Metrics;
            OnPropertyChanged(nameof(Metrics));
        }
    }
}