namespace DotNetBungieAPI.Models;

public sealed class StreamInfo
{
    [JsonPropertyName("ChannelName")]
    public string ChannelName { get; init; }
}
