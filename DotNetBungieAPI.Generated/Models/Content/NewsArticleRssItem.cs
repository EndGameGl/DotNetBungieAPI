namespace DotNetBungieAPI.Generated.Models.Content;

public class NewsArticleRssItem
{
    [JsonPropertyName("Title")]
    public string? Title { get; set; }

    [JsonPropertyName("Link")]
    public string? Link { get; set; }

    [JsonPropertyName("PubDate")]
    public DateTime? PubDate { get; set; }

    [JsonPropertyName("UniqueIdentifier")]
    public string? UniqueIdentifier { get; set; }

    [JsonPropertyName("Description")]
    public string? Description { get; set; }

    [JsonPropertyName("HtmlContent")]
    public string? HtmlContent { get; set; }

    [JsonPropertyName("ImagePath")]
    public string? ImagePath { get; set; }

    [JsonPropertyName("OptionalMobileImagePath")]
    public string? OptionalMobileImagePath { get; set; }
}
