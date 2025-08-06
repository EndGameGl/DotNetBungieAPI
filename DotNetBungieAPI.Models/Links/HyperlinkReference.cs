namespace DotNetBungieAPI.Models.Links;

public sealed class HyperlinkReference
{
    [JsonPropertyName("title")]
    public string Title { get; init; }

    [JsonPropertyName("url")]
    public string Url { get; init; }
}
