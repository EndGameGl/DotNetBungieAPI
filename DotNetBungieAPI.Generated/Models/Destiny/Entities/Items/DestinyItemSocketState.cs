using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

public sealed class DestinyItemSocketState
{

    [JsonPropertyName("plugHash")]
    public uint? PlugHash { get; init; }

    [JsonPropertyName("isEnabled")]
    public bool IsEnabled { get; init; }

    [JsonPropertyName("isVisible")]
    public bool IsVisible { get; init; }

    [JsonPropertyName("enableFailIndexes")]
    public List<int> EnableFailIndexes { get; init; }
}
