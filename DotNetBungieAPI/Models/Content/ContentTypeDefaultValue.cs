using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Content
{
    public sealed record ContentTypeDefaultValue
    {
        [JsonPropertyName("whenClause")] public string WhenClause { get; init; }

        [JsonPropertyName("whenValue")] public string WhenValue { get; init; }

        [JsonPropertyName("defaultValue")] public string DefaultValue { get; init; }
    }
}