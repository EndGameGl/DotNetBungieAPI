using NetBungieAPI.Models.GroupsV2;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public sealed record GroupApplicationResponse
    {
        [JsonPropertyName("resolution")]
        public GroupApplicationResolveState Resolution { get; init; }
    }
}
