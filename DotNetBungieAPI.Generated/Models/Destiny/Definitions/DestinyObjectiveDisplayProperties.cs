using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyObjectiveDisplayProperties
{

    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; init; }

    [JsonPropertyName("displayOnItemPreviewScreen")]
    public bool DisplayOnItemPreviewScreen { get; init; }
}
