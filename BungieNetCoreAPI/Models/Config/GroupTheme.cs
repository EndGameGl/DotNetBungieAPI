using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Config
{
    public sealed record GroupTheme
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("folder")]
        public string Folder { get; init; }

        [JsonPropertyName("description")]
        public string Description { get; init; }
    }
}
