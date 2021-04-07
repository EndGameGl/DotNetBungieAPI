using NetBungieAPI.Models.Forum;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public sealed record SearchResultOfPostResponse : SearchResultBase
    {
        [JsonPropertyName("results")]
        public ReadOnlyCollection<PostResponse> Results { get; init; } = Defaults.EmptyReadOnlyCollection<PostResponse>();
    }
    
}
