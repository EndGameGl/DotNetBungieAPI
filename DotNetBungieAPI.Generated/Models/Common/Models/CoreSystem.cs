namespace DotNetBungieAPI.Generated.Models.Common.Models;

public class CoreSystem : IDeepEquatable<CoreSystem>
{
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, string> Parameters { get; set; }

    public bool DeepEquals(CoreSystem? other)
    {
        return other is not null &&
               Enabled == other.Enabled &&
               Parameters.DeepEqualsDictionaryNaive(other.Parameters);
    }
}