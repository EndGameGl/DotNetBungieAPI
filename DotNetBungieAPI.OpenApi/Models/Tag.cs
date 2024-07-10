using System.Diagnostics;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.OpenApi.Models;

#if DEBUG
[DebuggerDisplay("{DebuggerDisplay}")]
#endif
public class Tag
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }

#if DEBUG
    private string DebuggerDisplay => $"{Name} - {Description}";
#endif
}
