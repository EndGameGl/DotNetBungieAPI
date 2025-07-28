using System.Diagnostics;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

#if DEBUG
[DebuggerDisplay("{Name} - {Description}")]
#endif
public class Tag
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }
}
