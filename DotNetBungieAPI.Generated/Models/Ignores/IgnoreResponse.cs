namespace DotNetBungieAPI.Generated.Models.Ignores;

public class IgnoreResponse
{
    [JsonPropertyName("isIgnored")]
    public bool? IsIgnored { get; set; }

    [JsonPropertyName("ignoreFlags")]
    public Ignores.IgnoreStatus? IgnoreFlags { get; set; }
}
