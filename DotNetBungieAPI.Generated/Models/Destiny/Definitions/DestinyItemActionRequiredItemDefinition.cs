using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyItemActionRequiredItemDefinition
{

    [JsonPropertyName("count")]
    public int Count { get; init; }

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }

    [JsonPropertyName("deleteOnAction")]
    public bool DeleteOnAction { get; init; }
}
