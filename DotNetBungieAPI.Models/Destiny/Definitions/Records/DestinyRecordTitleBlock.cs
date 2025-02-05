using DotNetBungieAPI.Models.Destiny.Definitions.Genders;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Records;

public sealed record DestinyRecordTitleBlock : IDeepEquatable<DestinyRecordTitleBlock>
{
    [JsonPropertyName("hasTitle")]
    public bool HasTitle { get; init; }

    [JsonPropertyName("titlesByGender")]
    public ReadOnlyDictionary<DestinyGender, string> TitlesByGender { get; init; } =
        ReadOnlyDictionary<DestinyGender, string>.Empty;

    [JsonPropertyName("titlesByGenderHash")]
    public ReadOnlyDictionary<
        DefinitionHashPointer<DestinyGenderDefinition>,
        string
    > TitlesByGenderHash { get; init; } =
        ReadOnlyDictionary<DefinitionHashPointer<DestinyGenderDefinition>, string>.Empty;

    [JsonPropertyName("gildingTrackingRecordHash")]
    public DefinitionHashPointer<DestinyRecordDefinition> GildingTrackingRecord { get; init; } =
        DefinitionHashPointer<DestinyRecordDefinition>.Empty;

    public bool DeepEquals(DestinyRecordTitleBlock other)
    {
        return other != null
            && HasTitle == other.HasTitle
            && TitlesByGender.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndSimpleValue(
                other.TitlesByGender
            )
            && TitlesByGenderHash.DeepEqualsReadOnlyDictionaryWithDefinitionKeyAndSimpleValue(
                other.TitlesByGenderHash
            )
            && GildingTrackingRecord.DeepEquals(other.GildingTrackingRecord);
    }
}
