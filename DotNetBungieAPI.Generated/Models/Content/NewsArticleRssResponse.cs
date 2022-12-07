namespace DotNetBungieAPI.Generated.Models.Content;

public class NewsArticleRssResponse
{
    [JsonPropertyName("NewsArticles")]
    public List<Content.NewsArticleRssItem> NewsArticles { get; set; }

    [JsonPropertyName("CurrentPaginationToken")]
    public int? CurrentPaginationToken { get; set; }

    [JsonPropertyName("NextPaginationToken")]
    public int? NextPaginationToken { get; set; }

    [JsonPropertyName("ResultCountThisPage")]
    public int? ResultCountThisPage { get; set; }

    [JsonPropertyName("CategoryFilter")]
    public string? CategoryFilter { get; set; }
}
