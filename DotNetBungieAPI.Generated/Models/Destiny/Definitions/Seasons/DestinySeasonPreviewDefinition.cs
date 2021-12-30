using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Seasons;

public sealed class DestinySeasonPreviewDefinition
{

    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("linkPath")]
    public string LinkPath { get; init; }

    [JsonPropertyName("videoLink")]
    public string VideoLink { get; init; }

    [JsonPropertyName("images")]
    public List<Destiny.Definitions.Seasons.DestinySeasonPreviewImageDefinition> Images { get; init; }
}
