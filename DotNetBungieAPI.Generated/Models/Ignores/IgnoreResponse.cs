namespace DotNetBungieAPI.Generated.Models.Ignores;

public class IgnoreResponse : IDeepEquatable<IgnoreResponse>
{
    [JsonPropertyName("isIgnored")]
    public bool IsIgnored { get; set; }

    [JsonPropertyName("ignoreFlags")]
    public Ignores.IgnoreStatus IgnoreFlags { get; set; }

    public bool DeepEquals(IgnoreResponse? other)
    {
        return other is not null &&
               IsIgnored == other.IsIgnored &&
               IgnoreFlags == other.IgnoreFlags;
    }
}