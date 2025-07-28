namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public class DestinyRecordTitleBlock
{
    [JsonPropertyName("hasTitle")]
    public bool HasTitle { get; set; }

    [JsonPropertyName("titlesByGender")]
    public Dictionary<Destiny.DestinyGender, string>? TitlesByGender { get; set; }

    /// <summary>
    ///     For those who prefer to use the definitions.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyGenderDefinition>("Destiny.Definitions.DestinyGenderDefinition")]
    [JsonPropertyName("titlesByGenderHash")]
    public Dictionary<uint, string>? TitlesByGenderHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Records.DestinyRecordDefinition>("Destiny.Definitions.Records.DestinyRecordDefinition")]
    [JsonPropertyName("gildingTrackingRecordHash")]
    public uint? GildingTrackingRecordHash { get; set; }
}
