namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyArrangementRegionFilterDefinition
{
    [JsonPropertyName("artArrangementRegionHash")]
    public uint? ArtArrangementRegionHash { get; set; }

    [JsonPropertyName("artArrangementRegionIndex")]
    public int? ArtArrangementRegionIndex { get; set; }

    [JsonPropertyName("statHash")]
    public uint? StatHash { get; set; }

    [JsonPropertyName("arrangementIndexByStatValue")]
    public Dictionary<int, int> ArrangementIndexByStatValue { get; set; }
}
