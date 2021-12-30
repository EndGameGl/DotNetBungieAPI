using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Config;

public sealed class GroupTheme
{

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("folder")]
    public string Folder { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }
}
