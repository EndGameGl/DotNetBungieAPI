using System.Text.Json.Serialization;
using NetBungieAPI.Models.Ignores;

namespace NetBungieAPI.Models.Queries
{
    public class GroupBanRequest
    {
        [JsonPropertyName("comment")] public string Comment { get; init; }

        [JsonPropertyName("length")] public IgnoreLength Length { get; init; }
    }
}