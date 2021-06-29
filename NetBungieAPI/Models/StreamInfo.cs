using System.Text.Json.Serialization;

namespace NetBungieAPI.Models
{
    public sealed record StreamInfo
    {
        [JsonPropertyName("ChannelName")] public string ChannelName { get; init; }
    }
}