using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models
{
    public sealed record StreamInfo
    {
        [JsonPropertyName("ChannelName")] public string ChannelName { get; init; }
    }
}