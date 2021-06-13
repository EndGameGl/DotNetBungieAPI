using NetBungieAPI.Models.Content;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfContentItemPublicContract : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<ContentItemPublicContract> Results { get; init; } = Defaults.EmptyReadOnlyCollection<ContentItemPublicContract>();
    }
}
