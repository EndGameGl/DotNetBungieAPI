using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Applications
{
    public sealed record ApiUsage
    {
        [JsonPropertyName("apiCalls")]
        public ReadOnlyCollection<Series> ApiCalls { get; init; } = Defaults.EmptyReadOnlyCollection<Series>();

        [JsonPropertyName("throttledRequests")]
        public ReadOnlyCollection<Series> ThrottledRequests { get; init; } = Defaults.EmptyReadOnlyCollection<Series>();
    }
}
