using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Content
{
    public sealed record TagMetadataDefinition
    {
        [JsonPropertyName("description")] public string Description { get; init; }

        [JsonPropertyName("order")] public int Order { get; init; }

        [JsonPropertyName("items")]
        public ReadOnlyCollection<TagMetadataItem> Items { get; init; } =
            Defaults.EmptyReadOnlyCollection<TagMetadataItem>();

        [JsonPropertyName("datatype")] public string Datatype { get; init; }

        [JsonPropertyName("name")] public string Name { get; init; }

        [JsonPropertyName("isRequired")] public bool IsRequired { get; init; }
    }
}