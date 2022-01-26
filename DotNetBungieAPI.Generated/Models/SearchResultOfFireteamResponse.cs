namespace DotNetBungieAPI.Generated.Models;

public class SearchResultOfFireteamResponse : IDeepEquatable<SearchResultOfFireteamResponse>
{
    [JsonPropertyName("results")]
    public List<Fireteam.FireteamResponse> Results { get; set; }

    [JsonPropertyName("totalResults")]
    public int TotalResults { get; set; }

    [JsonPropertyName("hasMore")]
    public bool HasMore { get; set; }

    [JsonPropertyName("query")]
    public Queries.PagedQuery Query { get; set; }

    [JsonPropertyName("replacementContinuationToken")]
    public string ReplacementContinuationToken { get; set; }

    /// <summary>
    ///     If useTotalResults is true, then totalResults represents an accurate count.
    /// <para />
    ///     If False, it does not, and may be estimated/only the size of the current page.
    /// <para />
    ///     Either way, you should probably always only trust hasMore.
    /// <para />
    ///     This is a long-held historical throwback to when we used to do paging with known total results. Those queries toasted our database, and we were left to hastily alter our endpoints and create backward- compatible shims, of which useTotalResults is one.
    /// </summary>
    [JsonPropertyName("useTotalResults")]
    public bool UseTotalResults { get; set; }

    public bool DeepEquals(SearchResultOfFireteamResponse? other)
    {
        return other is not null &&
               Results.DeepEqualsList(other.Results) &&
               TotalResults == other.TotalResults &&
               HasMore == other.HasMore &&
               (Query is not null ? Query.DeepEquals(other.Query) : other.Query is null) &&
               ReplacementContinuationToken == other.ReplacementContinuationToken &&
               UseTotalResults == other.UseTotalResults;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(SearchResultOfFireteamResponse? other)
    {
        if (other is null) return;
        if (!Results.DeepEqualsList(other.Results))
        {
            Results = other.Results;
            OnPropertyChanged(nameof(Results));
        }
        if (TotalResults != other.TotalResults)
        {
            TotalResults = other.TotalResults;
            OnPropertyChanged(nameof(TotalResults));
        }
        if (HasMore != other.HasMore)
        {
            HasMore = other.HasMore;
            OnPropertyChanged(nameof(HasMore));
        }
        if (!Query.DeepEquals(other.Query))
        {
            Query.Update(other.Query);
            OnPropertyChanged(nameof(Query));
        }
        if (ReplacementContinuationToken != other.ReplacementContinuationToken)
        {
            ReplacementContinuationToken = other.ReplacementContinuationToken;
            OnPropertyChanged(nameof(ReplacementContinuationToken));
        }
        if (UseTotalResults != other.UseTotalResults)
        {
            UseTotalResults = other.UseTotalResults;
            OnPropertyChanged(nameof(UseTotalResults));
        }
    }
}