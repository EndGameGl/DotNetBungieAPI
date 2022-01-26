namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyPresentationChildBlock : IDeepEquatable<DestinyPresentationChildBlock>
{
    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; set; }

    [JsonPropertyName("parentPresentationNodeHashes")]
    public List<uint> ParentPresentationNodeHashes { get; set; }

    [JsonPropertyName("displayStyle")]
    public Destiny.DestinyPresentationDisplayStyle DisplayStyle { get; set; }

    public bool DeepEquals(DestinyPresentationChildBlock? other)
    {
        return other is not null &&
               PresentationNodeType == other.PresentationNodeType &&
               ParentPresentationNodeHashes.DeepEqualsListNaive(other.ParentPresentationNodeHashes) &&
               DisplayStyle == other.DisplayStyle;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPresentationChildBlock? other)
    {
        if (other is null) return;
        if (PresentationNodeType != other.PresentationNodeType)
        {
            PresentationNodeType = other.PresentationNodeType;
            OnPropertyChanged(nameof(PresentationNodeType));
        }
        if (!ParentPresentationNodeHashes.DeepEqualsListNaive(other.ParentPresentationNodeHashes))
        {
            ParentPresentationNodeHashes = other.ParentPresentationNodeHashes;
            OnPropertyChanged(nameof(ParentPresentationNodeHashes));
        }
        if (DisplayStyle != other.DisplayStyle)
        {
            DisplayStyle = other.DisplayStyle;
            OnPropertyChanged(nameof(DisplayStyle));
        }
    }
}