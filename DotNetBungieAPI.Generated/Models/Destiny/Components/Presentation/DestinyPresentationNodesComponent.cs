namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Presentation;

public class DestinyPresentationNodesComponent : IDeepEquatable<DestinyPresentationNodesComponent>
{
    [JsonPropertyName("nodes")]
    public Dictionary<uint, Destiny.Components.Presentation.DestinyPresentationNodeComponent> Nodes { get; set; }

    public bool DeepEquals(DestinyPresentationNodesComponent? other)
    {
        return other is not null &&
               Nodes.DeepEqualsDictionary(other.Nodes);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPresentationNodesComponent? other)
    {
        if (other is null) return;
        if (!Nodes.DeepEqualsDictionary(other.Nodes))
        {
            Nodes = other.Nodes;
            OnPropertyChanged(nameof(Nodes));
        }
    }
}