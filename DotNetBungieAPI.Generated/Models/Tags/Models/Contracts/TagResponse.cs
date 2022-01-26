namespace DotNetBungieAPI.Generated.Models.Tags.Models.Contracts;

public class TagResponse : IDeepEquatable<TagResponse>
{
    [JsonPropertyName("tagText")]
    public string TagText { get; set; }

    [JsonPropertyName("ignoreStatus")]
    public Ignores.IgnoreResponse IgnoreStatus { get; set; }

    public bool DeepEquals(TagResponse? other)
    {
        return other is not null &&
               TagText == other.TagText &&
               (IgnoreStatus is not null ? IgnoreStatus.DeepEquals(other.IgnoreStatus) : other.IgnoreStatus is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(TagResponse? other)
    {
        if (other is null) return;
        if (TagText != other.TagText)
        {
            TagText = other.TagText;
            OnPropertyChanged(nameof(TagText));
        }
        if (!IgnoreStatus.DeepEquals(other.IgnoreStatus))
        {
            IgnoreStatus.Update(other.IgnoreStatus);
            OnPropertyChanged(nameof(IgnoreStatus));
        }
    }
}