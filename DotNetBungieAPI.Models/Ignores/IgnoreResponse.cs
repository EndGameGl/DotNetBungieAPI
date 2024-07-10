namespace DotNetBungieAPI.Models.Ignores;

public sealed record IgnoreResponse
{
    [JsonPropertyName("isIgnored")]
    public bool IsIgnored { get; init; }

    [JsonPropertyName("ignoreFlags")]
    public IgnoreStatus IgnoreFlags { get; init; }
}
