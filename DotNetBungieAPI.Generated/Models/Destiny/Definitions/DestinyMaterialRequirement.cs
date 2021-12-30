using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyMaterialRequirement
{

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }

    [JsonPropertyName("deleteOnAction")]
    public bool DeleteOnAction { get; init; }

    [JsonPropertyName("count")]
    public int Count { get; init; }

    [JsonPropertyName("omitFromRequirements")]
    public bool OmitFromRequirements { get; init; }
}
