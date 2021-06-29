using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public class GroupApplicationRequest
    {
        [JsonPropertyName("message")] public string Message { get; init; }
    }
}