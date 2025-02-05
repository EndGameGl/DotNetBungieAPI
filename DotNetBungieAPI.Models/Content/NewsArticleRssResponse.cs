namespace DotNetBungieAPI.Models.Content;

public sealed record NewsArticleRssResponse
{
    [JsonPropertyName("NewsArticles")]
    public ReadOnlyCollection<NewsArticleRssItem> NewsArticles { get; init; } =
        ReadOnlyCollection<NewsArticleRssItem>.Empty;

    [JsonPropertyName("CurrentPaginationToken")]
    public int CurrentPaginationToken { get; init; }

    [JsonPropertyName("NextPaginationToken")]
    public int? NextPaginationToken { get; init; }

    [JsonPropertyName("ResultCountThisPage")]
    public int ResultCountThisPage { get; init; }

    [JsonPropertyName("CategoryFilter")]
    public string? CategoryFilter { get; init; }

    [JsonPropertyName("PagerAction")]
    public string PagerAction { get; init; }
}
