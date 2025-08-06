namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyArrangementRegionFilterDefinition
{
    [JsonPropertyName("artArrangementRegionHash")]
    public uint ArtArrangementRegionHash { get; init; }

    [JsonPropertyName("artArrangementRegionIndex")]
    public int ArtArrangementRegionIndex { get; init; }

    [JsonPropertyName("statHash")]
    public uint StatHash { get; init; }

    [JsonPropertyName("arrangementIndexByStatValue")]
    public Dictionary<int, int>? ArrangementIndexByStatValue { get; init; }
}
