namespace DotNetBungieAPI.Generated.Models.Common.Models;

public class CoreSystem
{
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, string> Parameters { get; set; }
}
