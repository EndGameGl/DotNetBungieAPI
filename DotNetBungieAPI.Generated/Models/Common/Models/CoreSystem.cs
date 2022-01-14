namespace DotNetBungieAPI.Generated.Models.Common.Models;

public sealed class CoreSystem
{

    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, string> Parameters { get; init; }
}
