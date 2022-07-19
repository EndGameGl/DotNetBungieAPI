namespace DotNetBungieAPI.Models.Content;

public sealed record NewsArticleRssItem
{
    [JsonPropertyName("Title")]
    public string Title { get; init; }

    [JsonPropertyName("Link")]
    public string Link { get; init; }

    [JsonPropertyName("PubDate")]
    public DateTime PubDate { get; init; }

    [JsonPropertyName("UniqueIdentifier")]
    public string UniqueIdentifier { get; init; }

    [JsonPropertyName("Description")]
    public string Description { get; init; }
}