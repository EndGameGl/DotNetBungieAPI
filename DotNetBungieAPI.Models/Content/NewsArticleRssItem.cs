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

    [JsonPropertyName("HtmlContent")]
    public string? HtmlContent { get; init; }

    [JsonPropertyName("ImagePath")]
    public string? ImagePath { get; init; }

    [JsonPropertyName("OptionalMobileImagePath")]
    public string? OptionalMobileImagePath { get; init; }
}
