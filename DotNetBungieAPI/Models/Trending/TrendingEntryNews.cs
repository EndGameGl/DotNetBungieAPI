using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Content;

namespace DotNetBungieAPI.Models.Trending
{
    public sealed record TrendingEntryNews
    {
        [JsonPropertyName("article")] public ContentItemPublicContract Article { get; init; }
    }
}