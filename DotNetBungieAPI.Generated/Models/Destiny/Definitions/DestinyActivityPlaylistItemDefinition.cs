using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyActivityPlaylistItemDefinition
{

    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; init; }

    [JsonPropertyName("directActivityModeHash")]
    public uint? DirectActivityModeHash { get; init; }

    [JsonPropertyName("directActivityModeType")]
    public int? DirectActivityModeType { get; init; }

    [JsonPropertyName("activityModeHashes")]
    public List<uint> ActivityModeHashes { get; init; }

    [JsonPropertyName("activityModeTypes")]
    public List<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> ActivityModeTypes { get; init; }
}
