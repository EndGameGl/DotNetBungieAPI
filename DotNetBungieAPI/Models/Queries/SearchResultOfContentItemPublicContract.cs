using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Content;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfContentItemPublicContract : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<ContentItemPublicContract> Results { get; init; } =
            Defaults.EmptyReadOnlyCollection<ContentItemPublicContract>();
    }
}