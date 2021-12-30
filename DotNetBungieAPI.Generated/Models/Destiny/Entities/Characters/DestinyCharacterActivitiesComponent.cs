using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Characters;

public sealed class DestinyCharacterActivitiesComponent
{

    [JsonPropertyName("dateActivityStarted")]
    public DateTime DateActivityStarted { get; init; }

    [JsonPropertyName("availableActivities")]
    public List<Destiny.DestinyActivity> AvailableActivities { get; init; }

    [JsonPropertyName("currentActivityHash")]
    public uint CurrentActivityHash { get; init; }

    [JsonPropertyName("currentActivityModeHash")]
    public uint CurrentActivityModeHash { get; init; }

    [JsonPropertyName("currentActivityModeType")]
    public int? CurrentActivityModeType { get; init; }

    [JsonPropertyName("currentActivityModeHashes")]
    public List<uint> CurrentActivityModeHashes { get; init; }

    [JsonPropertyName("currentActivityModeTypes")]
    public List<Destiny.HistoricalStats.Definitions.DestinyActivityModeType> CurrentActivityModeTypes { get; init; }

    [JsonPropertyName("currentPlaylistActivityHash")]
    public uint? CurrentPlaylistActivityHash { get; init; }

    [JsonPropertyName("lastCompletedStoryHash")]
    public uint LastCompletedStoryHash { get; init; }
}
