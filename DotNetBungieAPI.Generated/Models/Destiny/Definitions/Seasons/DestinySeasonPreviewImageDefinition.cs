using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Seasons;

public sealed class DestinySeasonPreviewImageDefinition
{

    [JsonPropertyName("thumbnailImage")]
    public string ThumbnailImage { get; init; }

    [JsonPropertyName("highResImage")]
    public string HighResImage { get; init; }
}
