using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyEntitySearchResultItem
{

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("entityType")]
    public string EntityType { get; init; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("weight")]
    public double Weight { get; init; }
}
