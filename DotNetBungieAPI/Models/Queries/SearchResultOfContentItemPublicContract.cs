using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.Content;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfContentItemPublicContract : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<ContentItemPublicContract> Results { get; init; } =
            ReadOnlyCollections<ContentItemPublicContract>.Empty;
    }
}