namespace DotNetBungieAPI.Generated.Models.Content;

public class NewsArticleRssResponse
{
    [JsonPropertyName("CurrentPaginationToken")]
    public int CurrentPaginationToken { get; set; }

    [JsonPropertyName("NextPaginationToken")]
    public int? NextPaginationToken { get; set; }

    [JsonPropertyName("ResultCountThisPage")]
    public int ResultCountThisPage { get; set; }

    [JsonPropertyName("NewsArticles")]
    public Content.NewsArticleRssItem[]? NewsArticles { get; set; }

    [JsonPropertyName("CategoryFilter")]
    public string CategoryFilter { get; set; }

    [JsonPropertyName("PagerAction")]
    public string PagerAction { get; set; }
}
