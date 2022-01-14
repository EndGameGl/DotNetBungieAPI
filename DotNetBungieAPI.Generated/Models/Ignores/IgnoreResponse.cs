namespace DotNetBungieAPI.Generated.Models.Ignores;

public sealed class IgnoreResponse
{

    [JsonPropertyName("isIgnored")]
    public bool IsIgnored { get; init; }

    [JsonPropertyName("ignoreFlags")]
    public Ignores.IgnoreStatus IgnoreFlags { get; init; }
}
