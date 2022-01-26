namespace DotNetBungieAPI.Generated.Models.Queries;

public class PagedQuery : IDeepEquatable<PagedQuery>
{
    [JsonPropertyName("itemsPerPage")]
    public int ItemsPerPage { get; set; }

    [JsonPropertyName("currentPage")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("requestContinuationToken")]
    public string RequestContinuationToken { get; set; }

    public bool DeepEquals(PagedQuery? other)
    {
        return other is not null &&
               ItemsPerPage == other.ItemsPerPage &&
               CurrentPage == other.CurrentPage &&
               RequestContinuationToken == other.RequestContinuationToken;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(PagedQuery? other)
    {
        if (other is null) return;
        if (ItemsPerPage != other.ItemsPerPage)
        {
            ItemsPerPage = other.ItemsPerPage;
            OnPropertyChanged(nameof(ItemsPerPage));
        }
        if (CurrentPage != other.CurrentPage)
        {
            CurrentPage = other.CurrentPage;
            OnPropertyChanged(nameof(CurrentPage));
        }
        if (RequestContinuationToken != other.RequestContinuationToken)
        {
            RequestContinuationToken = other.RequestContinuationToken;
            OnPropertyChanged(nameof(RequestContinuationToken));
        }
    }
}