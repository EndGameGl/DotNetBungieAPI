namespace DotNetBungieAPI.Generated.Models;

public class StreamInfo : IDeepEquatable<StreamInfo>
{
    [JsonPropertyName("ChannelName")]
    public string ChannelName { get; set; }

    public bool DeepEquals(StreamInfo? other)
    {
        return other is not null &&
               ChannelName == other.ChannelName;
    }
}