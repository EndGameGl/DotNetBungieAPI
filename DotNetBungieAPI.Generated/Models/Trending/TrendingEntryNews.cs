using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Trending;

public sealed class TrendingEntryNews
{

    [JsonPropertyName("article")]
    public Content.ContentItemPublicContract Article { get; init; }
}
