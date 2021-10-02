using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.GroupsV2;

namespace DotNetBungieAPI.Models.Queries
{
    public sealed record GroupApplicationResponse
    {
        [JsonPropertyName("resolution")] public GroupApplicationResolveState Resolution { get; init; }
    }
}