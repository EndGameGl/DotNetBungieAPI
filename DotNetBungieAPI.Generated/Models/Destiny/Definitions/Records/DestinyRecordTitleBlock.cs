using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public sealed class DestinyRecordTitleBlock
{

    [JsonPropertyName("hasTitle")]
    public bool HasTitle { get; init; }

    [JsonPropertyName("titlesByGender")]
    public Dictionary<Destiny.DestinyGender, string> TitlesByGender { get; init; }

    [JsonPropertyName("titlesByGenderHash")]
    public Dictionary<uint, string> TitlesByGenderHash { get; init; }

    [JsonPropertyName("gildingTrackingRecordHash")]
    public uint? GildingTrackingRecordHash { get; init; }
}
