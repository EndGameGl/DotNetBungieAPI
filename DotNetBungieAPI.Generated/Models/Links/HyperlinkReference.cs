namespace DotNetBungieAPI.Generated.Models.Links;

public class HyperlinkReference : IDeepEquatable<HyperlinkReference>
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    public bool DeepEquals(HyperlinkReference? other)
    {
        return other is not null &&
               Title == other.Title &&
               Url == other.Url;
    }
}