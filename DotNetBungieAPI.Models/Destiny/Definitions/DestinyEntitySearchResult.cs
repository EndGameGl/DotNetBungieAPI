namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     The results of a search for Destiny content. This will be improved on over time, I've been doing some experimenting to see what might be useful.
/// </summary>
public sealed class DestinyEntitySearchResult
{
    /// <summary>
    ///     A list of suggested words that might make for better search results, based on the text searched for.
    /// </summary>
    [JsonPropertyName("suggestedWords")]
    public string[]? SuggestedWords { get; init; }

    /// <summary>
    ///     The items found that are matches/near matches for the searched-for term, sorted by something vaguely resembling "relevance". Hopefully this will get better in the future.
    /// </summary>
    [JsonPropertyName("results")]
    public SearchResultOfDestinyEntitySearchResultItem? Results { get; init; }
}
