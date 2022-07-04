namespace DotNetBungieAPI.Models.Destiny.Responses;

/// <summary>
///     The results of a search for Destiny content. This will be improved on over time, I've been doing some experimenting
///     to see what might be useful.
/// </summary>
public sealed record DestinyEntitySearchResult
{
    /// <summary>
    ///     A list of suggested words that might make for better search results, based on the text searched for.
    /// </summary>
    [JsonPropertyName("suggestedWords")]
    public ReadOnlyCollection<string> SuggestedWords { get; init; } = ReadOnlyCollections<string>.Empty;

    /// <summary>
    ///     The items found that are matches/near matches for the searched-for term, sorted by something vaguely resembling
    ///     "relevance". Hopefully this will get better in the future.
    /// </summary>
    [JsonPropertyName("results")]
    public SearchResultOfDestinyEntitySearch Results { get; init; }
}