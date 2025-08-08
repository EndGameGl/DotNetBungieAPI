namespace DotNetBungieAPI.Models.Destiny.Definitions.Records;

public sealed class DestinyRecordTitleBlock
{
    [JsonPropertyName("hasTitle")]
    public bool HasTitle { get; init; }

    [JsonPropertyName("titlesByGender")]
    public Dictionary<Destiny.DestinyGender, string>? TitlesByGender { get; init; }

    /// <summary>
    ///     For those who prefer to use the definitions.
    /// </summary>
    [JsonPropertyName("titlesByGenderHash")]
    public Dictionary<DefinitionHashPointer<Destiny.Definitions.DestinyGenderDefinition>, string>? TitlesByGenderHash { get; init; }

    [JsonPropertyName("gildingTrackingRecordHash")]
    public DefinitionHashPointer<Destiny.Definitions.Records.DestinyRecordDefinition> GildingTrackingRecordHash { get; init; }
}
