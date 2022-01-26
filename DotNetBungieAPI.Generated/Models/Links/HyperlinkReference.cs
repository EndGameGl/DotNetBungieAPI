namespace DotNetBungieAPI.Generated.Models.Links;

public class HyperlinkReference : IDeepEquatable<HyperlinkReference>
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    public bool DeepEquals(HyperlinkReference? other)
    {
        return other is not null &&
               Title == other.Title &&
               Url == other.Url;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(HyperlinkReference? other)
    {
        if (other is null) return;
        if (Title != other.Title)
        {
            Title = other.Title;
            OnPropertyChanged(nameof(Title));
        }
        if (Url != other.Url)
        {
            Url = other.Url;
            OnPropertyChanged(nameof(Url));
        }
    }
}