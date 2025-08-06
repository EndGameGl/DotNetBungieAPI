namespace DotNetBungieAPI.Models.Content;

public sealed class NewsArticleRssResponse
{
    [JsonPropertyName("CurrentPaginationToken")]
    public int CurrentPaginationToken { get; init; }

    [JsonPropertyName("NextPaginationToken")]
    public int? NextPaginationToken { get; init; }

    [JsonPropertyName("ResultCountThisPage")]
    public int ResultCountThisPage { get; init; }

    [JsonPropertyName("NewsArticles")]
    public Content.NewsArticleRssItem[]? NewsArticles { get; init; }

    [JsonPropertyName("CategoryFilter")]
    public string CategoryFilter { get; init; }

    [JsonPropertyName("PagerAction")]
    public string PagerAction { get; init; }
}
