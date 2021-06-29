using System.Text.Json.Serialization;
using NetBungieAPI.Models.GroupsV2;

namespace NetBungieAPI.Models.Queries
{
    public sealed record GroupApplicationResponse
    {
        [JsonPropertyName("resolution")] public GroupApplicationResolveState Resolution { get; init; }
    }
}