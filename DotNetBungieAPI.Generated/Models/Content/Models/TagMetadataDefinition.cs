using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Content.Models;

public sealed class TagMetadataDefinition
{

    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("order")]
    public int Order { get; init; }

    [JsonPropertyName("items")]
    public List<Content.Models.TagMetadataItem> Items { get; init; }

    [JsonPropertyName("datatype")]
    public string Datatype { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("isRequired")]
    public bool IsRequired { get; init; }
}
