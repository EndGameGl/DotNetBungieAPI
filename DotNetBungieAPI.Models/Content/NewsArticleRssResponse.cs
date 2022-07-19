﻿namespace DotNetBungieAPI.Models.Content;

public sealed record NewsArticleRssResponse
{
    [JsonPropertyName("NewsArticles")]
    public ReadOnlyCollection<NewsArticleRssItem> NewsArticles { get; init; } =
        ReadOnlyCollections<NewsArticleRssItem>.Empty;

    [JsonPropertyName("CurrentPaginationToken")]
    public int CurrentPaginationToken { get; init; }

    [JsonPropertyName("NextPaginationToken")]
    public int? NextPaginationToken { get; init; }

    [JsonPropertyName("ResultCountThisPage")]
    public int ResultCountThisPage { get; init; }
}