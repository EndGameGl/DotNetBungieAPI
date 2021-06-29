using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Content
{
    public sealed record ContentPreview
    {
        [JsonPropertyName("name")] public string Name { get; init; }

        [JsonPropertyName("path")] public string Path { get; init; }

        [JsonPropertyName("itemInSet")] public bool ItemInSet { get; init; }

        [JsonPropertyName("setTag")] public string SetTag { get; init; }

        [JsonPropertyName("setNesting")] public int SetNesting { get; init; }

        [JsonPropertyName("useSetId")] public int UseSetId { get; init; }
    }
}