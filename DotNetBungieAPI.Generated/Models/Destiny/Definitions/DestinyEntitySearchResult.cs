namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The results of a search for Destiny content. This will be improved on over time, I've been doing some experimenting to see what might be useful.
/// </summary>
public class DestinyEntitySearchResult : IDeepEquatable<DestinyEntitySearchResult>
{
    /// <summary>
    ///     A list of suggested words that might make for better search results, based on the text searched for.
    /// </summary>
    [JsonPropertyName("suggestedWords")]
    public List<string> SuggestedWords { get; set; }

    /// <summary>
    ///     The items found that are matches/near matches for the searched-for term, sorted by something vaguely resembling "relevance". Hopefully this will get better in the future.
    /// </summary>
    [JsonPropertyName("results")]
    public SearchResultOfDestinyEntitySearchResultItem Results { get; set; }

    public bool DeepEquals(DestinyEntitySearchResult? other)
    {
        return other is not null &&
               SuggestedWords.DeepEqualsListNaive(other.SuggestedWords) &&
               (Results is not null ? Results.DeepEquals(other.Results) : other.Results is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyEntitySearchResult? other)
    {
        if (other is null) return;
        if (!SuggestedWords.DeepEqualsListNaive(other.SuggestedWords))
        {
            SuggestedWords = other.SuggestedWords;
            OnPropertyChanged(nameof(SuggestedWords));
        }
        if (!Results.DeepEquals(other.Results))
        {
            Results.Update(other.Results);
            OnPropertyChanged(nameof(Results));
        }
    }
}