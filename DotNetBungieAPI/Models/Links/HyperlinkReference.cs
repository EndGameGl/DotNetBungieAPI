namespace DotNetBungieAPI.Models.Links;

public sealed record HyperlinkReference : IDeepEquatable<HyperlinkReference>
{
    [JsonPropertyName("title")] public string Title { get; init; }

    [JsonPropertyName("url")] public string Url { get; init; }

    public bool DeepEquals(HyperlinkReference other)
    {
        return other != null && Title == other.Title && Url == other.Url;
    }
}