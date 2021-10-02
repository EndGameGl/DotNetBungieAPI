using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Content
{
    public sealed record TagMetadataItem
    {
        [JsonPropertyName("description")] public string Description { get; init; }

        [JsonPropertyName("tagText")] public string TagText { get; init; }

        [JsonPropertyName("groups")]
        public ReadOnlyCollection<string> Groups { get; init; } = Defaults.EmptyReadOnlyCollection<string>();

        [JsonPropertyName("isDefault")] public bool IsDefault { get; init; }

        [JsonPropertyName("name")] public string Name { get; init; }
    }
}