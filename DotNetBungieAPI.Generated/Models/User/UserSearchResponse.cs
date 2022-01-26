namespace DotNetBungieAPI.Generated.Models.User;

public class UserSearchResponse : IDeepEquatable<UserSearchResponse>
{
    [JsonPropertyName("searchResults")]
    public List<User.UserSearchResponseDetail> SearchResults { get; set; }

    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; set; }

    public bool DeepEquals(UserSearchResponse? other)
    {
        return other is not null &&
               SearchResults.DeepEqualsList(other.SearchResults) &&
               Page == other.Page &&
               HasMore == other.HasMore;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(UserSearchResponse? other)
    {
        if (other is null) return;
        if (!SearchResults.DeepEqualsList(other.SearchResults))
        {
            SearchResults = other.SearchResults;
            OnPropertyChanged(nameof(SearchResults));
        }
        if (Page != other.Page)
        {
            Page = other.Page;
            OnPropertyChanged(nameof(Page));
        }
        if (HasMore != other.HasMore)
        {
            HasMore = other.HasMore;
            OnPropertyChanged(nameof(HasMore));
        }
    }
}